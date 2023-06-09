using CSharp5_WebAPI.Data;
using CSharp5_WebAPI.IServices;
using CSharp5_WebAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CS5_DbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
});
builder.Services.AddControllers();
builder.Services.AddTransient<INationalServices, NationalServices>();
builder.Services.AddTransient<IVoucherServies, VoucherServies>();
builder.Services.AddTransient<IRoleServices, RoleServices>();
builder.Services.AddTransient<IPostServices, PostServices>();
builder.Services.AddTransient<IProductServices, ProductServices>();
builder.Services.AddTransient<IProducerServices,ProducerServices>();
builder.Services.AddTransient<IBillServices, BillServices>();
builder.Services.AddTransient<IBillDetailServices, BillDetailServices>();
builder.Services.AddTransient<IChefServices, ChefServices>();
builder.Services.AddTransient<ICategorieSerivces, CategorieServices>();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<ICartServices, CartServices>();
builder.Services.AddTransient<ICartDetailServices, CartDetailServices>();
builder.Services.AddTransient<IComboServices, ComboServices>();
builder.Services.AddTransient<IComboItemServices, ComboItemServices>();

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
