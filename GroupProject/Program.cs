using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GroupProject
{

    public struct Loai
    {
        string ten;
        int ma;
        int tongSL;
    }

    public struct HoaQua
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


    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
        }

        public static void NhapHoaQua()
        {
            while (true)
            {
                Console.Write("mã sản phẩm: ");
                int ma = int.Parse(Console.ReadLine());

                Console.Write("tên sản phẩm: ");
                string ten = Console.ReadLine();

                Console.Write("ngày nhập: ");
                DateTime ngayNhap = DateTime.Parse(Console.ReadLine());

                Console.Write("hạn sử dụng: ");
                DateTime ngayHetHan = DateTime.Parse(Console.ReadLine());

                Console.Write("số lượng: ");
                int soLuong = int.Parse(Console.ReadLine());

                Console.Write("xuất xứ:");
                string xuatXu = Console.ReadLine();

                Console.Write("giá nhập: ");
                int giaNhap = int.Parse(Console.ReadLine());

                Console.Write("giá bán: ");
                int giaBan = int.Parse(Console.ReadLine());

                Console.Write("khối lượng mỗi sản phẩm: ");
                int khoiLuong = int.Parse(Console.ReadLine());

                Console.Write("là hàng nhập khẩu: ");
                bool laNhapKhau = bool.Parse(Console.ReadLine());

                Console.Write("Loại: ");
                string loai = Console.ReadLine();

                HoaQua hoaqua = new HoaQua();
                hoaqua.ma = ma;
                hoaqua.ten = ten;
                hoaqua.ngayNhap = ngayNhap;
                hoaqua.ngayHetHan = ngayHetHan;
                hoaqua.soLuong = soLuong;
            }
        }

        public static void ThongKe()
        {
            Console.WriteLine("Có {0} loại quả trong siêu thị." + listLoai.Count());
            
            
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
