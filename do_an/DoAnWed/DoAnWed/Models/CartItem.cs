using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnWed.Models
{
    public class CartItem
    {
        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public int iMaLoai { get; set; }
        public int iMaNSX { get; set; }
        public int iSoLuong { get; set; }
        public int iDonGia { get; set; }
        
        public string sMoTa { get; set; }
        public string sHinhSP { get; set; }
        public string sHinhItems { get; set; }
        public string sChiTiet { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * iDonGia; }            
        }
        public CartItem(int masp)
        {
            DataClasses1DataContext data = new DataClasses1DataContext();
            SanPham sp = data.SanPhams.Single(n => n.MaSP == masp);
            if (sp != null)
            {
                iMaSP = masp;
                sTenSP = sp.TenSP;
                iMaLoai = int.Parse(sp.MaLoai.ToString());
                iMaNSX = int.Parse(sp.MaNSX.ToString());               
                iDonGia = int.Parse(sp.DonGia.ToString());
                //iGiaKM = int.Parse(sp.GiaKM.ToString());
                sMoTa = sp.MoTa;
                sHinhSP = sp.HinhSP;
                sHinhItems = sp.HinhSP;
                sChiTiet = sp.ChiTiet;
                iSoLuong = 1;
            }
        }
    }
}