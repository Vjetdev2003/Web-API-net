using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApiNet5.Data;
using WebApiNet5.Models;

namespace WebApiNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDBContext _context;

        public LoaisController(MyDBContext context) 
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var dsLoai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (dsLoai != null) {
                return Ok(dsLoai);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);

            }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpPut("{id}")]
        public IActionResult EditById(int id,LoaiModel model) {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            try
            {
                if (loai != null) 
                { 
                    loai.TenLoai = model.TenLoai;
                }
                _context.Update(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveById(int id) 
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
             try
                {
                if(loai == null)
                {
                    return NotFound();
                }
                _context.Remove(loai);
                _context.SaveChanges(); 
                     return Ok(loai);
                }
            catch
                {
                    return BadRequest();
                }
         }
    }
}
