using MasPorMenos.WebApi.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using Dominio.Entities;
using Dominio.Dtos;
namespace MasPorMenos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context) { 
        
            _context = context;
        }

        [HttpPost]
        public ActionResult Crear([FromBody] CrearProductoDto crearProductoDto)
        {

            Producto producto = new Producto();
            
            //Mapeo Manual

            //Dto - Entidad
            producto.Descripcion = crearProductoDto.Descripcion;
            producto.Categoria = crearProductoDto.Categoria;
            producto.Marca = crearProductoDto.Marca;    

            producto.Estado = "Registrado";
            producto.FechaRegistro = DateTime.Now;
            producto.Codigo = producto.Categoria.Substring(0, 1) + new Random().NextInt64(1, 10000); 
            _context.Productos.Add(producto);
            _context.SaveChanges();

            //Entidad - Dto
            ProductoCreadoDto productoCreadoDto = new ProductoCreadoDto();
            productoCreadoDto.Id = producto.Id;
            productoCreadoDto.FechaCreacion=producto.FechaRegistro;
            productoCreadoDto.Descripcion = producto.Descripcion;
            productoCreadoDto.Marca = producto.Marca;
            productoCreadoDto.Estado = producto.Estado;
            productoCreadoDto.Categoria = producto.Categoria;
            productoCreadoDto.Codigo = producto.Codigo;



            return Ok(productoCreadoDto);
        }

    }
}
