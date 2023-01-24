﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) 
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(c => c.Title)
                .IsRequired();

            entity.Property(c => c.Description)
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(r => r.Rating)
                .IsRequired();
            
            entity.Property(r => r.Comment)
                .HasMaxLength(500);

            entity.HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();
            
            entity.Property(p => p.Description)
                .HasMaxLength(500);

            entity.Property(p => p.Rating)
                .HasPrecision(2);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();
            
            entity.Property(p => p.Description)
                .HasMaxLength(500);
            
            entity.Property(p => p.Price)
                .HasPrecision(2);

            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.HasOne(p => p.Manufacturer)
                .WithMany(m => m.Products)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(p => p.Tags)
                .WithMany(t => t.Products);
        });

    }
}