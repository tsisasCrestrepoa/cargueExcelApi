using Microsoft.EntityFrameworkCore;
using PruebaCargueExcel.Models;

namespace PruebaCargueExcel
{
    public class PruebaCargueExcelContext:DbContext
    {
        public DbSet<TmpCargueExcel> TmpCargueExcel { get; set; }

        public PruebaCargueExcelContext(DbContextOptions<PruebaCargueExcelContext> options):base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TmpCargueExcel>(tmpCargueExcel =>
            {
                tmpCargueExcel.ToTable("TMP_CARGUE_EXCEL");
                tmpCargueExcel.HasKey(tmp => tmp.Id);
                tmpCargueExcel.Ignore(tmp => tmp.Archivo);
            });
        }
    }
}
