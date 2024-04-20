using code_first.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SinhVienConText>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));
var app = builder.Build();

Console.WriteLine("list cac sinh vien");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

SinhVienConText context = new SinhVienConText();
var students = context.SinhViens
    .Where(s => s.LopId == 9 && s.Tuoi >= 18 && s.Tuoi <= 20)
    .ToList();
Console.WriteLine("list cac sinh vien");
foreach (var student in students)
{
    Console.WriteLine($"Id: {student.Id}, HoTen: {student.HoTen}, Tuoi: {student.Tuoi}, Lop: {student.Lop.TenLop}");
}

