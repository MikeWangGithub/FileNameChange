using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using FCNDBContext.BussinessEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCNDBContext.DataAccessLayer
{
    public class FCNDBContext : DbContext
    {
        public DbSet<Files> PDFFiles { get; set; }
        public DbSet<Check> PDFCheck { get; set; }


        public FCNDBContext(string connectionName)
            : base(connectionName)
        {

        }
        public FCNDBContext()
            : base("SQLServerDBString")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SequenceTableMap());

            modelBuilder.Configurations.Add(new FilesTableMap());
            

            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// Model  Object Mapping Class : Files Table
        /// </summary>
        public class FilesTableMap : EntityTypeConfiguration<Files>
        {
            public FilesTableMap()
            {
                this.ToTable("Files");
                this.HasKey(p => p.ID);
                // this.Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
                this.Property(p => p.CreateDate).IsRequired().HasColumnName("CreateDate");
                this.Property(p => p.ModifyDate).HasColumnName("ModifyDate");
                this.Property(p => p.FileName).IsRequired().HasMaxLength(240).HasColumnName("FileName").IsUnicode(true);
                this.Property(p => p.FileFullName).IsRequired().HasMaxLength(300).HasColumnName("FileFullName");
                this.Property(p => p.FilePath).IsRequired().HasMaxLength(300).HasColumnName("FilePath");
                this.Property(p => p.Extension).IsRequired().HasMaxLength(10).HasColumnName("Extension");
                this.Property(p => p.IsValid).IsRequired().HasColumnName("IsValid");
                this.Property(p => p.Size).HasColumnName("Size");
                this.Property(p => p.Size_Abbreviation).HasMaxLength(30).HasColumnName("Size_Abbreviation").IsUnicode(true);
                this.Property(p => p.Memo).HasMaxLength(300).HasColumnName("Memo").IsUnicode(true);


            }
        }/// <summary>
         /// Model  Object Mapping Class : Sequence Table
         /// </summary>
        public class SequenceTableMap : EntityTypeConfiguration<Check>
        {
            public SequenceTableMap()
            {
                this.ToTable("Check");
                this.HasKey(p => p.ID);
                this.Property(p => p.Name).HasMaxLength(100).HasColumnName("Name").IsUnicode(true);
                // this.Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
                this.Property(p => p.CreateDate).HasColumnName("CreateDate");
                this.Property(p => p.CheckDirectory).HasMaxLength(300).HasColumnName("CheckDirectory").IsUnicode(true);
                this.Property(p => p.Total).HasColumnName("Total");
                this.Property(p => p.Valid).HasColumnName("Valid");
                this.Property(p => p.Invalid).HasColumnName("Invalid");

                // config TypeTable.ID : ColumnTable.TypeID (1:0..n)
                this.HasMany(seq => seq._fileslist).WithRequired(files => files._check).HasForeignKey(files => files.CheckID);

            }
        }


        

    }
}
