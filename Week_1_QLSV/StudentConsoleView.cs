using QLSV;
using System.Globalization;

namespace QLSV
{
    public class StudentConsoleView
    {
        public void HienThiMenu()
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("        QUẢN LÝ SINH VIÊN");
            Console.WriteLine("======================================");
            Console.WriteLine("1.  Thêm sinh viên");
            Console.WriteLine("2.  Hiển thị danh sách");
            Console.WriteLine("3.  Tìm sinh viên theo mã");
            Console.WriteLine("4.  Tìm gần đúng theo họ tên");
            Console.WriteLine("5.  Cập nhật sinh viên");
            Console.WriteLine("6.  Xóa sinh viên");
            Console.WriteLine("7.  Sắp xếp theo họ tên");
            Console.WriteLine("8.  Sắp xếp theo điểm trung bình");
            Console.WriteLine("9.  Sinh viên có điểm từ 8 trở lên");
            Console.WriteLine("10. Sinh viên có điểm cao nhất");
            Console.WriteLine("11. Tính điểm trung bình toàn bộ");
            Console.WriteLine("12. Thống kê theo ngành");
            Console.WriteLine("13. Thống kê theo trạng thái");
            Console.WriteLine("0.  Thoát");
            Console.WriteLine("======================================");
            Console.Write("Nhập lựa chọn: ");
        }

        public Student NhapSinhVien()
        {
            Student student = new Student();

            Console.Write("Mã sinh viên: ");
            student.MaSV = Console.ReadLine() ?? "";

            Console.Write("Họ tên: ");
            student.HoTen = Console.ReadLine() ?? "";

            student.NgaySinh = NhapNgaySinh();

            Console.Write("Giới tính: ");
            student.GioiTinh = Console.ReadLine() ?? "";

            student.Email = NhapEmail();

            Console.Write("Số điện thoại: ");
            student.SoDienThoai = Console.ReadLine();

            Console.Write("Ngành học: ");
            student.NganhHoc = Console.ReadLine() ?? "";

            student.DiemTB = NhapDiem();

            Console.Write("Trạng thái học tập: ");
            student.TrangThai = Console.ReadLine() ?? "";

            return student;
        }

        public DateTime NhapNgaySinh()
        {
            while (true)
            {
                Console.Write("Ngày sinh (dd/MM/yyyy): ");
                string chuoiNgay = Console.ReadLine() ?? "";

                DateTime ngaySinh;

                bool hopLe = DateTime.TryParseExact(
                    chuoiNgay,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out ngaySinh);

                if (hopLe && ngaySinh <= DateTime.Now)
                {
                    return ngaySinh;
                }

                Console.WriteLine("Ngày sinh không hợp lệ.");
            }
        }

        public double NhapDiem()
        {
            while (true)
            {
                Console.Write("Điểm trung bình: ");
                string chuoiDiem = Console.ReadLine() ?? "";

                // Cho phép nhập cả 8.5 và 8,5
                chuoiDiem = chuoiDiem.Replace(',', '.');

                double diem;

                bool hopLe = double.TryParse(
                    chuoiDiem,
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out diem);

                if (hopLe && diem >= 0 && diem <= 10)
                {
                    return diem;
                }

                Console.WriteLine(
                    "Điểm trung bình phải từ 0 đến 10.");
            }
        }

        public string? NhapEmail()
        {
            while (true)
            {
                Console.Write("Email (có thể để trống): ");
                string? email = Console.ReadLine();

                if (StudentValidator.KiemTraEmail(email))
                {
                    return email;
                }

                Console.WriteLine("Email không đúng định dạng.");
            }
        }

        public void TamDung()
        {
            Console.WriteLine();
            Console.Write("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }
    }
}