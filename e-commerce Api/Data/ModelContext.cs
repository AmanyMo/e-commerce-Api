namespace e_commerce_Api.Data
{
    public class ModelContext:DbContext
    {
        public ModelContext(DbContextOptions<ModelContext>options):base(options)
        {
        }

       public DbSet<Products> Products { get; set; }
        public DbSet<Categories>  Categories { get; set; }
    }
}
