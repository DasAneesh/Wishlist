using Microsoft.EntityFrameworkCore;
using MYwishlist.Repository;

namespace MYwishserver
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {

        }

        public DbSet<Wish> Wishes => Set<Wish>();
    }
}
