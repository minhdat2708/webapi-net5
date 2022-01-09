using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class LoaiHangVM
    {
        [Required]
        [MaxLength(100)]
        public string TenLoai { get; set; }
    }
}
