using ContentNegotiationAndAjax.Models;
using Microsoft.EntityFrameworkCore;

namespace ContentNegotiationAndAjax.Data
{
    public class ApplicationDbConetxt : DbContext
    {
        public ApplicationDbConetxt(DbContextOptions<ApplicationDbConetxt> options) : base(options)
        {

        }
        public DbSet<TaskEmployee> TaskEmpl { get; set; }
    }
}
