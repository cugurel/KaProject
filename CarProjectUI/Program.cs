var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
<<<<<<< Updated upstream
=======
builder.Services.AddMvc(
    config =>
    {
        config.Filters.Add(new ResponseCacheFilter());
    }
);
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer("server = (localdb)\\local; database=uqrtml; integrated security = true; TrustServerCertificate=True;", builder => builder.EnableRetryOnFailure()));
builder.Services.AddIdentity<User,IdentityRole>().
    AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{ 
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = true;
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).
    ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });
>>>>>>> Stashed changes
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=/Auth/Register}");
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
