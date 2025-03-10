﻿using Microsoft.EntityFrameworkCore;

namespace top_bod_be.Models
{
    public class NutritionDetailsContext : DbContext
    {
        public NutritionDetailsContext(DbContextOptions<NutritionDetailsContext> options) : base(options){ }

        public DbSet<NutritionDetail> NutritionDetails { get; set; } = null!;
    }
}
