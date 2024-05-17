using Medicio.Application.Abstractions;
using Medicio.Domain.Models;
using Medicio.Persistence.Concretes;
using Medicio.Persistence.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Medicio.Persistence.Concretes;

namespace Medicio.Presentation
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddIdentity<User,IdentityRole>
				().AddEntityFrameworkStores<AppDbContext>();
			
			builder.Services.AddScoped<IDoctorService, DoctorServices>();
			builder.Services.AddScoped<IUserService, UserServices>();

			builder.Services.AddDbContext<AppDbContext>(opt =>
			{
				opt.UseSqlServer(builder.Configuration.GetConnectionString("default"));
			});
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapControllerRoute(
			name: "areas",
			pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
		  );

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}