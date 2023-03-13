using Microsoft.AspNetCore.Mvc;
using System;
using Test_Api.Models;
using Test_Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private IHangHoaRepository _hangHoaRepository;

        public HangHoaController(IHangHoaRepository hangHoaRepository) {
            _hangHoaRepository = hangHoaRepository;
        }  

        [HttpGet]
        public async Task<IActionResult> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1)
        {
            try
            {
                return Ok(await _hangHoaRepository.GetAll(search, from, to, sortBy, page));            
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var hangHoa = _hangHoaRepository.GetById(id);
            return Ok(hangHoa);
        }

        // GET api/<HangHoaController>/5
        //[HttpGet("{id}")]
        //public IActionResult GetbyId(string id)
        //{
        //    try
        //    {
        //        var hangHoa = hangHoas.SingleOrDefault(d => d.MaHangHoa == Guid.Parse(id));
        //        if (hangHoa == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(hangHoa);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        //// POST api/<HangHoaController>
        //[HttpPost]
        //public IActionResult Post(HangHoaVM hangHoaVM)
        //{
        //    HangHoa hangHoa = new HangHoa()
        //    {
        //        MaHangHoa = Guid.NewGuid(),
        //        TenHangHoa = hangHoaVM.TenHangHoa,
        //        DonGia = hangHoaVM.DonGia
        //    };
        //    hangHoas.Add(hangHoa);
        //    return Ok(new
        //    {
        //        Success = true,
        //        Data = hangHoa
        //    });
        //}

        //// PUT api/<HangHoaController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(string id, HangHoa hangHoaEdit)
        //{
        //    try
        //    {
        //        var hangHoa = hangHoas.SingleOrDefault(d => d.MaHangHoa == Guid.Parse(id));
        //        if(hangHoa == null)
        //        {
        //            return NotFound();
        //        }
        //        if(hangHoaEdit.MaHangHoa != hangHoa.MaHangHoa)
        //        {
        //            return BadRequest();
        //        }
        //        hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
        //        hangHoa.DonGia = hangHoaEdit.DonGia;
        //        return Ok();
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        //// DELETE api/<HangHoaController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    try
        //    {
        //        var hangHoa = hangHoas.SingleOrDefault(d => d.MaHangHoa == Guid.Parse(id));
        //        if (hangHoa == null)
        //        {
        //            return NotFound();
        //        }
        //        hangHoas.Remove(hangHoa);
        //        return Ok();
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
