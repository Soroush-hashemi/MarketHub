﻿using ApiMarketHub.Domain.CategoryAggregate;
using ApiMarketHub.Domain.CommentAggregate;
using ApiMarketHub.Domain.OrderAggregate;
using ApiMarketHub.Domain.ProductAggregate;
using ApiMarketHub.Domain.RoleAggregate;
using ApiMarketHub.Domain.SellerAggregate;
using ApiMarketHub.Domain.SideEntities;
using ApiMarketHub.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace ApiMarketHub.Infrastructure.Persistence.Command;
public class Context : DbContext
{
    /*
    اینجا در کلاس های مختلف زمان استفاده از کلاس کانتکس به جای اپشن باید یه پارامتری 
    بهش پاس بدیم پس از بیس اپشن ارث بری میکنیم تا بتونیم به اپشن یه پارامتری بدیم 
    */
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<SellerInventory> Inventories { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Poster> Poster { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ShippingMethod> ShippingMethods { get; set; }


    // تنظیمات لازم برای اتصال به دیتابیس رو میده بهمون
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {   // تنظیم می‌کند که تمامی داده‌هایی که از پایگاه داده خوانده می‌شوند و قابل تغییر نیستند
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    /* 
    این متد میره اسمبلی کانتکس رو میگیره و
    تمام کلاس هایی که از کانتکس استفاده کردن رو دریافت میکنه (مثل کانفیگورپروداکت) و تغییراتی که انجام دادن رو میاره اینجا
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}