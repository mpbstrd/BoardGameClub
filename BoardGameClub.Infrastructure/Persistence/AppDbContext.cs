using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BoardGameClub.Infrastructure.Persistence;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
