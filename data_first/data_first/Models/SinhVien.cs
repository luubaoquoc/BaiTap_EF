using System;
using System.Collections.Generic;

namespace data_first.Models;

public partial class SinhVien
{
    public int Id { get; set; }

    public string HoTen { get; set; } = null!;

    public int? Tuoi { get; set; }

    public int LopId { get; set; }

    public virtual Lop Lop { get; set; } = null!;
}
