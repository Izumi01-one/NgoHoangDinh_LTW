using QLSV;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace QLSV
{
    public class StudentService
    {
        private List<Student> danhSach;

        public StudentService()
        {
            danhSach = new List<Student>();
        }

        public List<Student> GetDanhSach()
        {
            return danhSach;
        }

        // 1. Thêm sinh viên
        public bool ThemSinhVien(Student student, out string thongBao)
        {
            if (!StudentValidator.KiemTraSinhVien(student, out thongBao))
            {
                return false;
            }

            if (TimTheoMa(student.MaSV) != null)
            {
                thongBao = "Mã sinh viên đã tồn tại.";
                return false;
            }

            danhSach.Add(student);
            student.SoLuongSinhVien++;

            thongBao = "Thêm sinh viên thành công.";
            return true;
        }

        // 2. Hiển thị danh sách
        public void HienThiDanhSach(List<Student> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên trống.");
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Sinh viên thứ " + (i + 1));
                list[i].HienThi();
            }

            Console.WriteLine();
            Console.WriteLine("Tổng số sinh viên: " + list.Count);
        }

        // 3. Tìm sinh viên theo mã
        public Student? TimTheoMa(string maSV)
        {
            for (int i = 0; i < danhSach.Count; i++)
            {
                if (danhSach[i].MaSV == maSV)
                {
                    return danhSach[i];
                }
            }

            return null;
        }

        // 4. Tìm gần đúng theo họ tên
        public List<Student> TimTheoHoTen(string tuKhoa)
        {
            List<Student> ketQua = new List<Student>();

            for (int i = 0; i < danhSach.Count; i++)
            {
                if (danhSach[i].HoTen.ToLower().Contains(tuKhoa.ToLower()))
                {
                    ketQua.Add(danhSach[i]);
                }
            }

            return ketQua;
        }

        // 5. Cập nhật sinh viên
        public bool CapNhatSinhVien( string maCanSua, Student sinhVienMoi, out string thongBao)
        {
            Student? sinhVienCu = TimTheoMa(maCanSua);

            if (sinhVienCu == null)
            {
                thongBao = "Sinh viên không tồn tại.";
                return false;
            }

            if (!StudentValidator.KiemTraSinhVien(sinhVienMoi, out thongBao))
            {
                return false;
            }

            // Nếu đổi mã thì kiểm tra mã mới có trùng không
            if (!(maCanSua == sinhVienMoi.MaSV))
            {
                Student? sinhVienTrung = TimTheoMa(sinhVienMoi.MaSV);

                if (sinhVienTrung != null)
                {
                    thongBao = "Mã sinh viên mới đã tồn tại.";
                    return false;
                }
            }

            sinhVienCu.MaSV = sinhVienMoi.MaSV;
            sinhVienCu.HoTen = sinhVienMoi.HoTen;
            sinhVienCu.NgaySinh = sinhVienMoi.NgaySinh;
            sinhVienCu.GioiTinh = sinhVienMoi.GioiTinh;
            sinhVienCu.Email = sinhVienMoi.Email;
            sinhVienCu.SoDienThoai = sinhVienMoi.SoDienThoai;
            sinhVienCu.NganhHoc = sinhVienMoi.NganhHoc;
            sinhVienCu.DiemTB = sinhVienMoi.DiemTB;
            sinhVienCu.TrangThai = sinhVienMoi.TrangThai;

            thongBao = "Cập nhật sinh viên thành công.";
            return true;
        }

        // 6. Xóa sinh viên
        public bool XoaSinhVien(string maSV, out string thongBao)
        {
            Student? student = TimTheoMa(maSV);

            if (student == null)
            {
                thongBao = "Sinh viên không tồn tại.";
                return false;
            }

            danhSach.Remove(student);
            student.SoLuongSinhVien--;

            thongBao = "Xóa sinh viên thành công.";
            return true;
        }

        // 7. Sắp xếp theo họ tên
        public List<Student> SapXepTheoHoTen()
        {
            List<Student> ketQua = new List<Student>(danhSach);

            for (int i = 0; i < ketQua.Count - 1; i++)
            {
                for (int j = i + 1; j < ketQua.Count; j++)
                {
                    string ten1 = ketQua[i].HoTen.ToLower();
                    string ten2 = ketQua[j].HoTen.ToLower();

                    if (ten1.CompareTo(ten2) > 0)
                    {
                        Student temp = ketQua[i];
                        ketQua[i] = ketQua[j];
                        ketQua[j] = temp;
                    }
                }
            }

            return ketQua;
        }

        // 8. Sắp xếp điểm trung bình giảm dần
        public List<Student> SapXepTheoDiem()
        {
            List<Student> ketQua = new List<Student>(danhSach);

            for (int i = 0; i < ketQua.Count - 1; i++)
            {
                for (int j = i + 1; j < ketQua.Count; j++)
                {
                    if (ketQua[i].DiemTB < ketQua[j].DiemTB)
                    {
                        Student temp = ketQua[i];
                        ketQua[i] = ketQua[j];
                        ketQua[j] = temp;
                    }
                }
            }

            return ketQua;
        }

        // 9. Sinh viên có điểm từ 8 trở lên
        public List<Student> LaySinhVienDiemTu8()
        {
            List<Student> ketQua = new List<Student>();

            for (int i = 0; i < danhSach.Count; i++)
            {
                if (danhSach[i].DiemTB >= 8)
                {
                    ketQua.Add(danhSach[i]);
                }
            }

            return ketQua;
        }

        // 10. Sinh viên có điểm cao nhất
        public List<Student> LaySinhVienDiemCaoNhat()
        {
            List<Student> ketQua = new List<Student>();

            if (danhSach.Count == 0)
            {
                return ketQua;
            }

            double diemCaoNhat = danhSach[0].DiemTB;

            for (int i = 1; i < danhSach.Count; i++)
            {
                if (danhSach[i].DiemTB > diemCaoNhat)
                {
                    diemCaoNhat = danhSach[i].DiemTB;
                }
            }

            for (int i = 0; i < danhSach.Count; i++)
            {
                if (danhSach[i].DiemTB == diemCaoNhat)
                {
                    ketQua.Add(danhSach[i]);
                }
            }

            return ketQua;
        }

        // 11. Tính điểm trung bình toàn bộ sinh viên
        public double TinhDiemTrungBinh()
        {
            if (danhSach.Count == 0)
            {
                return 0;
            }

            double tongDiem = 0;

            for (int i = 0; i < danhSach.Count; i++)
            {
                tongDiem = tongDiem + danhSach[i].DiemTB;
            }

            return tongDiem / danhSach.Count;
        }

        // 12. Thống kê sinh viên theo ngành
        public void ThongKeTheoNganh()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên trống.");
                return;
            }

            List<string> nganhDaKiemTra = new List<string>();

            Console.WriteLine("THỐNG KÊ THEO NGÀNH");
            Console.WriteLine("-----------------------------");

            for (int i = 0; i < danhSach.Count; i++)
            {
                string nganh = danhSach[i].NganhHoc;
                bool daKiemTra = false;

                // Kiểm tra ngành này đã được thống kê chưa
                for (int j = 0; j < nganhDaKiemTra.Count; j++)
                {
                    if (nganhDaKiemTra[j].ToLower() == nganh.ToLower())
                    {
                        daKiemTra = true;
                        break;
                    }
                }

                // Nếu chưa thống kê thì đếm số sinh viên
                if (daKiemTra == false)
                {
                    int soLuong = 0;

                    for (int j = 0; j < danhSach.Count; j++)
                    {
                        if (danhSach[j].NganhHoc.ToLower() == nganh.ToLower())
                        {
                            soLuong++;
                        }
                    }

                    Console.WriteLine(nganh + ": " + soLuong + " sinh viên");

                    // Đánh dấu ngành đã được thống kê
                    nganhDaKiemTra.Add(nganh);
                }
            }
        }

        // 13. Thống kê sinh viên theo trạng thái
        public void ThongKeTheoTrangThai()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên trống.");
                return;
            }

            List<string> trangThaiDaKiemTra = new List<string>();

            Console.WriteLine("THỐNG KÊ THEO TRẠNG THÁI");
            Console.WriteLine("-----------------------------");

            for (int i = 0; i < danhSach.Count; i++)
            {
                string trangThai = danhSach[i].TrangThai;
                bool daKiemTra = false;

                // Kiểm tra trạng thái đã được thống kê chưa
                for (int j = 0; j < trangThaiDaKiemTra.Count; j++)
                {
                    if (trangThaiDaKiemTra[j].ToLower()
                        == trangThai.ToLower())
                    {
                        daKiemTra = true;
                        break;
                    }
                }

                // Nếu chưa thống kê thì tiến hành đếm
                if (daKiemTra == false)
                {
                    int soLuong = 0;

                    for (int j = 0; j < danhSach.Count; j++)
                    {
                        if (danhSach[j].TrangThai.ToLower()
                            == trangThai.ToLower())
                        {
                            soLuong++;
                        }
                    }

                    Console.WriteLine(
                        trangThai + ": " + soLuong + " sinh viên");

                    // Đánh dấu trạng thái đã được thống kê
                    trangThaiDaKiemTra.Add(trangThai);
                }
            }
        }
    }
}
