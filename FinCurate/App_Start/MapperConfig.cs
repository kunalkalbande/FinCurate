using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CommonLibrary.Models;
using FinCurate;

namespace FinCurate
{
    public static class MapperConfig
    {
        public static void AutoMapperBootstrap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProfitabilityEntityList, ProfitabilityRatio>();
           
             });
        }
    }
}