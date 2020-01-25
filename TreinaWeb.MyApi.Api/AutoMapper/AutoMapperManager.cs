using _0_Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinaWeb.MyApi.Api.DTOs;

namespace TreinaWeb.MyApi.Api.AutoMapper
{
    public class AutoMapperManager
    {
        private MapperConfiguration _config;
        private static readonly Lazy<AutoMapperManager> _instance
            = new Lazy<AutoMapperManager>(() =>
            {
                return new AutoMapperManager();
            });

        public static AutoMapperManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public IMapper Mapper
        {
            get
            {
                return _config.CreateMapper();
            }
        }
        public AutoMapperManager()
        {
            _config = new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<Aluno, AlunoDTO>();
                cfg.CreateMap<AlunoDTO, Aluno>();
            });
        }
    }
}