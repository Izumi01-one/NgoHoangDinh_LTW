namespace QLSV
{
    public class Student
    {
     
        public int SoLuongSinhVien { get; set; } = 0;
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string? Email { get; set; }
        public string? SoDienThoai { get; set; }
        public string NganhHoc { get; set; }
        public double DiemTB { get; set; }
        public string TrangThai { get; set; }

        // Constructor không tham số
        public Student()
        {
            MaSV = "";
            HoTen = "";
            NgaySinh = DateTime.Now;
            GioiTinh = "";
            Email = null;
            SoDienThoai = null;
            NganhHoc = "";
            DiemTB = 0;
            TrangThai = "";
        }

        // Constructor có tham số
        public Student(
            string maSV,
            string hoTen,
            DateTime ngaySinh,
            string gioiTinh,
            string? email,
            string? soDienThoai,
            string nganhHoc,
            double diemTB,
            string trangThai)
        {
            this.MaSV = maSV;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.Email = email;
            this.SoDienThoai = soDienThoai;
            this.NganhHoc = nganhHoc;
            this.DiemTB = diemTB;
            this.TrangThai = trangThai;
        }

        // Hiển thị thông tin một sinh viên
        public void HienThi()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Mã sinh viên    : " + MaSV);
            Console.WriteLine("Họ tên          : " + HoTen);
            Console.WriteLine(
                "Ngày sinh       : " + NgaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("Giới tính       : " + GioiTinh);
            Console.WriteLine("Email           : " + Email);
            Console.WriteLine("Số điện thoại  : " + SoDienThoai);
            Console.WriteLine("Ngành học       : " + NganhHoc);
            Console.WriteLine(
                "Điểm trung bình : " + DiemTB.ToString("0.00"));
            Console.WriteLine("Trạng thái      : " + TrangThai);
        }
    }
}
