using ApiModelo.Application.DTOs;
using ApiModelo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiModelo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IApplicationServiceProduto applicationServiceProduto;

        public ProdutoController(IApplicationServiceProduto applicationServiceProduto)
        {
            this.applicationServiceProduto = applicationServiceProduto;
        }



        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceProduto.GetAll());
        }

        // GET api/values/5\
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceProduto.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ProdutoDto produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();


                applicationServiceProduto.Add(produtoDTO);
                return Ok("O produto foi cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
        [HttpPut]
        public ActionResult Put(int id , [FromBody] ProdutoDto produtoDTO)
        {

            try
            {
                if (produtoDTO == null)
                    return NotFound();

                applicationServiceProduto.Update(id , produtoDTO);
                return Ok("O produto foi atualizado com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == null)
                    return NotFound();               

                applicationServiceProduto.Delete(id); // Passando o ID como string
                return Ok("O produto foi removido com sucesso!");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}