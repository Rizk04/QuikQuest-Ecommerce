using Microsoft.EntityFrameworkCore;
using QuikQuest.Data;
using Microsoft.AspNetCore.Identity;
using QuikQuest.Areas.Identity.Data;
public class Program
{ 
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(options
            => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddDbContext<AuthDbContext>(options
            => options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbContextConnection")));


        builder.Services.AddDefaultIdentity<QuikQuestUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AuthDbContext>();

        builder.Services.AddRazorPages();
        builder.Services.Configure<IdentityOptions>(options =>
        {

            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        });
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
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        using(var scope = app.Services.CreateScope())
        {
            
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
    var roles = new[] { "Admin", "Member" };

            foreach(var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

        }
  
        app.Run();
    }
    
}


