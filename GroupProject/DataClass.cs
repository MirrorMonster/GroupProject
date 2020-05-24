using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    partial class Program
    {
        public struct Loai
        {
            public string ten;
            public int ma;
            public int tongSL;
        }

        public struct SanPham
        {
            public int ma; 
            public string ten; 
            public int soLuong;  
            public DateTime ngayNhap;
            public DateTime ngayHetHan;
            public string xuatSu; 
            public int giaNhap; 
            public int giaBan;
            public int khoiLuong; 
            public bool nhapKhau;
            public string loai;
        }
    }
}
