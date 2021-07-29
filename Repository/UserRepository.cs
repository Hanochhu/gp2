
using gp2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace gp2.Repository
{
    public class UserRepository : Repository<User>
    {
        private readonly Gp2Context _gp2Context;

        private DbSet<User> _entity;

        public UserRepository(Gp2Context gp2Context):base(gp2Context)
        {
            _gp2Context = gp2Context;
        }

        private DbSet<User> Entity => _entity ?? (_entity = _gp2Context.Set<User>());

        public async Task<User> FindByPhoneAsync(string phone)
        {
          
            
            return await _gp2Context.Users.Where(p => p.UserPhone.Equals(phone)).SingleOrDefaultAsync();

        }



    }
}
