using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.Context
{
    public class UnitOfWork : DbContext
    {
        public DbSet<CalculoHistoricoModel> CalculoHistorico { get; set; }
        public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalculoHistoricoModel>()
                .HasIndex(u => u.Id)
                .IsUnique();

            // Desabilita a exclusão em cascata
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(p => p.GetForeignKeys()))
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
