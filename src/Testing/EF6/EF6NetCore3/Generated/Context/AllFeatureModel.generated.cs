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
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace Testing
{
   /// <inheritdoc/>
   public partial class AllFeatureModel : DbContext
   {
      #region DbSets
      public virtual System.Data.Entity.DbSet<global::Testing.AbstractBaseClass> AbstractBaseClasses { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.AllPropertyTypesOptional> AllPropertyTypesOptionals { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.AllPropertyTypesRequired> AllPropertyTypesRequireds { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.BaseClass> BaseClasses { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.BaseClassWithRequiredProperties> BaseClassWithRequiredProperties { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.BChild> BChilds { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.BParentCollection> BParentCollections { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.BParentOptional> BParentOptionals { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.BParentRequired> BParentRequireds { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.Child> Children { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.ConcreteDerivedClass> ConcreteDerivedClasses { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.ConcreteDerivedClassWithRequiredProperties> ConcreteDerivedClassWithRequiredProperties { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.DerivedClass> DerivedClasses { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.HiddenEntity> HiddenEntities { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.Master> Masters { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.ParserTest> ParserTests { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.RenamedColumn> RenamedColumns { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.SpatialProperties> SpatialProperties { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.UChild> UChilds { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.UParentCollection> UParentCollections { get; set; }

      /// <summary>
      /// Repository for global::Testing.UParentOptional - x
      /// </summary>
      public virtual System.Data.Entity.DbSet<global::Testing.UParentOptional> UParentOptionals { get; set; }
      public virtual System.Data.Entity.DbSet<global::Testing.UParentRequired> UParentRequireds { get; set; }
      #endregion DbSets

      #region Constructors

      partial void CustomInit();

      /// <summary>
      /// Default connection string
      /// </summary>
      public static string ConnectionString { get; set; } = @"Data Source=.\sqlexpress;Initial Catalog=Test;Integrated Security=True";
      /// <inheritdoc />
      public AllFeatureModel() : base(ConnectionString)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<AllFeatureModel>(null);
         CustomInit();
      }

      /// <inheritdoc />
      public AllFeatureModel(string connectionString) : base(connectionString)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<AllFeatureModel>(null);
         CustomInit();
      }

      /// <inheritdoc />
      public AllFeatureModel(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<AllFeatureModel>(null);
         CustomInit();
      }

      /// <inheritdoc />
      public AllFeatureModel(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<AllFeatureModel>(null);
         CustomInit();
      }

      /// <inheritdoc />
      public AllFeatureModel(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection) : base(existingConnection, model, contextOwnsConnection)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<AllFeatureModel>(null);
         CustomInit();
      }

      /// <inheritdoc />
      public AllFeatureModel(System.Data.Entity.Infrastructure.DbCompiledModel model) : base(model)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<AllFeatureModel>(null);
         CustomInit();
      }

      /// <inheritdoc />
      public AllFeatureModel(System.Data.Entity.Core.Objects.ObjectContext objectContext, bool dbContextOwnsObjectContext) : base(objectContext, dbContextOwnsObjectContext)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<AllFeatureModel>(null);
         CustomInit();
      }

      #endregion Constructors

      partial void OnModelCreatingImpl(System.Data.Entity.DbModelBuilder modelBuilder);
      partial void OnModelCreatedImpl(System.Data.Entity.DbModelBuilder modelBuilder);

      /// <inheritdoc />
      protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         OnModelCreatingImpl(modelBuilder);

         modelBuilder.HasDefaultSchema("dbo");

         modelBuilder.Entity<global::Testing.AbstractBaseClass>();

         modelBuilder.Entity<global::Testing.AllPropertyTypesOptional>().ToTable("AllPropertyTypesOptionals").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.AllPropertyTypesOptional>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().ToTable("AllPropertyTypesRequireds").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.BinaryAttr).IsRequired();
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.BooleanAttr).IsRequired();
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.ByteAttr).IsRequired();
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.DateTimeAttr).IsRequired();
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.DateTimeOffsetAttr).IsRequired();
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.DecimalAttr).IsRequired();
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.DoubleAttr).IsRequired();
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.GuidAttr).IsRequired();
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.Int16Attr).IsRequired();
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.Int32Attr).IsRequired();
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.Int64Attr).IsRequired();
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.SingleAttr).IsRequired();
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.TimeAttr).IsRequired();
         modelBuilder.Entity<global::Testing.AllPropertyTypesRequired>().Property(t => t.StringAttr).IsRequired();

         modelBuilder.Entity<global::Testing.BaseClass>();

         modelBuilder.Entity<global::Testing.BaseClassWithRequiredProperties>().ToTable("BaseClassWithRequiredProperties").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.BaseClassWithRequiredProperties>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         modelBuilder.Entity<global::Testing.BaseClassWithRequiredProperties>().Property(t => t.Property0).IsRequired();

         modelBuilder.Entity<global::Testing.BChild>().ToTable("BChilds").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.BChild>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         modelBuilder.Entity<global::Testing.BChild>().HasRequired(x => x.BParentRequired).WithOptional(x => x.BChildOptional);
         modelBuilder.Entity<global::Testing.BChild>().HasRequired(x => x.BParentRequired_1).WithRequiredPrincipal(x => x.BChildRequired);
         modelBuilder.Entity<global::Testing.BChild>().HasRequired(x => x.BParentRequired_2).WithMany(x => x.BChildCollection).Map(x => x.MapKey("BParentRequired_2Id"));
         modelBuilder.Entity<global::Testing.BChild>().HasMany(x => x.BParentCollection).WithRequired(x => x.BChildRequired).Map(x => x.MapKey("BChildRequiredId"));
         modelBuilder.Entity<global::Testing.BChild>().HasMany(x => x.BParentCollection_1).WithMany(x => x.BChildCollection).Map(x => { x.ToTable("BParentCollection_1_x_BChildCollection"); x.MapLeftKey("BChild_Id"); x.MapRightKey("BParentCollection_Id"); });
         modelBuilder.Entity<global::Testing.BChild>().HasMany(x => x.BParentCollection_2).WithOptional(x => x.BChildOptional).Map(x => x.MapKey("BChildOptionalId"));
         modelBuilder.Entity<global::Testing.BChild>().HasOptional(x => x.BParentOptional).WithRequired(x => x.BChildRequired);
         modelBuilder.Entity<global::Testing.BChild>().HasOptional(x => x.BParentOptional_1).WithMany(x => x.BChildCollection).Map(x => x.MapKey("BParentOptional_1Id"));
         modelBuilder.Entity<global::Testing.BChild>().HasOptional(x => x.BParentOptional_2).WithOptionalPrincipal(x => x.BChildOptional);

         modelBuilder.Entity<global::Testing.BParentCollection>().ToTable("BParentCollections").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.BParentCollection>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

         modelBuilder.Entity<global::Testing.BParentOptional>().ToTable("BParentOptionals").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.BParentOptional>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

         modelBuilder.Entity<global::Testing.BParentRequired>().ToTable("BParentRequireds").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.BParentRequired>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

         modelBuilder.Entity<global::Testing.Child>().ToTable("Children").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.Child>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         modelBuilder.Entity<global::Testing.Child>().HasRequired(x => x.Parent).WithMany(x => x.Children).Map(x => x.MapKey("ParentId"));

         modelBuilder.Entity<global::Testing.ConcreteDerivedClass>();

         modelBuilder.Entity<global::Testing.ConcreteDerivedClassWithRequiredProperties>();
         modelBuilder.Entity<global::Testing.ConcreteDerivedClassWithRequiredProperties>().Property(t => t.Property1).IsRequired();

         modelBuilder.Entity<global::Testing.DerivedClass>();

         modelBuilder.Entity<global::Testing.HiddenEntity>().ToTable("HiddenEntities").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.HiddenEntity>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

         modelBuilder.Entity<global::Testing.Master>().ToTable("Masters").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.Master>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         modelBuilder.Entity<global::Testing.Master>().HasMany(x => x.Children).WithRequired().Map(x => x.MapKey("Master_Children_Id"));

         modelBuilder.Entity<global::Testing.ParserTest>().ToTable("ParserTests").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.ParserTest>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
         modelBuilder.Entity<global::Testing.ParserTest>().Property(t => t.foo).IsRequired();

         modelBuilder.Entity<global::Testing.RenamedColumn>().ToTable("RenamedColumns").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.RenamedColumn>().Property(t => t.Id).IsRequired().HasColumnName("Foo").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

         modelBuilder.Entity<global::Testing.SpatialProperties>().ToTable("SpatialProperties").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.SpatialProperties>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

         modelBuilder.Entity<global::Testing.UChild>().ToTable("UChilds").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.UChild>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

         modelBuilder.Entity<global::Testing.UParentCollection>().ToTable("UParentCollections").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.UParentCollection>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         modelBuilder.Entity<global::Testing.UParentCollection>().HasRequired(x => x.UChildRequired).WithMany().Map(x => x.MapKey("UChildRequiredId"));
         modelBuilder.Entity<global::Testing.UParentCollection>().HasMany(x => x.UChildCollection).WithMany().Map(x => { x.ToTable("UParentCollection_x_UChildCollection"); x.MapLeftKey("UParentCollection_Id"); x.MapRightKey("UChild_Id"); });
         modelBuilder.Entity<global::Testing.UParentCollection>().HasOptional(x => x.UChildOptional).WithMany().Map(x => x.MapKey("UChildOptionalId"));

         modelBuilder.Entity<global::Testing.UParentOptional>();
         modelBuilder.Entity<global::Testing.UParentOptional>().HasOptional(x => x.UChildOptional).WithOptionalDependent();
         modelBuilder.Entity<global::Testing.UParentOptional>().HasMany(x => x.UChildCollection).WithOptional();
         modelBuilder.Entity<global::Testing.UParentOptional>().HasRequired(x => x.UChildRequired).WithOptional();

         modelBuilder.Entity<global::Testing.UParentRequired>().ToTable("UParentRequireds").HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.UParentRequired>().Property(t => t.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         modelBuilder.Entity<global::Testing.UParentRequired>().HasRequired(x => x.UChildRequired).WithRequiredDependent();
         modelBuilder.Entity<global::Testing.UParentRequired>().HasMany(x => x.UChildCollection).WithRequired().Map(x => x.MapKey("UParentRequired_UChildCollection_Id"));
         modelBuilder.Entity<global::Testing.UParentRequired>().HasOptional(x => x.UChildOptional).WithRequired().WillCascadeOnDelete(true);

         OnModelCreatedImpl(modelBuilder);
      }
   }
}
