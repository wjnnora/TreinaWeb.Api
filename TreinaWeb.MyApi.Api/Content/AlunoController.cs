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

        public IHttpActionResult Get()
        {
            return Ok(_alunoRepository.Selecionar());
        }

        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            Aluno aluno = _alunoRepository.SelecionarPorId(id.Value);
            if (aluno == null)
            {
                return NotFound();
            }
            return Content(HttpStatusCode.Found, aluno);
        }

        public IHttpActionResult Post([FromBody] Aluno aluno)
        {
            try
            {
                _alunoRepository.Inserir(aluno);
                return Created($"{Request.RequestUri}/{aluno.Id}", aluno);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Put(int? id, [FromBody] Aluno aluno)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }
                aluno.Id = id.Value;
                _alunoRepository.Atualizar(aluno);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }
                Aluno aluno = _alunoRepository.SelecionarPorId(id.Value);
                if (aluno == null)
                {
                    return NotFound();
                }
                _alunoRepository.Excluir(aluno);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        
    }
}
