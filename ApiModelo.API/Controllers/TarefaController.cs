using ApiModelo.Application.DTOs;
using ApiModelo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiModelo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarefaController : Controller
    {
        private readonly IApplicationServiceTarefa applicationServiceTarefa;

        public TarefaController(IApplicationServiceTarefa applicationServiceTarefa)
        {
            this.applicationServiceTarefa = applicationServiceTarefa;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceTarefa.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceTarefa.GetById(id));
        }

        [HttpGet("{nome}")]
        public ActionResult<string> GetByName(string nome)
        {
            return Ok(applicationServiceTarefa.GetByName(nome));
        }

        [HttpPost]
        public ActionResult Post([FromBody] TarefaDto tarefaDTO)
        {
            try
            {
                if (tarefaDTO == null)
                    return NotFound();


                applicationServiceTarefa.Add(tarefaDTO);
                return Ok("A tarefa foi cadastrada com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] TarefaDto tarefaDTO)
        {

            try
            {
                if (tarefaDTO == null)
                    return NotFound();

                applicationServiceTarefa.Update(id, tarefaDTO);
                return Ok("A tarefa foi atualizada com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete()]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                applicationServiceTarefa.Delete(id); 
                return Ok("A tarefa foi removida com sucesso!");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
