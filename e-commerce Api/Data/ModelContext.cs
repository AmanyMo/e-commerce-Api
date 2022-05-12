using Microsoft.EntityFrameworkCore;
namespace e_commerce_Api.Models
{
    public class ModelContext : DbContext
    {

        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {

        }

        DbSet<Products> Products { get; set; }
    }
}