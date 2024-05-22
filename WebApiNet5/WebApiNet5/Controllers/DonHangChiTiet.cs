using System;
using WebApiNet5.Data;

namespace WebApiNet5.Controllers
{
    public class DonHangChiTiet
    {
        public Guid MaHh {  get; set; }
        public Guid MaDh { get; set; }
        public int SoLuong {  get; set; }
        public double DonGia { get; set; }
        public byte GiamGia {  get; set; }
        //reletionship
        public DonHang DonHang { get; set; }

        public HangHoa HangHoa { get; set; }


    }
}
