using System;
using System.Collections.Generic;
using System.IO;
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


    partial class Program
    {
        //Khởi tạo 2 mảng lưu sản phẩm và loại sản phẩm
        public static SanPham[] listSanPham = new SanPham[0];

        public static Loai[] listLoai = new Loai[0];

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            DocFileDanhMuc();
            DocFileSanPham();
            
            Console.WriteLine(StringValue.TIEU_DE);

            while (true)
            {
                //Mở menu chức năng
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
                        switch (ChonCheDo(StringValue.MENU_HIEN_THI))
                        {
                            case 1:
                                HienThiDanhMuc(listLoai);
                                break;
                            case 2:
                                HienThiSanPham(listSanPham);
                                break;
                        }
                        break;
                    case 3:
                        //chức năng tìm kiếm
                        switch (ChonCheDo(StringValue.MENU_TIM_KIEM))
                        {
                            case 1:
                                {
                                    Console.Write(StringValue.TEN_LOAI);
                                    string danhMuc = Console.ReadLine();
                                    int index = TimKiemDanhMuc(danhMuc);
                                    if (index >= 0)
                                    {
                                        Loai loai = listLoai[index];
                                        HienThiDanhMuc(new Loai[] { loai });
                                    }
                                    else
                                        Console.WriteLine(StringValue.KHONG_TON_TAI_2 + " " + danhMuc);
                                    break;
                                }
                            case 2:
                                {
                                    Console.Write("Mời bạn nhập tên Sản Phẩm");
                                    string sanPham = Console.ReadLine();
                                    int index2 = TimKiemSanPham(sanPham);
                                    if (index2 >= 0)
                                    {
                                        SanPham sp = listSanPham[index2];
                                        HienThiSanPham(new SanPham[] { sp });
                                    }
                                    else
                                        Console.WriteLine(StringValue.KHONG_TON_TAI_2 + " " + sanPham);
                                    break;
                                }
                        }
                        break;

                    case 4:
                        //chức năng sửa thông tin
                        switch (ChonCheDo(StringValue.MENU_SUA_THONG_TIN))
                        {
                            case 1:
                                {
                                    Console.Write(StringValue.TEN_LOAI);
                                    string danhMuc = Console.ReadLine();
                                    int index = TimKiemDanhMuc(danhMuc);
                                    if(index>=0)
                                    {
                                        SuaLoai(index);
                                    }
                                    else
                                        Console.WriteLine(StringValue.KHONG_TON_TAI_2 + " " + danhMuc);
                                    break;
                                }
                            case 2:
                                {
                                    Console.Write(StringValue.TEN_SAN_PHAM);
                                    string sanPham = Console.ReadLine();
                                    int index2 = TimKiemSanPham(sanPham);
                                    if (index2 >= 0)
                                    {
                                        SuaSanPham(index2);
                                    }
                                    else
                                        Console.WriteLine(StringValue.KHONG_TON_TAI_2 + " " + sanPham);

                                    break;
                                }
                        }
                        break;

                    case 5:
                        //chức năng xóa thông tin
                        switch (ChonCheDo(StringValue.MENU_XOA_THONG_TIN))
                        {
                            case 1:
                                {
                                    Console.Write(StringValue.TEN_LOAI);
                                    string DanhMuc = Console.ReadLine();
                                    int index = TimKiemDanhMuc(DanhMuc);
                                    if (index >= 0)
                                    {
                                        Console.Write(StringValue.THONG_BAO_XOA_DANH_MUC);
                                        string ch = Console.ReadLine();
                                        if (ch == "y")
                                        {
                                            XoaSanPhamTheoDanhMuc(DanhMuc);
                                            XoaLoai(index);
                                        }
                                    }
                                    else
                                        Console.WriteLine(StringValue.KHONG_TON_TAI_2 + " " + DanhMuc);
                                    break;
                                }
                            case 2:
                                {
                                    Console.Write(StringValue.TEN_SAN_PHAM);
                                    string SanPham = Console.ReadLine();
                                    int index2 = TimKiemSanPham(SanPham);
                                    if (index2 >= 0)
                                    {
                                        Console.Write(StringValue.THONG_BAO_XOA_SAN_PHAM);
                                        string ch = Console.ReadLine();
                                        if (ch == "y")
                                        {
                                            for (int i=0;i<listLoai.Length;i++)
                                            {
                                                if(listLoai[i].ten==listSanPham[index2].loai)
                                                {
                                                    listLoai[i].tongSL=listLoai[i].tongSL-1;
                                                }
                                            }
                                            XoaSanPham(index2);
                                        }
                                    }
                                    else
                                        Console.WriteLine(StringValue.KHONG_TON_TAI_2 + " " + SanPham);

                                    break;
                                }
                        }

                        break;

                    case 6:
                        ThongKe();
                        break;

                    default:
                        GhiFileDanhMuc();
                        GhiFileSanPham();
                        Console.WriteLine(StringValue.TAM_BIET);
                        Environment.Exit(1);
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
                    Console.Write(StringValue.TEN_LOAI);
                    string ten = Console.ReadLine();
                    ten = xuli(ten);
                    loai.ten = ten;
                    if (TimKiemDanhMuc())
                    {
                        loai.ma = listLoai.Length + 1;
                    }
                    else loai.ma = listLoai.Length;
                    loai.tongSL = DemQuaTheoLoai(loai.ten);

                    if (ten != "")
                        ThemLoaiSanPham(loai);
                    else Console.WriteLine(StringValue.THONG_BAO_LOI);
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
                    int loaiQuaIndex = TimKiemDanhMuc(loai);
                    if (loaiQuaIndex < 0)
                    {
                        if (Thoat(StringValue.KHONG_TON_TAI_1 + " " + loai + " " + StringValue.TIN_NHAN_THOAT_1))
                        {
                            Loai loaiQua = new Loai();
                            loaiQua.ten = loai;
                            if (TimKiemDanhMuc())
                                loaiQua.ma = listLoai.Length + 1;
                            else loaiQua.ma = listLoai.Length;
                            ThemLoaiSanPham(loaiQua);
                        }
                        else
                        {
                            Console.WriteLine(StringValue.THONG_BAO_LOI);
                            return;
                        }
                    }

                    int ma;
                    if (TimKiemSanPham())
                    {
                        ma = listSanPham.Length + 1;
                    }
                    else ma = listSanPham.Length;


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
                    string nk = Console.ReadLine();
                    bool laNhapKhau;
                    if (nk == "y")
                        laNhapKhau = true;
                    else laNhapKhau = false;

                    if (ten != "" &&
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
                        listLoai[TimKiemDanhMuc(loai)].tongSL += 1;
                        ThemSanPham(sanPham);
                    }
                    else Console.WriteLine(StringValue.THONG_BAO_LOI);
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

        public static bool TimKiemDanhMuc()
        {
            foreach (var i in listLoai)
            {
                if (i.ma == listLoai.Length)
                    return true;
            }
            return false;
        }

        public static bool TimKiemSanPham()
        {
            foreach (var i in listSanPham)
            {
                if (i.ma == listSanPham.Length)
                    return true;
            }
            return false;
        }

        public static int TimKiemSanPham(string SanPham)
        {
            for (int i = 0; i < listSanPham.Length; i++)
            {
                if (listSanPham[i].ten == SanPham)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int TimKiemDanhMuc(string DanhMuc)
        {
            for (int i = 0; i < listLoai.Length; i++)
            {
                if (listLoai[i].ten == DanhMuc)
                {
                    return i;
                }
            }
            return -1;

        }

        public static int DemQuaTheoLoai(string loai)
        {
            int count = 0;
            foreach (var qua in listSanPham)
            {
                if (qua.loai == loai)
                    count++;
            }
            return count;
        }

        public static bool Thoat(string thongBao)
        {
            Console.Write(thongBao + "(y/n): ");
            string thoat = Console.ReadLine();
            if (thoat == "y")
                return true;
            else return false;
        }

        public static void ThongKe()
        {
            Console.WriteLine("trong cửa hàng hiện có " + listLoai.Length + " loại quả:");
            foreach (var loai in listLoai)
            {
                Console.WriteLine("\t" + loai.ten + ": " + loai.tongSL + " sản phẩm");
                foreach (var sanPham in listSanPham)
                {
                    if (sanPham.loai == loai.ten)
                    {
                        string nk = sanPham.nhapKhau ? "nhập khẩu" : "nội địa";
                        Console.WriteLine("\t\t" + sanPham.ma + "|" +
                                        sanPham.ten + "|" +
                                        sanPham.soLuong + "|" +
                                        sanPham.ngayNhap.ToString("dd/MM/yyyy") + "|" +
                                        sanPham.ngayHetHan.ToString("dd/MM/yyyy") + "|" +
                                        sanPham.xuatSu + "|" +
                                        sanPham.giaNhap + "|" +
                                        sanPham.giaBan + "|" +
                                        sanPham.khoiLuong + "|" +
                                        nk);
                    }
                }
            }
        }

        public static int ChonCheDo(string thongBao)
        {
            try
            {
                Console.Write(thongBao + "\n" + StringValue.CHON_CHE_DO);
                int i = int.Parse(Console.ReadLine());
                return i;
            }
            catch
            {
                Console.WriteLine();
            }
            return 0;
        }

        public static void DocFileDanhMuc()
        {
            StreamReader reader;
            try
            {
                if (!File.Exists(StringValue.FILE_DANH_MUC))
                    File.Create(StringValue.FILE_DANH_MUC).Close();

                reader = new StreamReader(StringValue.FILE_DANH_MUC);
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] data = line.Split('|');
                    Loai loai = new Loai();
                    loai.ma = int.Parse(data[0]);
                    loai.ten = data[1];
                    loai.tongSL = int.Parse(data[2]);
                    ThemLoaiSanPham(loai);
                    line = reader.ReadLine();
                }
                reader.Close();
            }
            catch
            {
                Console.WriteLine(StringValue.THONG_BAO_LOI_2);
            }
        }

        public static void GhiFileDanhMuc()
        {
            StreamWriter writer;
            try
            {
                writer = new StreamWriter(StringValue.FILE_DANH_MUC);
                foreach (var dm in listLoai)
                    writer.WriteLine(dm.ma + "|" + dm.ten + "|" + dm.tongSL);
                writer.Close();
            }
            catch
            {
                Console.WriteLine(StringValue.THONG_BAO_LOI_2);
            }
        }

        public static void DocFileSanPham()
        {
            StreamReader reader;
            try
            {
                if (!File.Exists(StringValue.FILE_SAN_PHAM))
                    File.Create(StringValue.FILE_SAN_PHAM).Close();

                reader = new StreamReader(StringValue.FILE_SAN_PHAM);
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] data = line.Split('|');
                    SanPham sanPham = new SanPham();
                    sanPham.loai = data[0];
                    sanPham.ma = int.Parse(data[1]);
                    sanPham.ten = data[2];
                    sanPham.soLuong = int.Parse(data[3]);
                    sanPham.khoiLuong = int.Parse(data[4]);
                    sanPham.xuatSu = data[5];
                    sanPham.ngayNhap = DateTime.Parse(data[6]);
                    sanPham.ngayHetHan = DateTime.Parse(data[7]);
                    sanPham.giaNhap = int.Parse(data[8]);
                    sanPham.giaBan = int.Parse(data[9]);
                    sanPham.nhapKhau = bool.Parse(data[10]);
                    ThemSanPham(sanPham);
                    line = reader.ReadLine();
                }
                reader.Close();
            }
            catch
            {
                Console.WriteLine(StringValue.THONG_BAO_LOI_2);
            }
        }

        public static void GhiFileSanPham()
        {
            StreamWriter writer;
            try
            {
                writer = new StreamWriter(StringValue.FILE_SAN_PHAM);
                foreach (var i in listSanPham)
                    writer.WriteLine(i.loai + "|" +
                                     i.ma + "|" +
                                     i.ten + "|" +
                                     i.soLuong + "|" +
                                     i.khoiLuong + "|" +
                                     i.xuatSu + "|" +
                                     i.ngayNhap.ToString("dd/MM/yyyy") + "|" +
                                     i.ngayHetHan.ToString("dd/MM/yyyy") + "|" +
                                     i.giaNhap + "|" +
                                     i.giaBan + "|" +
                                     i.nhapKhau.ToString());
                writer.Close();
            }
            catch
            {
                Console.WriteLine(StringValue.THONG_BAO_LOI_2);
            }
        }

        public static void SuaLoai(int index)
        {
            Console.Write(StringValue.MA_LOAI);
            listLoai[index].ma = int.Parse(Console.ReadLine());
            Console.Write(StringValue.TEN_LOAI);
            listLoai[index].ten = xuli(Console.ReadLine());
        }

        public static void SuaSanPham(int index)
        {
            Console.Write(StringValue.MA_SAN_PHAM);
            listSanPham[index].ma = int.Parse(Console.ReadLine());
            Console.Write(StringValue.TEN_LOAI);
            listSanPham[index].ten = xuli(Console.ReadLine());
            Console.Write(StringValue.GIA_BAN);
            listSanPham[index].giaBan = int.Parse(Console.ReadLine());
            Console.Write(StringValue.GIA_NHAP);
            listSanPham[index].giaNhap = int.Parse(Console.ReadLine());
            Console.Write(StringValue.LOAI);
            listSanPham[index].loai = xuli(Console.ReadLine());
            Console.Write(StringValue.SO_LUONG);
            listSanPham[index].soLuong = int.Parse(Console.ReadLine());
            Console.Write(StringValue.TEN_LOAI);
            listSanPham[index].ngayHetHan=DateTime.Parse(Console.ReadLine());
            Console.Write(StringValue.NGAY_NHAP);
            listSanPham[index].ngayNhap=DateTime.Parse(Console.ReadLine());
            Console.Write(StringValue.NHAP_KHAU);
            //listSanPham[index].nhapKhau;
            Console.Write(StringValue.XUAT_XU);
            listSanPham[index].xuatSu = xuli(Console.ReadLine());

        }

        public static void XoaLoai(int index)
        {
            for (int i = index; i < listLoai.Length - 1; i++)
            {
                listLoai[i] = listLoai[i + 1];
            }
            Array.Resize(ref listLoai, listLoai.Length - 1);
        }

        public static void XoaSanPham(int index)
        {
            for (int i = index; i < listSanPham.Length - 1; i++)
            {
                listSanPham[i] = listSanPham[i + 1];
            }
            Array.Resize(ref listSanPham, listLoai.Length - 1);
            

        }

        public static void XoaSanPhamTheoDanhMuc(string DanhMuc)
        {
            for(int i=0;i<listSanPham.Length;i++)
            {
                if(listSanPham[i].loai==DanhMuc)
                {
                    XoaSanPham(i);
                }    
            }    
        }

        public static string xuli(string chuoi)
        {
            chuoi = chuoi.Trim().ToLower();
            while (chuoi.Contains("  "))
            {
                chuoi = chuoi.Replace("  ", " ");
            }
            return chuoi;
        }

        public static void HienThiDanhMuc(Loai[] l)
        {
            Console.WriteLine(StringValue.LOAI);
            foreach (var i in l)
                Console.WriteLine(i.ma + "|" + i.ten + "|" + i.tongSL);
        }

        public static void HienThiSanPham(SanPham[] sp)
        {
            Console.WriteLine(StringValue.SP);
            foreach (var i in sp)
                Console.WriteLine(i.loai + "|" +
                                 i.ma + "|" +
                                 i.ten + "|" +
                                 i.soLuong + "|" +
                                 i.khoiLuong + "|" +
                                 i.xuatSu + "|" +
                                 i.ngayNhap.ToString("dd/MM/yyyy") + "|" +
                                 i.ngayHetHan.ToString("dd/MM/yyyy") + "|" +
                                 i.giaNhap + "|" +
                                 i.giaBan + "|" +
                                 i.nhapKhau.ToString());
        }
    }
}