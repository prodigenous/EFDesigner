//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Testing
{
   /// <inheritdoc/>
   public partial class AllFeatureModel : Microsoft.EntityFrameworkCore.DbContext
   {
      #region DbSets
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.AbstractBaseClass> AbstractBaseClasses { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.AllPropertyTypesOptional> AllPropertyTypesOptionals { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.AllPropertyTypesRequired> AllPropertyTypesRequireds { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.BaseClass> BaseClasses { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.BaseClassWithRequiredProperties> BaseClassWithRequiredProperties { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.BChild> BChilds { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.BParentCollection> BParentCollections { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.BParentOptional> BParentOptionals { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.BParentRequired> BParentRequireds { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.Child> Children { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.ConcreteDerivedClass> ConcreteDerivedClasses { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.ConcreteDerivedClassWithRequiredProperties> ConcreteDerivedClassWithRequiredProperties { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.DerivedClass> DerivedClasses { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.HiddenEntity> HiddenEntities { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.Master> Masters { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.ParserTest> ParserTests { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.RenamedColumn> RenamedColumns { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.UChild> UChilds { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.UParentCollection> UParentCollections { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.UParentOptional> UParentOptionals { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<Testing.UParentRequired> UParentRequireds { get; set; }
      #endregion DbSets

      /// <summary>
      /// Default connection string
      /// </summary>
      public static string ConnectionString { get; set; } = @"Data Source=.\sqlexpress;Initial Catalog=Test;Integrated Security=True";

      /// <inheritdoc />
      public AllFeatureModel() : base()
      {
      }

      /// <inheritdoc />
      public AllFeatureModel(DbContextOptions<AllFeatureModel> options) : base(options)
      {
      }

      partial void CustomInit(DbContextOptionsBuilder optionsBuilder);

      /// <inheritdoc />
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         CustomInit(optionsBuilder);
      }

      partial void OnModelCreatingImpl(ModelBuilder modelBuilder);
      partial void OnModelCreatedImpl(ModelBuilder modelBuilder);

      /// <inheritdoc />
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         OnModelCreatingImpl(modelBuilder);

         modelBuilder.HasDefaultSchema("dbo");


         modelBuilder.Entity<Testing.AllPropertyTypesOptional>().ToTable("AllPropertyTypesOptionals").HasKey(t => new { t.Id, t.Id1 });
         modelBuilder.Entity<Testing.AllPropertyTypesOptional>().Property(t => t.Id).IsRequired().ValueGeneratedNever();
         modelBuilder.Entity<Testing.AllPropertyTypesOptional>().Property(t => t.StringAttr).HasMaxLength(10);
         modelBuilder.Entity<Testing.AllPropertyTypesOptional>().Property(t => t.Id1).IsRequired().ValueGeneratedNever();

         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().ToTable("AllPropertyTypesRequireds").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.BinaryAttr).IsRequired();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.BooleanAttr).IsRequired();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.ByteAttr).IsRequired();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.DateTimeAttr).IsRequired();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.DateTimeOffsetAttr).IsRequired();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.DecimalAttr).IsRequired();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.DoubleAttr).IsRequired();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.GuidAttr).IsRequired();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.Int16Attr).IsRequired();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.Int32Attr).IsRequired();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.Int64Attr).IsRequired();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.SingleAttr).IsRequired();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.StringAttr).HasMaxLength(10).IsRequired();
         modelBuilder.Entity<Testing.AllPropertyTypesRequired>().Property(t => t.TimeAttr).IsRequired();


         modelBuilder.Entity<Testing.BaseClassWithRequiredProperties>().ToTable("BaseClassWithRequiredProperties").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.BaseClassWithRequiredProperties>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
         modelBuilder.Entity<Testing.BaseClassWithRequiredProperties>().Property(t => t.Property0).IsRequired();

         modelBuilder.Entity<Testing.BChild>().ToTable("BChilds").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.BChild>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
         modelBuilder.Entity<Testing.BChild>().HasOne(x => x.BParentRequired).WithOne(x => x.BChildOptional).HasForeignKey("BParentRequired_Id");
         modelBuilder.Entity<Testing.BChild>().HasOne(x => x.BParentRequired_1).WithOne(x => x.BChildRequired).HasForeignKey("BParentRequired_1_Id").IsRequired();
         modelBuilder.Entity<Testing.BChild>().HasOne(x => x.BParentRequired_2).WithMany(x => x.BChildCollection).HasForeignKey("BParentRequired_2_Id");
         modelBuilder.Entity<Testing.BChild>().HasMany(x => x.BParentCollection).WithOne(x => x.BChildRequired).HasForeignKey("BChildRequired_Id").IsRequired();
         modelBuilder.Entity<Testing.BChild>().HasMany(x => x.BParentCollection_2).WithOne(x => x.BChildOptional).HasForeignKey("BChildOptional_Id");
         modelBuilder.Entity<Testing.BChild>().HasOne(x => x.BParentOptional).WithOne(x => x.BChildRequired).HasForeignKey("BChildRequired1_Id").IsRequired();
         modelBuilder.Entity<Testing.BChild>().HasOne(x => x.BParentOptional_1).WithMany(x => x.BChildCollection).HasForeignKey("BParentOptional_1_Id");
         modelBuilder.Entity<Testing.BChild>().HasOne(x => x.BParentOptional_2).WithOne(x => x.BChildOptional).HasForeignKey("BParentOptional_2_Id");

         modelBuilder.Entity<Testing.BParentCollection>().ToTable("BParentCollections").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.BParentCollection>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();

         modelBuilder.Entity<Testing.BParentOptional>().ToTable("BParentOptionals").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.BParentOptional>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();

         modelBuilder.Entity<Testing.BParentRequired>().ToTable("BParentRequireds").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.BParentRequired>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();

         modelBuilder.Entity<Testing.Child>().ToTable("Children").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.Child>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
         modelBuilder.Entity<Testing.Child>().HasOne(x => x.Parent).WithMany(x => x.Children).HasForeignKey("Parent_Id");


         modelBuilder.Entity<Testing.ConcreteDerivedClassWithRequiredProperties>().Property(t => t.Property1).IsRequired();


         modelBuilder.Entity<Testing.HiddenEntity>().ToTable("HiddenEntities").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.HiddenEntity>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();

         modelBuilder.Entity<Testing.Master>().ToTable("Masters").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.Master>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
         modelBuilder.Entity<Testing.Master>().HasMany(x => x.Children).WithOne().HasForeignKey("Testing.ChildChildren_Id").IsRequired();

         modelBuilder.Entity<Testing.ParserTest>().ToTable("ParserTests").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.ParserTest>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
         modelBuilder.Entity<Testing.ParserTest>().Property(t => t.name7).HasMaxLength(6);
         modelBuilder.Entity<Testing.ParserTest>().Property(t => t.name8).HasMaxLength(6);
         modelBuilder.Entity<Testing.ParserTest>().Property(t => t.name9).HasMaxLength(6);
         modelBuilder.Entity<Testing.ParserTest>().Property(t => t.name).HasMaxLength(6);
         modelBuilder.Entity<Testing.ParserTest>().Property(t => t.name15).HasMaxLength(6);
         modelBuilder.Entity<Testing.ParserTest>().Property(t => t.name16).HasMaxLength(6);
         modelBuilder.Entity<Testing.ParserTest>().Property(t => t.name17).HasMaxLength(6);
         modelBuilder.Entity<Testing.ParserTest>().Property(t => t.name18).HasMaxLength(6);

         modelBuilder.Entity<Testing.RenamedColumn>().ToTable("RenamedColumns").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.RenamedColumn>().Property(t => t.Id).IsRequired().HasColumnName("Foo").ValueGeneratedOnAdd();

         modelBuilder.Entity<Testing.UChild>().ToTable("UChilds").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.UChild>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();

         modelBuilder.Entity<Testing.UParentCollection>().ToTable("UParentCollections").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.UParentCollection>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
         modelBuilder.Entity<Testing.UParentCollection>().HasOne(x => x.UChildRequired).WithMany().HasForeignKey("UChildRequired_Id");
         modelBuilder.Entity<Testing.UParentCollection>().HasOne(x => x.UChildOptional).WithMany().HasForeignKey("UChildOptional_Id");

         modelBuilder.Entity<Testing.UParentOptional>().HasOne(x => x.UChildOptional).WithOne().HasForeignKey("Testing.UChildUChildOptional_Id");
         modelBuilder.Entity<Testing.UParentOptional>().HasMany(x => x.UChildCollection).WithOne().HasForeignKey("Testing.UChildUChildCollection_Id");
         modelBuilder.Entity<Testing.UParentOptional>().HasOne(x => x.UChildRequired).WithOne().HasForeignKey("UChildRequired_Id");

         modelBuilder.Entity<Testing.UParentRequired>().ToTable("UParentRequireds").HasKey(t => t.Id);
         modelBuilder.Entity<Testing.UParentRequired>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
         modelBuilder.Entity<Testing.UParentRequired>().HasOne(x => x.UChildRequired).WithOne().HasForeignKey("Testing.UChildUChildRequired_Id").IsRequired();
         modelBuilder.Entity<Testing.UParentRequired>().HasMany(x => x.UChildCollection).WithOne().HasForeignKey("Testing.UChildUChildCollection_Id").IsRequired();
         modelBuilder.Entity<Testing.UParentRequired>().HasOne(x => x.UChildOptional).WithOne().HasForeignKey("Testing.UChildUChildOptional_Id").IsRequired();

         OnModelCreatedImpl(modelBuilder);
      }
   }
}
