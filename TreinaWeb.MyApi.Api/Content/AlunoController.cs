using _0_Domain;
using _2_Repository.EF;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service.Context;

namespace TreinaWeb.MyApi.Api.Content
{
    public class AlunoController : ApiController
    {
        private IRepository<Aluno, int> _alunoRepository = new AlunoRepository(new MyApiDbContext());

        public IEnumerable<Aluno> Get()
        {
            return _alunoRepository.Selecionar();
        }

        public Aluno Get(int? id)
        {
            return _alunoRepository.SelecionarPorId(id.Value);
        }
    }
}
