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
using TreinaWeb.MyApi.Api.DTOs;
using TreinaWeb.MyApi.Api.AutoMapper;
using TreinaWeb.MyApi.Api.Filters;

namespace TreinaWeb.MyApi.Api.Controllers
{
    [RoutePrefix("api/aluno")]
    public class AlunoController : ApiController
    {
        private IRepository<Aluno, int> _alunoRepository = new AlunoRepository(new MyApiDbContext());

        
        public IHttpActionResult Get()
        {
            List<Aluno> alunos = _alunoRepository.Selecionar();
            List<AlunoDTO> alunosDto = AutoMapperManager.Instance.Mapper.Map<List<Aluno>, List<AlunoDTO>>(alunos);
            return Ok(alunosDto);
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
            AlunoDTO alunoDto = AutoMapperManager.Instance.Mapper.Map<Aluno, AlunoDTO>(aluno);
            return Content(HttpStatusCode.OK, alunoDto);
        }

        [Route("por-nome/{nomeAluno}")]
        public IHttpActionResult Get(string nomeAluno)
        {
            List<Aluno> alunos = _alunoRepository.Selecionar(a => a.Nome.ToLower().Contains(nomeAluno.ToLower()));
            List<AlunoDTO> dtos = AutoMapperManager.Instance.Mapper.Map<List<Aluno>, List <AlunoDTO>>(alunos);
            return Ok(dtos);
        }

        [ApplyModelValidation]
        public IHttpActionResult Post([FromBody] AlunoDTO alunoDto)
        {
            try
            {
                Aluno aluno = AutoMapperManager.Instance.Mapper.Map<AlunoDTO, Aluno>(alunoDto);
                _alunoRepository.Inserir(aluno);
                return Created($"{Request.RequestUri}/{aluno.Id}", aluno);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [ApplyModelValidation]
        public IHttpActionResult Put(int? id, [FromBody] AlunoDTO alunoDto)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }
                alunoDto.Id = id.Value;
                Aluno aluno = AutoMapperManager.Instance.Mapper.Map<AlunoDTO, Aluno>(alunoDto);
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
