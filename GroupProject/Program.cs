using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GroupProject
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


    class Program
    {
        static SanPham[] listSanPham = new SanPham[0];
        static Loai[] listLoai = new Loai[0];
        static string tinNhan1 = "có gì đó sai sai, dữ liệu bạn vừa nhập sẽ không được lưu";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            NhapLoaiQua();
            NhapSanPham();
            ThongKe();
            Console.ReadKey();
            
        }

        public static void NhapLoaiQua()
        {
            while (Thoat("bạn thêm loại quả mới? "))
            {
                try 
                {
                    Loai loai = new Loai();
                    Console.Write("mã: ");
                    int ma = int.Parse(Console.ReadLine());

                    Console.Write("tên: ");
                    string ten = Console.ReadLine();

                    loai.ma = ma;
                    loai.ten = ten;
                    loai.tongSL = DemQuaTheoLoai(loai.ten);

                    if (ten != "" && ma > listLoai.Length - 1)
                        ThemLoaiSanPham(loai);
                } 
                catch 
                {
                    Console.WriteLine(tinNhan1);
                }

            }
        }

        public static void NhapSanPham()
        {
            while (Thoat("bạn muốn thêm sản phấm mới?"))
            {

                try
                {
                    // cần hàm tim kiếm theo tên loại, nếu tồn tại thì thêm, không thì hỏi người dùng có muốn tạo mới không
                    Console.Write("Loại: ");
                    string loai = Console.ReadLine();

                    Console.Write("mã sản phẩm: ");
                    int ma = int.Parse(Console.ReadLine());

                    Console.Write("tên sản phẩm: ");
                    string ten = Console.ReadLine();

                    Console.Write("số lượng: ");
                    int soLuong = int.Parse(Console.ReadLine());

                    Console.Write("khối lượng mỗi sản phẩm: ");
                    int khoiLuong = int.Parse(Console.ReadLine());

                    Console.Write("xuất xứ: ");
                    string xuatXu = Console.ReadLine();

                    Console.Write("ngày nhập: ");
                    string ngayNhap = Console.ReadLine();

                    Console.Write("hạn sử dụng: ");
                    string ngayHetHan = Console.ReadLine();

                    Console.Write("giá nhập: ");
                    int giaNhap = int.Parse(Console.ReadLine());

                    Console.Write("giá bán: ");
                    int giaBan = int.Parse(Console.ReadLine());

                    Console.Write("là hàng nhập khẩu: ");
                    bool laNhapKhau = bool.Parse(Console.ReadLine());

                    if (ma > listSanPham.Length &&
                        ten != "" &&
                        soLuong > 0 &&
                        khoiLuong > 0 &&
                        xuatXu != "" &&
                        ngayNhap != "" &&
                        ngayHetHan != "" &&
                        giaNhap >= 0 &&
                        giaBan >= 0)
                    {
                        SanPham sanPham = new SanPham();
                        sanPham.ma = ma;
                        sanPham.ten = ten;
                        sanPham.ngayNhap = DateTime.Parse(ngayNhap);
                        sanPham.ngayHetHan = DateTime.Parse(ngayHetHan);
                        sanPham.soLuong = soLuong;
                        sanPham.xuatSu = xuatXu;
                        sanPham.giaNhap = giaNhap;
                        sanPham.giaBan = giaBan;
                        sanPham.khoiLuong = khoiLuong;
                        sanPham.nhapKhau = laNhapKhau;
                        sanPham.loai = loai;
                        //cần hàm tìm kiếm theo tên loại sau đó sẽ cập nhật số lượng sản phẩm trong loại đó
                        ThemSanPham(sanPham);
                    }
                }
                catch
                {
                    Console.WriteLine(tinNhan1);
                }

            }
        }

        public static void ThemSanPham(SanPham sanPham)
        {
            Array.Resize(ref listSanPham, listSanPham.Length + 1);
            listSanPham[listSanPham.Length - 1] = sanPham;
        }

        public static void ThemLoaiSanPham(Loai loai)
        {
            Array.Resize(ref listLoai, listLoai.Length + 1);
            listLoai[listLoai.Length - 1] = loai;
        }

        public static int DemQuaTheoLoai(string loai)
        {
            int count = 0;
            foreach(var qua in listSanPham)
            {
                if (qua.loai == loai)
                    count++;
            }
            return count;
        }

        public static bool Thoat(string thongBao)
        {
            Console.Write(thongBao+"(y/n): ");
            string thoat = Console.ReadLine();
            if (thoat == "y")
                return true;
            else return false;
        }

        public static void ThongKe()
        {
            Console.WriteLine("trong cửa hàng hiện có " + listLoai.Length + " loại quả:");
            foreach(var loai in listLoai)
            {
                    Console.WriteLine("\t" + loai.ten + ": " + loai.tongSL +" sản phẩm");
                    foreach(var sanPham in listSanPham)
                    {
                        if (sanPham.loai == loai.ten)
                        {
                            string nk = sanPham.nhapKhau ? "nhập khẩu" : "nội địa";
                            Console.WriteLine("\t\t" + sanPham.ma + "\t" +
                                            sanPham.ten + "\t" +
                                            sanPham.soLuong + "\t" +
                                            sanPham.ngayNhap.ToString("dd/mm/yyyy") + "\t" +
                                            sanPham.ngayHetHan.ToString("dd/mm/yyyy") + "\t" +
                                            sanPham.xuatSu + "\t" +
                                            sanPham.giaNhap + "\t" +
                                            sanPham.giaBan + "\t" +
                                            sanPham.khoiLuong + "\t" +
                                            nk);
                        }
                    }
            }
        }

        static void TimKiem(int ma)
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
