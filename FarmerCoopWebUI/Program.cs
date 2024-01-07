using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddDbContext<FarmerCoopDbContext>();
//builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<FarmerCoopDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{

	//identity k�t�phanesinden default olarak gelen zorunluluklar� kald�r�yorum.
	x.Password.RequireUppercase = false;
	x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireDigit = false;
    x.Password.RequireLowercase = false;
    x.Password.RequiredUniqueChars = 0;

}).AddEntityFrameworkStores<FarmerCoopDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
