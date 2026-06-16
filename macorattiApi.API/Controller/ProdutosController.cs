using macorattiApi.API.Context;
using macorattiApi.API.Domain;
using Microsoft.AspNetCore.Mvc;

namespace macorattiApi.API.Controller;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
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

    [HttpGet("{id:int}", Name = "Obterproduto")]
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

        return new CreatedAtRouteResult("Obterproduto", new { id = produto.Id }, produto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<Produto> Put(int id, Produto produto)
    {
        if (id != produto.Id)
            return BadRequest();

        _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();

        return Ok(produto);
    }
}
