namespace e_commerce_Api.Data
{
    public class ModelContext:DbContext
    {
        //public ModelContext()
        //{
        //}
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }

        public DbSet<Categories>  Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<OrderList> orderList { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<User>users { get; set; }


    }
}
