using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IKategorilerDal,EfKategorilerDal>();
builder.Services.AddScoped<IKategorilerService, KategorilerManager>();
builder.Services.AddScoped<IlanlarDal, EfIlanlarDal>();
builder.Services.AddScoped<IlanlarService, IlanlarManager>();
builder.Services.AddScoped<IUrunlerDal, EfUrunlerDal>();
builder.Services.AddScoped<IUrunlerService,UrunlerManager>();

builder.Services.AddCors(opt => {
    opt.AddPolicy("ikincim", opts =>
    {
        opts.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("ikincim");
app.UseAuthorization();

app.MapControllers();

app.Run();
