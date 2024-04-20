using System;
using System.Collections.Generic;

namespace data_first.Models;

public partial class Lop
{
    public int Id { get; set; }

    public string TenLop { get; set; } = null!;

    public int KhoaId { get; set; }

    public virtual Khoa Khoa { get; set; } = null!;

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
