using System;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PackAPI.Models;

namespace PackAPIAPI.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    { }
    public DbSet<User> User { get; set; } = null!;
}