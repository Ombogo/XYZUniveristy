using Microsoft.EntityFrameworkCore;
using XYZUniversityPaymentsAPI.Models;

namespace XYZUniversityPaymentsAPI.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }  // DbSet for the Students table
    public DbSet<PaymentNotification> PaymentNotifications { get; set; }  // DbSet for the PaymentNotifications table

}