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
        //Khởi tạo 2 mảng lưu sản phẩm và loại sản phẩm
        static SanPham[] listSanPham = new SanPham[0];
        static Loai[] listLoai = new Loai[0];
        

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
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
                        break;

                    case 3:
                        //chức năng tìm kiếm
                        switch(ChonCheDo(StringValue.MENU_TIM_KIEM))
                        {
                            case 1:
                                {
                                    Console.Write("Mời bạn nhập tên loại Sản Phẩm");
                                    string DanhMuc = Console.ReadLine();
                                    if(TimKiemDanhMuc(xuli(DanhMuc)) !=-1)
                                    {
                                        Console.WriteLine("Loại sản phẩm muốn tìm là:");
                                        //hiển thị thông tin
                                    }    
                                    break;
                                }
                            case 2:
                                {
                                    Console.Write("Mời bạn nhập tên Sản Phẩm");
                                    string DanhMuc = Console.ReadLine();
                                    if (TimKiemSanPham(xuli(DanhMuc))!=-1)
                                    {
                                        Console.WriteLine("Loại sản phẩm muốn tìm là:");
                                        //hiển thị thông tin
                                    }
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

                                    break;
                                }
                            case 2:
                                {
                                    break;
                                }
                        }
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
                    ten = xuli(ten);
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
                    int loaiQuaIndex = TimKiemDanhMuc(loai);
                    if (loaiQuaIndex < 0)
                    {
                        if (Thoat(StringValue.KHONG_TON_TAI_1 + " " + loai + " " + StringValue.TIN_NHAN_THOAT_1))
                        {
                            Array.Resize(ref listLoai, listLoai.Length + 1);
                            listLoai[listLoai.Length - 1].ten = loai;
                            if (TimKiemDanhMuc())
                                listLoai[listLoai.Length - 1].ma = listLoai.Length+1;
                            else listLoai[listLoai.Length - 1].ma = listLoai.Length;
                        } else
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
                        listLoai[listLoai.Length-1].tongSL += 1;
                        ThemSanPham(sanPham);
                        
                    }
            }
                catch
            {
                Console.WriteLine(StringValue.THONG_BAO_LOI);
            }

        }
        }
        /// <summary>
        /// Chèn Sản phẩm vừa thêm vào cuối mảng lưu sản phẩm
        /// </summary>
        /// <param name="sanPham"></param>
        public static void ThemSanPham(SanPham sanPham)
        {
            Array.Resize(ref listSanPham, listSanPham.Length + 1);
            listSanPham[listSanPham.Length - 1] = sanPham;
        }
        /// <summary>
        /// Chèn Loại vừa thêm vào cuối mảng lưu Loại
        /// </summary>
        /// <param name="loai"></param>
        public static void ThemLoaiSanPham(Loai loai)
        {
            Array.Resize(ref listLoai, listLoai.Length + 1);
            listLoai[listLoai.Length - 1] = loai;
        }
        /// <summary>
        /// Đếm quả theo loại trong listSanPham
        /// </summary>
        /// <param name="loai">Loại quả cần đếm</param>
        /// <returns></returns>
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
            Console.Write(thongBao + "(y/n): ");
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

        }

        static bool TimKiemDanhMuc()
        {
            foreach (var i in listLoai)
            {
                if (i.ma == listLoai.Length)
                    return true;
            }
            return false;
        }
        static bool TimKiemSanPham()
        {
            foreach(var i in listSanPham)
            {
                if (i.ma == listSanPham.Length)
                    return true;
            }
            return false;
        }
        public static void DocFile()
        {
            StringBuilder builder = new StringBuilder();
        }

        public static void GhiFile()
        {

        }
        /// <summary>
        /// Trả về vị trí Sản phẩm muốn tìm
        /// </summary>
        /// <param name="danhmuc">Tên sản phẩm người dùng muốn tìm</param>
        /// <returns></returns>
        static int TimKiemSanPham(string SanPham)
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
        /// <summary>
        /// Trả về vị trí Danh mục muốn tìm
        /// </summary>
        /// <param name="DanhMuc">Tên Danh mục người dùng muốn tìm</param>
        /// <returns></returns>
        static int TimKiemDanhMuc(string DanhMuc)
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
        /// <summary>
        /// Sửa Danh mục
        /// </summary>
        /// <param name="index">Vị trí Danh mục tìm được</param>
        public static void SuaLoai(int index)
        {
            Console.Write(StringValue.MA_LOAI);
            listLoai[index].ma = int.Parse(Console.ReadLine());
            Console.Write(StringValue.TEN_LOAI);
            listLoai[index].ten = xuli( Console.ReadLine());
            //Console.Write(StringValue.s);
            //-------:))-------
            //listLoai[index].;
        }
        /// <summary>
        /// Sửa Sản Phẩm (Chưa xong)
        /// </summary>
        /// <param name="index">Vị trí sản phẩm tìm thấy</param>
        public static void SuaSanPham(int index)
        {
            Console.Write(StringValue.MA_SAN_PHAM);
            listSanPham[index].ma = int.Parse(Console.ReadLine());
            Console.Write(StringValue.TEN_LOAI);
            listSanPham[index].ten = xuli(Console.ReadLine());
            Console.Write(StringValue.GIA_BAN);
            listSanPham[index].giaBan= int.Parse(Console.ReadLine());
            Console.Write(StringValue.GIA_NHAP);
            listSanPham[index].giaNhap= int.Parse(Console.ReadLine());
            Console.Write(StringValue.LOAI);
            listSanPham[index].loai= xuli(Console.ReadLine());
            Console.Write(StringValue.SO_LUONG);
            listSanPham[index].soLuong= int.Parse(Console.ReadLine();
            Console.Write(StringValue.TEN_LOAI);
            //listSanPham[index].ngayHetHan=Console.ReadLine().ToString("dd/MM/yyyy");
            Console.Write(StringValue.NGAY_NHAP);
            //listSanPham[index].ngayNhap;
            Console.Write(StringValue.NHAP_KHAU);
            //listSanPham[index].nhapKhau;
            Console.Write(StringValue.XUAT_XU);
            listSanPham[index].xuatSu= xuli(Console.ReadLine());

        }
        /// <summary>
        /// Hàm xứ lý chuỗi. Các bạn bổ sung thêm nhé :)
        /// </summary>
        /// <param name="chuoi">Chuỗi ban đầu</param>
        /// <returns></returns>
        public static string xuli(string chuoi)
        {
            chuoi = chuoi.Trim().ToLower();
            while(chuoi.Contains("  "))
            {
                chuoi = chuoi.Replace("  ", " ");
            }    
            return chuoi;
        }
    }
}
