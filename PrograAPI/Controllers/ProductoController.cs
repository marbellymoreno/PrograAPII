using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrograAPI.DTOs;
using PrograAPI.Models;

namespace PrograAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private Context _context;

        public ProductoController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductoDTO>> Get() =>
            await _context.Productos.Select(b => new ProductoDTO
            {
                Id = b.Id,
                Nombre = b.Nombre,
                Precio = b.Precio,
                Stock = b.Stock,
            }).ToListAsync();

        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductoDTO>> GetById(int Id)
        {
            var producto = await _context.Productos.FindAsync(Id);
            if (producto == null)
            {
                return NotFound();
            }

            var productoDTO = new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock,
            };

            return Ok(productoDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> Add(InsertarProductoDTO productoInsertDTO)
        {
            var producto = new Producto
            {
                Nombre = productoInsertDTO.Nombre,
                Precio = productoInsertDTO.Precio,
                Stock = productoInsertDTO.Stock
            };

            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();

            var productoDTO = new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock
            };

            return CreatedAtAction(nameof(GetById), new { Id = producto.Id }, productoDTO);
        }
    }
}
