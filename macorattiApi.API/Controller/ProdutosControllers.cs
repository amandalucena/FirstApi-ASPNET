using macorattiApi.API.Context;
using macorattiApi.API.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace macorattiApi.API.Controller;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    //Injetamos a dependencia
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _context.Produtos.ToList();

        if (produtos is null)
        {
            return NotFound("Produtos não encontrados");
        }
        return produtos;
    }

    [HttpGet("{id:int}")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

        if (produto is null)
        {
            return NotFound("Produto não encontrado");
        }

        return produto;
    }

    [HttpPost]
    public ActionResult<Produto> Post(Produto produto)
    {
        if (produto is null)
            return BadRequest();

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }
}
