using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5DBEE0D\\SQLEXPRESS;Database=IkincimDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Ilanlar> TblIlanlar { get; set; }
        public DbSet<Urunler> TblUrunler { get; set; }
        public DbSet<Kategoriler> TblKategoriler { get; set; }
        public DbSet<Begeni> TblBegeni { get; set; }
        public DbSet<Sikayet> TblSikayet { get; set; }
    }
}
