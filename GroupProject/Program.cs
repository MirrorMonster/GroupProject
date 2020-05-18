using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GroupProject
{
    class Program
    {
        
        static void Main(string[] args)
        {
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
