using QLSV;

namespace QLSV
{
    public class MenuManager
    {
        private StudentService studentService;
        private StudentConsoleView studentView;

        public MenuManager()
        {
            studentService = new StudentService();
            studentView = new StudentConsoleView();
        }

        public void Chay()
        {
            bool tiepTuc = true;

            while (tiepTuc)
            {
                studentView.HienThiMenu();

                string luaChon = Console.ReadLine() ?? "";

                Console.Clear();

                switch (luaChon)
                {
                    case "1":
                        ThemSinhVien();
                        break;

                    case "2":
                        studentService.HienThiDanhSach(studentService.GetDanhSach());
                        break;

                    case "3":
                        TimTheoMa();
                        break;

                    case "4":
                        TimTheoHoTen();
                        break;

                    case "5":
                        CapNhatSinhVien();
                        break;

                    case "6":
                        XoaSinhVien();
                        break;

                    case "7":
                        studentService.HienThiDanhSach(studentService.SapXepTheoHoTen());
                        break;

                    case "8":
                        studentService.HienThiDanhSach(studentService.SapXepTheoDiem());
                        break;

                    case "9":
                        studentService.HienThiDanhSach(studentService.LaySinhVienDiemTu8());
                        break;

                    case "10":
                        studentService.HienThiDanhSach(studentService.LaySinhVienDiemCaoNhat());
                        break;

                    case "11":
                        HienThiDiemTrungBinh();
                        break;

                    case "12":
                        studentService.ThongKeTheoNganh();
                        break;

                    case "13":
                        studentService.ThongKeTheoTrangThai();
                        break;

                    case "0":
                        tiepTuc = false;
                        Console.WriteLine("Đã thoát chương trình.");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }

                if (tiepTuc)
                {
                    studentView.TamDung();
                }
            }
        }

        private void ThemSinhVien()
        {
            Console.WriteLine("THÊM SINH VIÊN");
            Console.WriteLine("-----------------------");

            Student student = studentView.NhapSinhVien();

            string thongBao;

            studentService.ThemSinhVien(student,out thongBao);

            Console.WriteLine();
            Console.WriteLine(thongBao);
        }

        private void TimTheoMa()
        {
            Console.Write("Nhập mã sinh viên cần tìm: ");
            string maSV = Console.ReadLine() ?? "";

            Student? student = studentService.TimTheoMa(maSV);

            if (student == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
            }
            else
            {
                student.HienThi();
            }
        }

        private void TimTheoHoTen()
        {
            Console.Write("Nhập họ tên cần tìm: ");
            string tuKhoa = Console.ReadLine() ?? "";

            List<Student> ketQua =
                studentService.TimTheoHoTen(tuKhoa);

            studentService.HienThiDanhSach(ketQua);
        }

        private void CapNhatSinhVien()
        {
            Console.Write("Nhập mã sinh viên cần cập nhật: ");
            string maSV = Console.ReadLine() ?? "";

            Student? student = studentService.TimTheoMa(maSV);

            if (student == null)
            {
                Console.WriteLine("Sinh viên không tồn tại.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Thông tin hiện tại:");
            student.HienThi();

            Console.WriteLine();
            Console.WriteLine("Nhập thông tin mới:");

            Student sinhVienMoi = studentView.NhapSinhVien();

            string thongBao;

            studentService.CapNhatSinhVien(
                maSV,
                sinhVienMoi,
                out thongBao);

            Console.WriteLine();
            Console.WriteLine(thongBao);
        }

        private void XoaSinhVien()
        {
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string maSV = Console.ReadLine() ?? "";

            Student? student = studentService.TimTheoMa(maSV);

            if (student == null)
            {
                Console.WriteLine("Sinh viên không tồn tại.");
                return;
            }

            student.HienThi();

            Console.WriteLine();
            Console.Write("Bạn có chắc chắn muốn xóa? (Y/N): ");
            string luaChon = Console.ReadLine() ?? "";

            if (luaChon.ToUpper() == "Y")
            {
                string thongBao;

                studentService.XoaSinhVien(
                    maSV,
                    out thongBao);

                Console.WriteLine(thongBao);
            }
            else
            {
                Console.WriteLine("Đã hủy xóa sinh viên.");
            }
        }

        private void HienThiDiemTrungBinh()
        {
            if (studentService.GetDanhSach().Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên trống.");
                return;
            }

            double diemTrungBinh =
                studentService.TinhDiemTrungBinh();

            Console.WriteLine(
                "Điểm trung bình toàn bộ sinh viên: "
                + diemTrungBinh.ToString("0.00"));
        }
    }
}