using MWSProductApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;
namespace MWSProducts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataDbContext>
    {
        public DataDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<DataDbContext>();
            optionBuilder.UseSqlServer("Data Source=ASPLAP1341\\SQLEXPRESS;Initial Catalog=MWSProductDEV;Persist Security Info=True;Enlist=True;TrustServerCertificate=True;Integrated Security=True;");
            return new DataDbContext(optionBuilder.Options);
        }
    }            
    
}
