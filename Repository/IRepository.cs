using gp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gp2.Repository
{///
    public interface IRepository<T> where T :class
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> FindAsync(int id);

        T Find(int id);

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="t"></param>
        void Add(T t);


        /// <summary>
        /// 删
        /// </summary>
        /// <param name="t"></param>
        void Delete(T t);

        /// <summary>
        /// 改
        /// </summary>
        /// <param name="t"></param>
        Task UpdateAsync(T t);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();


    }
}
