using HaberSistemi.Data.DataContext.Model;
using HaberSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSistemi.Data.DataContext
{
    public class HaberContext : DbContext
    {
        public HaberContext()
        {
            Database.Connection.ConnectionString = "Server=DESKTOP-9I5UOLU;Database=HaberPortali;integrated security=True";
        }
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Haber> Habers { get; set; }
        public DbSet<Resim> Resims { get; set; }
    }
}
