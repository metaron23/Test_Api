using System.ComponentModel.DataAnnotations;

namespace Test_Api.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]
        public string? TenLoai { get; set; }
    }

    public class LoaiModelWithId : LoaiModel
    {
        [Key]
        public int MaLoai { get; set; }
    }
}
