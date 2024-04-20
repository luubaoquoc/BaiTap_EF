namespace code_first.Models
{
    public class Khoa
    {
        public int Id { get; set; }
        public string TenKhoa { get; set; }
        public List<Lop> Lops { get; set; } = new List<Lop>();
    }
}
