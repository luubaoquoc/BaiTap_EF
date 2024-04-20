namespace code_first.Models
{
    public class SinhVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public int LopId { get; set; }
        public Lop Lop { get; set; }
    }
}

