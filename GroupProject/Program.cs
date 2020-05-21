using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.CompilerServices;
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
        

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(StringValue.TIEU_DE);
            
            while (true)
            {
                switch (ChonCheDo(StringValue.MENU_CHINH))
                {
                    case 1: // chức năng nhập 
                        switch (ChonCheDo(StringValue.MENU_NHAP))
                        {
                            case 1:
                                NhapLoaiQua();
                                break;

                            case 2:
                                NhapSanPham();
                                break;
                        }
                        break;

                    case 2:
                        // chức năng hiển thị
                        break;

                    case 3:
                        //chức năng tìm kiếm
                        break;

                    case 4:
                        //chức năng sửa thông tin
                        break;

                    case 5:
                        //chức năng xóa thông tin

                    case 6:
                        ThongKe();
                        break;
                }
            }
            
            
        }

        public static void NhapLoaiQua()
        {
            while (Thoat(StringValue.TIN_NHAN_THOAT_1))
            {
                try 
                {
                    Loai loai = new Loai();
                    Console.Write(StringValue.MA_LOAI);
                    int ma = int.Parse(Console.ReadLine());

                    Console.Write(StringValue.TEN_LOAI);
                    string ten = Console.ReadLine();

                    loai.ma = ma;
                    loai.ten = ten;
                    loai.tongSL = DemQuaTheoLoai(loai.ten);

                    if (ten != "" && ma > listLoai.Length - 1)
                        ThemLoaiSanPham(loai);
                } 
                catch 
                {
                    Console.WriteLine(StringValue.THONG_BAO_LOI);
                }

            }
        }

        public static void NhapSanPham()
        {
            while (Thoat(StringValue.TIN_NHAN_THOAT_2))
            {

                try
                {
                    // cần hàm tim kiếm theo tên loại, nếu tồn tại thì thêm, không thì hỏi người dùng có muốn tạo mới không
                    Console.Write(StringValue.LOAI);
                    string loai = Console.ReadLine();

                    Console.Write(StringValue.MA_SAN_PHAM);
                    int ma = int.Parse(Console.ReadLine());

                    Console.Write(StringValue.TEN_SAN_PHAM);
                    string ten = Console.ReadLine();

                    Console.Write(StringValue.SO_LUONG);
                    int soLuong = int.Parse(Console.ReadLine());

                    Console.Write(StringValue.KHOI_LUONG);
                    int khoiLuong = int.Parse(Console.ReadLine());

                    Console.Write(StringValue.XUAT_XU);
                    string xuatXu = Console.ReadLine();

                    Console.Write(StringValue.NGAY_NHAP);
                    string ngayNhap = Console.ReadLine();

                    Console.Write(StringValue.HAN_DUNG);
                    string ngayHetHan = Console.ReadLine();

                    Console.Write(StringValue.GIA_NHAP);
                    int giaNhap = int.Parse(Console.ReadLine());

                    Console.Write(StringValue.GIA_BAN);
                    int giaBan = int.Parse(Console.ReadLine());

                    Console.Write(StringValue.NHAP_KHAU);
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
                    Console.WriteLine(StringValue.THONG_BAO_LOI);
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

        public static int ChonCheDo(string thongBao)
        {
            Console.Write(thongBao+"\n"+StringValue.CHON_CHE_DO);
            int i = int.Parse(Console.ReadLine());
            return i;
        }

        public static void DocFile()
        {
            StringBuilder builder = new StringBuilder();
        }

        public static void GhiFile()
        {

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
