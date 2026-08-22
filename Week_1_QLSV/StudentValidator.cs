using QLSV;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace QLSV
{
    //internal class StudentValidator
    //{
    //}
    public class StudentValidator
    {
        public static bool KiemTraHoTen(String hoTen)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                return false;
            }
            else return true;
        }
        public static bool KiemTraDiem(double diem)
        {
            if (diem >= 0 && diem <= 10)
            {
                return true;
            }
            else return false;
        }
        public static bool KiemTraEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return true;
            }
            try
            {
                MailAddress mail = new MailAddress(email);
                return mail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool KiemTraSinhVien(Student student, out string thongBao)
        {
            if (string.IsNullOrWhiteSpace(student.MaSV))
            {
                thongBao = "Mã sinh viên không được để trống.";
                return false;
            }

            if (!KiemTraHoTen(student.HoTen))
            {
                thongBao = "Họ tên không được để trống.";
                return false;

            }

            if (!KiemTraDiem(student.DiemTB))
            {
                thongBao = "Điểm trung bình phải từ 0 đến 10.";
                return false;
    
            }


            if (!KiemTraEmail(student.Email))
            {
                thongBao = "Email không đúng định dạng.";
                return false;
    
            }

            if (string.IsNullOrWhiteSpace(student.NganhHoc))
            {
                thongBao = "Ngành học không được để trống.";
                return false;
    
            }

            if (string.IsNullOrWhiteSpace(student.TrangThai))
            {
                thongBao = "Trạng thái không được để trống.";
                return false;
    
            }

            thongBao = "";
            return true;

        }       

    }

}