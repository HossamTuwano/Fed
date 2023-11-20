using Fed.Models;
using Microsoft.EntityFrameworkCore;

namespace Fed;

public class FedDbContext : DbContext
{
    public FedDbContext(DbContextOptions<FedDbContext> options) : base(options)
    {
    }

    DbSet<Food> Foods { get; set; }
}






