using data_first.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

var context = new DataFirstContext();
var students = context.SinhViens
    .Where(s => s.LopId == 1 && s.Tuoi >= 18 && s.Tuoi <= 20)
    .ToList();
Console.WriteLine("list cac sinh vien");
foreach (var student in students)
{
    Console.WriteLine($"Id: {student.Id}, HoTen: {student.HoTen}, Tuoi: {student.Tuoi}, Lop: {student.LopId}");
}