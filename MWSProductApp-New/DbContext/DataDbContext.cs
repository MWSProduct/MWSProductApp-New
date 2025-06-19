using MWSProductApp.Model;
using Microsoft.EntityFrameworkCore;
namespace MWSProducts;

public class DataDbContext : DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {

    }
    public DbSet<MWSLogin> tbl_UserLogin { get; set; }
    public DbSet<MWSRefreshToken> tbl_UserRefreshToken { get; set; }
    public DbSet<MWSRoles> tbl_refRoles { get; set; }
    public DbSet<MWSSetPassword> tbl_UserSetPassWord { get; set; }
    public DbSet<MWSUserRegister> tbl_UserRegister { get; set; }
    public DbSet<MWSUserRoles> tbl_UserRoles { get; set; }             
    }
