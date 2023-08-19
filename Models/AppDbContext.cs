using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCommercialeServices.Models.Class;

namespace GestionCommercialeServices.Models;

public class AppDbContext:DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Taxe> Taxes { get; set; }
    public virtual DbSet<UniteOfSale> UniteOfSales { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Region> Regions { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<Sale> Ventes { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public virtual DbSet<PaymentClient> PaymentClients { get; set; }
    public virtual DbSet<TypePayment> TypePayment { get; set; }

    public virtual DbSet<DetailsSale> DetailsSales{ get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }





}
