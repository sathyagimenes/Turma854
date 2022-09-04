using APIProdutos.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIProdutos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {

        public IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("/produto/{descricao}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Produto>> GetProduto(string descricao)
        {
            var resultado = _produtoService.GetProdutoDesc(descricao);
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        [HttpGet("/produto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Produto>> GetProdutos()
        {
            return Ok(_produtoService.GetProdutos());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Produto> PostProduto(Produto produto)
        {
            if (!_produtoService.InsertProduto(produto))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(PostProduto), produto);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateProduto(long id, Produto produto)
        {
            if (!_produtoService.UpdateProduto(id, produto))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Produto>> DeleteProduto(long id)
        {
            if (!_produtoService.DeleteProduto(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}