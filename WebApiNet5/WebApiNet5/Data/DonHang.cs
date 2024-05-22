using System;
using System.Collections;
using System.Collections.Generic;
using WebApiNet5.Controllers;

namespace WebApiNet5.Data
{
    public enum TinhTrangDonDatHang 
    {
        New = 0, Payment = 1,Complete = 2,Cancel = -1
    }
    public class DonHang
    {
        public Guid MaDh {  get; set; }
        public DateTime NgayDat { get; set; }

        public DateTime? NgayGiao {  get; set; }
        public TinhTrangDonDatHang TinhTrangDonHang {  get; set; }
        public string NguoiNhan {  get; set; }
        public string DiaChi {  get; set; }
        public int SoDienThoai {  get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiets {  get; set; }

        public DonHang()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }
    }
}
