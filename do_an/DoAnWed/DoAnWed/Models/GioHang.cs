using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnWed.Models
{
    public class GioHang
    {
        public List<CartItem> lst;
        public GioHang()
        {
            lst = new List<CartItem>();
        }
        public GioHang(List<CartItem> lstGH)
        {
            lst = lstGH;
        }
        public int soMatHang()
        {
            return lst.Count;

        }
        public int tongSoMatHang()
        {
            if (lst == null)
                return 0;
            else
                return lst.Sum(s => s.iSoLuong);
        }
        public double thanhTien()
        {
            return lst.Sum(s => s.ThanhTien);
        }
        public int themSP(int iMaSP)
        {
            CartItem sanpham = lst.Find(n => n.iMaSP == iMaSP);
            if (sanpham == null) //chua co
            {
                CartItem sach = new CartItem(iMaSP);
                if (sach == null)
                    return -1;
                lst.Add(sach);
            }
            else
                sanpham.iSoLuong++;
            return 1;
        }
    }
}