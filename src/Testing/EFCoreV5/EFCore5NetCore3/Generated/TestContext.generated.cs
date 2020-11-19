//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v3.0.0.1
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore5NetCore3
{
   /// <inheritdoc/>
   public partial class TestContext : DbContext
   {
      #region DbSets
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::EFCore5NetCore3.Detail3> Detail3 { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::EFCore5NetCore3.Master> Masters { get; set; }

      #endregion DbSets

      /// <summary>
      /// Default connection string
      /// </summary>
      public static string ConnectionString { get; set; } = @"Data Source=.\sqlexpress;Initial Catalog=Test;Integrated Security=True";

      /// <inheritdoc />
      public TestContext(DbContextOptions<TestContext> options) : base(options)
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

         modelBuilder.Owned<global::EFCore5NetCore3.Detail1>();

         modelBuilder.Owned<global::EFCore5NetCore3.Detail2>();

         modelBuilder.Entity<global::EFCore5NetCore3.Detail3>()
                     .ToTable("Detail3")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::EFCore5NetCore3.Detail3>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedOnAdd();

         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .ToTable("Masters")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedOnAdd();
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .HasOne<global::EFCore5NetCore3.Detail3>(p => p.ToZeroOrOneDetail3)
                     .WithMany(p => p.B)
                     .HasForeignKey("ToZeroOrOneDetail3Id");
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .HasOne<global::EFCore5NetCore3.Detail3>(p => p.ToOneDetail3)
                     .WithMany(p => p.A)
                     .HasForeignKey("ToOneDetail3Id");
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .HasMany<global::EFCore5NetCore3.Detail3>(p => p.ToManyDetail3)
                     .WithMany(p => p.C)
                     .UsingEntity(x => x.ToTable("Detail3_C_x_Master_ToManyDetail3"));
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsOne(p => p.ToZeroOrOneDetail1)
                     .WithOwner(p => p.B);
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsOne(p => p.ToZeroOrOneDetail1)
                     .ToTable("Detail1");
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsOne(p => p.ToOneDetail1)
                     .WithOwner(p => p.A);
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsOne(p => p.ToOneDetail1)
                     .ToTable("Detail1");
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .Navigation(p => p.ToOneDetail1).IsRequired();
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsMany(p => p.ToManyDetail1)
                     .ToTable("Detail1");
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsMany(p => p.ToManyDetail1)
                     .WithOwner("C")
                     .HasForeignKey("CId");
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsMany(p => p.ToManyDetail1)
                     .Property<int>("Id");
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsMany(p => p.ToManyDetail1)
                     .HasKey("Id");
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsOne(p => p.ToZeroOrOneDetail2)
                     .WithOwner(p => p.B);
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsOne(p => p.ToZeroOrOneDetail2)
                     .ToTable("Detail2");
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsMany(p => p.ToManyDetail2)
                     .ToTable("Detail2");
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsMany(p => p.ToManyDetail2)
                     .WithOwner("C")
                     .HasForeignKey("CId");
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsMany(p => p.ToManyDetail2)
                     .Property<int>("Id");
         modelBuilder.Entity<global::EFCore5NetCore3.Master>()
                     .OwnsMany(p => p.ToManyDetail2)
                     .HasKey("Id");

         OnModelCreatedImpl(modelBuilder);
      }
   }
}
