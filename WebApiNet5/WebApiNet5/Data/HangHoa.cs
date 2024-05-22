using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiNet5.Controllers;

namespace WebApiNet5.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid Mahh { get; set; }
        public string Tenhh { get; set; }
        [Required]
        [MaxLength(100)]
        public string Mota {  get; set; }
        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }
       
        public byte GiamGia {  get; set; }

        public int? MaLoai {  get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }
        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
        public HangHoa()
        {
            DonHangChiTiets = new HashSet<DonHangChiTiet>(); //Có thể dùng List hoặc HashSet sao cho
            //đảm bảo thằng này null khi chưa có để đảm bảo là có danh sách rỗng
        }
    }
}
