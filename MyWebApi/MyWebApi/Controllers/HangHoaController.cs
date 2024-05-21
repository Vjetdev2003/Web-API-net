using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }
        [HttpPost]
        public IActionResult Create(HangHoaVM hanghoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hanghoaVM.TenHangHoa,
                DonGia = hanghoaVM.DonGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true, Data = hanghoaVM
            });
        }
        [HttpGet("{id}")]
        public ActionResult GetId(string id)
        {
            try
            {
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id , HangHoa hangHoaEdit)
        {
            try
            {
                var hanghoa = hangHoas.SingleOrDefault(hh =>hh.MaHangHoa == Guid.Parse (id));
                if(hanghoa == null)
                {
                    return NotFound();
                } 
                //update
                if(id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                hanghoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hanghoa.DonGia = hangHoaEdit.DonGia;
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var hanghoa = hangHoas.SingleOrDefault(hh=>hh.MaHangHoa == Guid.Parse(id));
                if(hanghoa == null)
                {
                    return NotFound();
                }
                hangHoas.Remove(hanghoa);
                return Ok(hanghoa);
            } 
           catch { 
                return BadRequest(); 
            }
        }
    }
}
