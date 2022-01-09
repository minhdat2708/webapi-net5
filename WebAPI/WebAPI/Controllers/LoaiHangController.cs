using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LoaiHangController : ControllerBase
    {
        private readonly MyDbContext context;

        public LoaiHangController(MyDbContext context)
        {
            this.context = context;
        }
    
        [HttpGet]
        public IActionResult GetAll()
        {
            var danhSachLoai = context.LoaiHangs.ToList();
            return Ok(danhSachLoai);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = context.LoaiHangs.SingleOrDefault(l => l.MaLoai == id);
            if (loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateNew(LoaiHangVM model)
        {
            try
            {
                var loai = new LoaiHang
                {
                    TenLoai = model.TenLoai
                };
                context.Add(loai);
                context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }  
        }
        [HttpPut("{id}")]
        public IActionResult UpdateLoaiHang(int id, LoaiHangVM model)
        {
            var loai = context.LoaiHangs.SingleOrDefault(l => l.MaLoai == id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
