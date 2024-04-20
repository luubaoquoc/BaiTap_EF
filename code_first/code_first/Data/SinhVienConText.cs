using code_first.Models;
using Microsoft.EntityFrameworkCore;

namespace code_first.Data

{
    public class SinhVienConText : DbContext
    {
        public SinhVienConText(DbContextOptions<SinhVienConText> options)
        : base(options)
        {
        }

        public SinhVienConText() { }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<Khoa> Khoas { get; set; }
    }
}
