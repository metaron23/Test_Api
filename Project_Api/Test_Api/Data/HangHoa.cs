﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Api.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid MaHh { get; set; }

        [Required]
        [MaxLength(100)]
        public string? TenHh { get; set; }

        public string? Mota { get; set; }

        [Range(0, Double.MaxValue)]
        public double DonGia { get; set; }

        public byte GiamGia { get; set; }

        public int? MaLoai { get; set; }

        public Loai? Loai { get; set; }

        public ICollection<DonHangChiTiet>? DonHangChiTiets { get; set; }
    }
}
