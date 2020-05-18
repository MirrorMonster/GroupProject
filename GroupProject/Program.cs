using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GroupProject
{

    struct Loai
    {
        string ten;
        int ma;
        int tongSL;
    }

    struct HoaQua
    {
        int ma;
        string ten;
        int soLuong;
        DateTime ngayNhap;
        DateTime ngayHetHan;
        string xuatSu;
        int giaNhap;
        int giaBan;
        int khoiLuong;
        bool nhapKhau;
        string loai;
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
        }
        static void timkiem()
        {
            Console.WriteLine("Nhập loại sản phẩm muốn tìm:");
            string loai = Console.ReadLine();
            loai = loai.Trim().ToLower();
            while (loai.Contains("  "))
            {
                loai = loai.Replace("  ", " ");
            }    
            
        }
    }
}
