using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiNet5.Models;

namespace WebApiNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> HangHoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(HangHoas);
        }

        [HttpPost]
        public IActionResult CreateProduct(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia,
            };
            HangHoas.Add(hanghoa);
            return Ok(new {
                Acccess = true, Data = hanghoa
                });
        }
        

        [HttpGet("{id}")]
        public IActionResult GetByID(string id) {
            try
            {
                var hanghoa = HangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if(hanghoa == null)
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
        public IActionResult Edit(string id, HangHoa EditHanghoa)
        {
            try
            {
                var hanghoa = HangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                if(id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                hanghoa.TenHangHoa = EditHanghoa.TenHangHoa;
                hanghoa.DonGia = EditHanghoa.DonGia;

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                var hanghoa = HangHoas.SingleOrDefault(hh=> hh.MaHangHoa == Guid.Parse(id));
                if(hanghoa == null)
                {
                    return NotFound();
                }
                //Remove
                HangHoas.Remove(hanghoa);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
