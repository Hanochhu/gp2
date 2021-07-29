using AutoMapper;
using gp2.DTO;
using gp2.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gp2.Extension
{
    public static class EntityAutoMapper
    {
        public static void AddLoaclAutoMapper(this IServiceCollection collection)
        {
            collection.AddAutoMapper(AddAutoMapperEntity);
        }

        public static void AddAutoMapperEntity(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Strategy, StaItem>();
            expression.CreateMap<User, StaItem>();
            expression.CreateMap<User, UserInfo>();
        }
    }
}
