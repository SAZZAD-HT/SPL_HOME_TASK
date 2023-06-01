using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace SPL_HOME_TASK.Models
{
    public class SPL_HOME_TASKContext : DbContext
    {
        public DbSet<DocumentCategoryInfo> DocumentCategoryInfos { get; set; }
        public DbSet<DocumentInformation> DocumentInformations { get; set; }
        public DbSet<MetaDataInformation> MetaDataInformations { get; set; }
        public DbSet<FileInformation> FileInformations { get; set; }

        public SPL_HOME_TASKContext() : base("name=SPL_HOME_TASKContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentCategoryInfo>()
                .Property(e => e.CategoryName)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UK_CategoryName") { IsUnique = true }));

            modelBuilder.Entity<DocumentInformation>()
                .Property(e => e.DocumentName)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UK_DocumentName") { IsUnique = true }));

            modelBuilder.Entity<MetaDataInformation>()
                .Property(e => e.MetaName)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UK_MetaName") { IsUnique = true }));

            modelBuilder.Entity<FileInformation>()
                .Property(e => e.FileName)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UK_FileName") { IsUnique = true }));

            base.OnModelCreating(modelBuilder);
        }
    }
}