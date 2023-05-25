using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TownMVC.Models;

namespace TownMVC.TownDataContext;

public class TownDbContext : IdentityDbContext<AppUser>
{
	public TownDbContext(DbContextOptions<TownDbContext> options) : base(options)
	{

	}
	public DbSet<Crud> Cruds { get; set; }
	public DbSet<Setting> Settings { get; set; }
}
