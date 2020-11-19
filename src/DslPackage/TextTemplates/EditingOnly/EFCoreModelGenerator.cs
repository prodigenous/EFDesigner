﻿using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

// ReSharper disable UnusedMember.Global

namespace Sawczyn.EFDesigner.EFModel.EditingOnly
{
   public partial class GeneratedTextTransformation
   {
      #region Template
      // EFDesigner v3.0.0.1
      // Copyright (c) 2017-2020 Michael Sawczyn
      // https://github.com/msawczyn/EFDesigner

      public abstract class EFCoreModelGenerator : EFModelGenerator
      {
         protected EFCoreModelGenerator(GeneratedTextTransformation host) : base(host) { }

         protected string[] SpatialTypes
         {
            get
            {
               return new[]
                      {
                         "Geometry"
                       , "GeometryPoint"
                       , "GeometryLineString"
                       , "GeometryPolygon"
                       , "GeometryCollection"
                       , "GeometryMultiPoint"
                       , "GeometryMultiLineString"
                       , "GeometryMultiPolygon"
                      };
            }
         }

         [SuppressMessage("ReSharper", "RedundantNameQualifier")]
         protected virtual void ConfigureBidirectionalAssociations(ModelClass modelClass
                                                                 , List<Association> visited
                                                                 , List<string> foreignKeyColumns
                                                                 , List<string> declaredShadowProperties)
         {
            MakeNonDependentAssociations();
            MakeDependentAssociations(modelClass, $"modelBuilder.Entity<{modelClass.FullName}>()");

            void MakeNonDependentAssociations()
            {
               // ReSharper disable once LoopCanBePartlyConvertedToQuery
               foreach (BidirectionalAssociation association in Association.GetLinksToTargets(modelClass)
                                                                           .OfType<BidirectionalAssociation>()
                                                                           .Where(x => x.Persistent && !x.Target.IsDependentType))
               {
                  if (visited.Contains(association))
                     continue;

                  visited.Add(association);

                  List<string> segments = new List<string>();
                  bool required = false;

                  segments.Add($"modelBuilder.Entity<{modelClass.FullName}>()");

                  switch (association.TargetMultiplicity) // realized by property on source
                  {
                     case Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroMany:
                        segments.Add($"HasMany<{association.Target.FullName}>(p => p.{association.TargetPropertyName})");

                        break;

                     case Sawczyn.EFDesigner.EFModel.Multiplicity.One:
                        segments.Add($"HasOne<{association.Target.FullName}>(p => p.{association.TargetPropertyName})");
                        required = (modelClass == association.Principal);

                        break;

                     case Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroOne:
                        segments.Add($"HasOne<{association.Target.FullName}>(p => p.{association.TargetPropertyName})");

                        break;
                  }

                  switch (association.SourceMultiplicity) // realized by property on target, but no property on target
                  {
                     case Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroMany:
                        segments.Add($"WithMany(p => p.{association.SourcePropertyName})");

                        if (association.TargetMultiplicity == Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroMany)
                        {
                           string tableMap = string.IsNullOrEmpty(association.JoinTableName)
                                                ? $"{association.Target.Name}_{association.SourcePropertyName}_x_{association.Source.Name}_{association.TargetPropertyName}"
                                                : association.JoinTableName;

                           segments.Add($"UsingEntity(x => x.ToTable(\"{tableMap}\"))");
                        }

                        break;

                     case Sawczyn.EFDesigner.EFModel.Multiplicity.One:
                        segments.Add($"WithOne(p => p.{association.SourcePropertyName})");
                        required = (modelClass == association.Principal);

                        break;

                     case Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroOne:
                        segments.Add($"WithOne(p => p.{association.SourcePropertyName})");

                        break;
                  }

                  string foreignKeySegment = CreateForeignKeySegment(association, foreignKeyColumns);

                  if (!string.IsNullOrEmpty(foreignKeySegment))
                     segments.Add(foreignKeySegment);

                  if (!association.Source.IsDependentType && !association.Target.IsDependentType
                   && (association.TargetRole == EndpointRole.Principal || association.SourceRole == EndpointRole.Principal))
                  {
                     DeleteAction deleteAction = association.SourceRole == EndpointRole.Principal
                                                    ? association.SourceDeleteAction
                                                    : association.TargetDeleteAction;

                     switch (deleteAction)
                     {
                        case DeleteAction.None:
                           segments.Add("OnDelete(DeleteBehavior.NoAction)");

                           break;

                        case DeleteAction.Cascade:
                           segments.Add("OnDelete(DeleteBehavior.Cascade)");

                           break;
                     }
                  }

                  if (required
                   && (association.SourceMultiplicity != Sawczyn.EFDesigner.EFModel.Multiplicity.One
                    || association.TargetMultiplicity != Sawczyn.EFDesigner.EFModel.Multiplicity.One))
                     segments.Add("IsRequired()");

                  Output(segments);
               }
            }

            void MakeDependentAssociations(ModelClass sourceInstance, string baseSegment)
            {
               // ReSharper disable once LoopCanBePartlyConvertedToQuery
               foreach (BidirectionalAssociation association in Association.GetLinksToTargets(sourceInstance)
                                                                           .OfType<BidirectionalAssociation>()
                                                                           .Where(x => x.Persistent && x.Target.IsDependentType))
               {
                  if (visited.Contains(association))
                     continue;

                  visited.Add(association);

                  List<string> segments = new List<string>();

                  switch (association.TargetMultiplicity) // realized by property on source
                  {
                     case Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroMany:
                     {
                        segments.Add(baseSegment);
                        segments.Add($"OwnsMany(p => p.{association.TargetPropertyName})");
                        segments.Add($"ToTable(\"{(string.IsNullOrEmpty(association.Target.TableName) ? association.Target.Name : association.Target.TableName)}\")");
                        Output(segments);

                        segments.Add(baseSegment);
                        segments.Add($"OwnsMany(p => p.{association.TargetPropertyName})");
                        segments.Add($"WithOwner(\"{association.SourcePropertyName}\")");
                        segments.Add($"HasForeignKey(\"{association.SourcePropertyName}Id\")");
                        Output(segments);

                        segments.Add(baseSegment);
                        segments.Add($"OwnsMany(p => p.{association.TargetPropertyName})");
                        segments.Add("Property<int>(\"Id\")");

                        Output(segments);

                        segments.Add(baseSegment);
                        segments.Add($"OwnsMany(p => p.{association.TargetPropertyName})");
                        segments.Add("HasKey(\"Id\")");

                        Output(segments);

                        MakeDependentAssociations(association.Target, $"{baseSegment}.OwnsMany(p => p.{association.TargetPropertyName})");

                        break;
                     }

                     case Sawczyn.EFDesigner.EFModel.Multiplicity.One:
                     {
                        segments.Add(baseSegment);
                        segments.Add($"OwnsOne(p => p.{association.TargetPropertyName})");
                        segments.Add($"WithOwner(p => p.{association.SourcePropertyName})");
                        Output(segments);

                        if (!string.IsNullOrEmpty(association.Target.TableName))
                        {
                           segments.Add(baseSegment);
                           segments.Add($"OwnsOne(p => p.{association.TargetPropertyName})");
                           segments.Add($"ToTable(\"{association.Target.TableName}\")");
                           Output(segments);
                        }

                        foreach (ModelAttribute modelAttribute in association.Target.AllAttributes)
                        {
                           segments.Add($"{baseSegment}.OwnsOne(p => p.{association.TargetPropertyName}).Property(p => p.{modelAttribute.Name})");

                           if (modelAttribute.ColumnName != modelAttribute.Name)
                              segments.Add($"HasColumnName(\"{modelAttribute.ColumnName}\")");

                           if (modelAttribute.Required)
                              segments.Add("IsRequired()");

                           if (segments.Count > 1)
                              Output(segments);

                           segments.Clear();
                        }

                        segments.Add(baseSegment);
                        segments.Add($"Navigation(p => p.{association.TargetPropertyName}).IsRequired()");
                        Output(segments);

                        MakeDependentAssociations(association.Target, $"{baseSegment}.OwnsOne(p => p.{association.TargetPropertyName})");

                        break;
                     }

                     case Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroOne:
                     {
                        segments.Add(baseSegment);
                        segments.Add($"OwnsOne(p => p.{association.TargetPropertyName})");
                        segments.Add($"WithOwner(p => p.{association.SourcePropertyName})");
                        Output(segments);

                        if (!string.IsNullOrEmpty(association.Target.TableName))
                        {
                           segments.Add(baseSegment);
                           segments.Add($"OwnsOne(p => p.{association.TargetPropertyName})");
                           segments.Add($"ToTable(\"{association.Target.TableName}\")");
                           Output(segments);
                        }

                        foreach (ModelAttribute modelAttribute in association.Target.AllAttributes)
                        {
                           segments.Add($"{baseSegment}.OwnsOne(p => p.{association.TargetPropertyName}).Property(p => p.{modelAttribute.Name})");

                           if (modelAttribute.ColumnName != modelAttribute.Name)
                              segments.Add($"HasColumnName(\"{modelAttribute.ColumnName}\")");

                           if (modelAttribute.Required)
                              segments.Add("IsRequired()");

                           if (segments.Count > 1)
                              Output(segments);

                           segments.Clear();
                        }

                        MakeDependentAssociations(association.Target, $"{baseSegment}.OwnsOne(p => p.{association.TargetPropertyName})");

                        break;
                     }
                  }
               }
            }
         }

         protected virtual void ConfigureModelAttributes(List<string> segments, ModelClass modelClass)
         {
            foreach (ModelAttribute modelAttribute in modelClass.Attributes.Where(x => x.Persistent && !SpatialTypes.Contains(x.Type)))
            {
               segments.Clear();

               if ((modelAttribute.MaxLength ?? 0) > 0)

                  // ReSharper disable once PossibleInvalidOperationException
                  segments.Add($"HasMaxLength({modelAttribute.MaxLength.Value})");

               if (modelAttribute.Required)
                  segments.Add("IsRequired()");

               if (modelAttribute.ColumnName != modelAttribute.Name && !string.IsNullOrEmpty(modelAttribute.ColumnName))
                  segments.Add($"HasColumnName(\"{modelAttribute.ColumnName}\")");

               if (!modelAttribute.AutoProperty)
               {
                  segments.Add($"HasField(\"{modelAttribute.BackingFieldName}\")");
                  segments.Add($"UsePropertyAccessMode(PropertyAccessMode.{modelAttribute.PropertyAccessMode})");
               }

               if (!string.IsNullOrEmpty(modelAttribute.ColumnType) && modelAttribute.ColumnType.ToLowerInvariant() != "default")
               {
                  if (modelAttribute.ColumnType.ToLowerInvariant() == "varchar" || modelAttribute.ColumnType.ToLowerInvariant() == "nvarchar" || modelAttribute.ColumnType.ToLowerInvariant() == "char")
                     segments.Add($"HasColumnType(\"{modelAttribute.ColumnType}({(modelAttribute.MaxLength > 0 ? modelAttribute.MaxLength.ToString() : "max")})\")");
                  else
                     segments.Add($"HasColumnType(\"{modelAttribute.ColumnType}\")");
               }

               if (modelAttribute.IsConcurrencyToken)
                  segments.Add("IsRowVersion()");

               if (modelAttribute.IsIdentity)
               {
                  segments.Add(modelAttribute.IdentityType == IdentityType.AutoGenerated
                                  ? "ValueGeneratedOnAdd()"
                                  : "ValueGeneratedNever()");
               }

               if (segments.Any())
               {
                  segments.Insert(0, $"modelBuilder.Entity<{modelClass.FullName}>()");
                  segments.Insert(1, $"Property(t => t.{modelAttribute.Name})");

                  Output(segments);
               }

               if (modelAttribute.Indexed && !modelAttribute.IsIdentity)
               {
                  segments.Clear();

                  segments.Add($"modelBuilder.Entity<{modelClass.FullName}>().HasIndex(t => t.{modelAttribute.Name})");

                  if (modelAttribute.IndexedUnique)
                     segments.Add("IsUnique()");

                  Output(segments);
               }
            }
         }

         protected virtual void ConfigureModelClasses(List<string> segments, ModelClass[] classesWithTables, List<string> foreignKeyColumns, List<Association> visited)
         {
            foreach (ModelClass modelClass in modelRoot.Classes.OrderBy(x => x.Name))
            {
               segments.Clear();
               foreignKeyColumns.Clear();
               NL();

               if (modelClass.IsDependentType)
               {
                  segments.Add($"modelBuilder.Owned<{modelClass.FullName}>()");
                  Output(segments);
                  continue;
               }

               segments.Add($"modelBuilder.Entity<{modelClass.FullName}>()");

               foreach (ModelAttribute transient in modelClass.Attributes.Where(x => !x.Persistent))
                  segments.Add($"Ignore(t => t.{transient.Name})");

               if (modelRoot.InheritanceStrategy == CodeStrategy.TablePerConcreteType && modelClass.Superclass != null)
                  segments.Add("Map(x => x.MapInheritedProperties())");

               if (classesWithTables.Contains(modelClass))
               {
                  if (modelClass.IsQueryType)
                  {
                     Output($"// There is no table defined for {modelClass.Name} because its IsQueryType value is");
                     Output($"// set to 'true'. Please provide the {modelRoot.FullName}.Get{modelClass.Name}SqlQuery() method in the partial class.");
                     Output("// ");
                     Output($"// private string Get{modelClass.Name}SqlQuery()");
                     Output("// {");
                     Output($"//    return the defining SQL query that pulls all the properties for {modelClass.FullName}");
                     Output("// }");

                     segments.Add($"ToSqlQuery(Get{modelClass.Name}SqlQuery())");
                  }
                  else
                  {
                     if (!string.IsNullOrEmpty(modelClass.TableName))
                     {
                        segments.Add(string.IsNullOrEmpty(modelClass.DatabaseSchema) || modelClass.DatabaseSchema == modelClass.ModelRoot.DatabaseSchema
                                        ? $"ToTable(\"{modelClass.TableName}\")"
                                        : $"ToTable(\"{modelClass.TableName}\", \"{modelClass.DatabaseSchema}\")");
                     }

                     // primary key code segments must be output last, since HasKey returns a different type
                     List<ModelAttribute> identityAttributes = modelClass.IdentityAttributes.ToList();

                     if (identityAttributes.Count == 1)
                        segments.Add($"HasKey(t => t.{identityAttributes[0].Name})");
                     else if (identityAttributes.Count > 1)
                        segments.Add($"HasKey(t => new {{ t.{string.Join(", t.", identityAttributes.Select(ia => ia.Name))} }})");
                  }
               }

               if (segments.Count > 1 || modelClass.IsDependentType)
                  Output(segments);

               // attribute level
               ConfigureModelAttributes(segments, modelClass);

               bool hasDefinedConcurrencyToken = modelClass.AllAttributes.Any(x => x.IsConcurrencyToken);

               if (!hasDefinedConcurrencyToken && modelClass.EffectiveConcurrency == ConcurrencyOverride.Optimistic)
                  Output($@"modelBuilder.Entity<{modelClass.FullName}>().Property<byte[]>(""Timestamp"").IsConcurrencyToken();");

               // Navigation endpoints are distingished as Source and Target. They are also distinguished as Principal
               // and Dependent. So how do these map to each other? Short answer: they don't - they're orthogonal concepts.
               // Source and Target are accidents of where the user started drawing the association, and help define where the
               // properties are in unidirectional associations. Principal and Dependent define where the foreign keys go in 
               // the persistence mechanism.

               // What matters to code generation is the Principal and Dependent classifications, so we docus on those. 
               // In the case of 1-1 or 0/1-0/1, it's situational, so the user has to tell us.
               // In all other cases, we can tell by the cardinalities of the associations.

               // navigation properties
               List<string> declaredShadowProperties = new List<string>();

               if (!modelClass.IsDependentType)
               {
                  ConfigureUnidirectionalAssociations(modelClass, visited, foreignKeyColumns, declaredShadowProperties);
                  ConfigureBidirectionalAssociations(modelClass, visited, foreignKeyColumns, declaredShadowProperties);
               }
            }
         }

         [SuppressMessage("ReSharper", "RedundantNameQualifier")]
         protected virtual void ConfigureUnidirectionalAssociations(ModelClass modelClass
                                                                  , List<Association> visited
                                                                  , List<string> foreignKeyColumns
                                                                  , List<string> declaredShadowProperties)
         {
            MakeNonDependentAssociations();
            MakeDependentAssociations(modelClass, $"modelBuilder.Entity<{modelClass.FullName}>()");

            void MakeNonDependentAssociations()
            {
               // ReSharper disable once LoopCanBePartlyConvertedToQuery
               foreach (UnidirectionalAssociation association in Association.GetLinksToTargets(modelClass)
                                                                            .OfType<UnidirectionalAssociation>()
                                                                            .Where(x => x.Persistent && !x.Target.IsDependentType))
               {
                  if (visited.Contains(association))
                     continue;

                  visited.Add(association);

                  List<string> segments = new List<string>();
                  bool required = false;

                  segments.Add($"modelBuilder.Entity<{modelClass.FullName}>()");

                  switch (association.TargetMultiplicity) // realized by property on source
                  {
                     case Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroMany:
                        segments.Add($"HasMany<{association.Target.FullName}>(p => p.{association.TargetPropertyName})");

                        break;

                     case Sawczyn.EFDesigner.EFModel.Multiplicity.One:
                        segments.Add($"HasOne<{association.Target.FullName}>(p => p.{association.TargetPropertyName})");
                        required = (modelClass == association.Principal);

                        break;

                     case Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroOne:
                        segments.Add($"HasOne<{association.Target.FullName}>(p => p.{association.TargetPropertyName})");

                        break;
                  }

                  switch (association.SourceMultiplicity) // realized by property on target, but no property on target
                  {
                     case Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroMany:
                        segments.Add("WithMany()");

                        if (association.TargetMultiplicity == Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroMany)
                        {
                           string tableMap = string.IsNullOrEmpty(association.JoinTableName)
                                                ? $"{association.Target.Name}_x_{association.Source.Name}_{association.TargetPropertyName}"
                                                : association.JoinTableName;

                           segments.Add($"UsingEntity(x => x.ToTable(\"{tableMap}\"))");
                        }

                        break;

                     case Sawczyn.EFDesigner.EFModel.Multiplicity.One:
                        segments.Add("WithOne()");
                        required = (modelClass == association.Principal);

                        break;

                     case Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroOne:
                        segments.Add("WithOne()");

                        break;
                  }

                  string foreignKeySegment = CreateForeignKeySegment(association, foreignKeyColumns);

                  if (!string.IsNullOrEmpty(foreignKeySegment))
                     segments.Add(foreignKeySegment);

                  if (!association.Source.IsDependentType && !association.Target.IsDependentType
                   && (association.TargetRole == EndpointRole.Principal || association.SourceRole == EndpointRole.Principal))
                  {
                     DeleteAction deleteAction = association.SourceRole == EndpointRole.Principal
                                                    ? association.SourceDeleteAction
                                                    : association.TargetDeleteAction;

                     switch (deleteAction)
                     {
                        case DeleteAction.None:
                           segments.Add("OnDelete(DeleteBehavior.NoAction)");

                           break;

                        case DeleteAction.Cascade:
                           segments.Add("OnDelete(DeleteBehavior.Cascade)");

                           break;
                     }
                  }

                  if (required
                   && (association.SourceMultiplicity != Sawczyn.EFDesigner.EFModel.Multiplicity.One
                    || association.TargetMultiplicity != Sawczyn.EFDesigner.EFModel.Multiplicity.One))
                     segments.Add("IsRequired()");

                  Output(segments);
               }
            }

            void MakeDependentAssociations(ModelClass sourceInstance, string baseSegment)
            {
               // ReSharper disable once LoopCanBePartlyConvertedToQuery
               foreach (UnidirectionalAssociation association in Association.GetLinksToTargets(sourceInstance)
                                                                            .OfType<UnidirectionalAssociation>()
                                                                            .Where(x => x.Persistent && x.Target.IsDependentType))
               {
                  if (visited.Contains(association))
                     continue;

                  visited.Add(association);

                  List<string> segments = new List<string>();

                  switch (association.TargetMultiplicity) // realized by property on source
                  {
                     case Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroMany:
                     {
                        segments.Add(baseSegment);
                        segments.Add($"OwnsMany(p => p.{association.TargetPropertyName})");
                        segments.Add($"WithOwner(\"{association.Source.Name}_{association.TargetPropertyName}\")");
                        segments.Add($"HasForeignKey(\"{association.Source.Name}_{association.TargetPropertyName}Id\")");
                        Output(segments);

                        segments.Add(baseSegment);
                        segments.Add($"OwnsMany(p => p.{association.TargetPropertyName})");
                        segments.Add("Property<int>(\"Id\")");

                        Output(segments);

                        segments.Add(baseSegment);
                        segments.Add($"OwnsMany(p => p.{association.TargetPropertyName})");
                        segments.Add("HasKey(\"Id\")");

                        Output(segments);

                        MakeDependentAssociations(association.Target, $"{baseSegment}.OwnsMany(p => p.{association.TargetPropertyName})");

                        break;
                     }

                     case Sawczyn.EFDesigner.EFModel.Multiplicity.One:
                     {
                        foreach (ModelAttribute modelAttribute in association.Target.AllAttributes)
                        {
                           segments.Add($"{baseSegment}.OwnsOne(p => p.{association.TargetPropertyName}).Property(p => p.{modelAttribute.Name})");

                           if (modelAttribute.ColumnName != modelAttribute.Name)
                              segments.Add($"HasColumnName(\"{modelAttribute.ColumnName}\")");

                           if (modelAttribute.Required)
                              segments.Add("IsRequired()");

                           Output(segments);
                        }

                        segments.Add(baseSegment);
                        segments.Add($"Navigation(p => p.{association.TargetPropertyName}).IsRequired()");
                        Output(segments);

                        MakeDependentAssociations(association.Target, $"{baseSegment}.OwnsOne(p => p.{association.TargetPropertyName})");

                        break;
                     }

                     case Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroOne:
                     {
                        foreach (ModelAttribute modelAttribute in association.Target.AllAttributes)
                        {
                           segments.Add($"{baseSegment}.OwnsOne(p => p.{association.TargetPropertyName}).Property(p => p.{modelAttribute.Name})");

                           if (modelAttribute.ColumnName != modelAttribute.Name)
                              segments.Add($"HasColumnName(\"{modelAttribute.ColumnName}\")");

                           if (modelAttribute.Required)
                              segments.Add("IsRequired()");

                           Output(segments);
                        }

                        MakeDependentAssociations(association.Target, $"{baseSegment}.OwnsOne(p => p.{association.TargetPropertyName})");

                        break;
                     }
                  }
               }
            }
         }

         [SuppressMessage("ReSharper", "RedundantNameQualifier")]
         protected virtual string CreateForeignKeySegment(Association association, List<string> foreignKeyColumns)
         {
            if (association.Principal == null || association.Dependent == null)
               return null;

            List<string> foreignKeys = GetForeignKeys(association, foreignKeyColumns).ToList();

            if (!foreignKeys.Any())
               return null;

            bool dependentClassRequired = (association.SourceMultiplicity != Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroMany && association.TargetMultiplicity != Sawczyn.EFDesigner.EFModel.Multiplicity.ZeroMany);
            string keyList = string.Join(",", foreignKeys);

            if (!foreignKeys.First().StartsWith("\""))
            {
               // foreign keys are real properties
               keyList = foreignKeys.Count == 1
                            ? $"k => {keyList}"
                            : $"k => new {{ {keyList} }}";

               return dependentClassRequired
                         ? $"HasForeignKey<{association.Dependent.Name}>({keyList})"
                         : $"HasForeignKey({keyList})";
            }

            // foreign keys are shadow properties
            return dependentClassRequired
                      ? $"HasForeignKey({'"'}{association.Dependent.Name}{'"'}, {keyList})"
                      : $"HasForeignKey({keyList})";
         }

         public override void Generate(Manager manager)
         {
            // Entities
            string fileNameMarker = string.IsNullOrEmpty(modelRoot.FileNameMarker) ? string.Empty : $".{modelRoot.FileNameMarker}";

            foreach (ModelClass modelClass in modelRoot.Classes.Where(e => e.GenerateCode))
            {
               manager.StartNewFile(Path.Combine(modelClass.EffectiveOutputDirectory, $"{modelClass.Name}{fileNameMarker}.cs"));

               WriteClass(modelClass);
            }

            // Enums

            foreach (ModelEnum modelEnum in modelRoot.Enums.Where(e => e.GenerateCode))
            {
               manager.StartNewFile(Path.Combine(modelEnum.EffectiveOutputDirectory, $"{modelEnum.Name}{fileNameMarker}.cs"));
               WriteEnum(modelEnum);
            }

            manager.StartNewFile(Path.Combine(modelRoot.ContextOutputDirectory, $"{modelRoot.EntityContainerName}{fileNameMarker}.cs"));
            WriteDbContext();
         }

         protected override List<string> GetAdditionalUsingStatements()
         {
            List<string> result = new List<string>();
            List<string> attributeTypes = modelRoot.Classes.SelectMany(c => c.Attributes).Select(a => a.Type).Distinct().ToList();

            if (attributeTypes.Intersect(modelRoot.SpatialTypes).Any())
               result.Add("using NetTopologySuite.Geometries;");

            return result;
         }

         [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
         protected virtual IEnumerable<string> GetForeignKeys(Association association, List<string> foreignKeyColumns)
         {
            // final collection of foreign key property names, real or shadow
            // shadow properties will be double quoted, real properties won't
            IEnumerable<string> result = null;

            // foreign key definitions always go in the table representing the Dependent end of the association
            // if there is no dependent end (i.e., many-to-many), there are no foreign keys
            ModelClass principal = association.Principal;
            ModelClass dependent = association.Dependent;

            if (principal != null && dependent != null)
            {
               if (string.IsNullOrWhiteSpace(association.FKPropertyName))
                  result = principal.IdentityAttributes.Select(identity => $"{'"'}{CreateShadowPropertyName(association, foreignKeyColumns, identity)}{'"'}");
               else
               {
                  // defined properties
                  result = association.FKPropertyName.Split(',').Select(prop => "k." + prop.Trim());
                  foreignKeyColumns.AddRange(result);
               }
            }

            return result;
         }

         protected void WriteContextConstructors()
         {
            if (!string.IsNullOrEmpty(modelRoot.ConnectionString) || !string.IsNullOrEmpty(modelRoot.ConnectionStringName))
            {
               string connectionString = string.IsNullOrEmpty(modelRoot.ConnectionString)
                                            ? $"Name={modelRoot.ConnectionStringName}"
                                            : modelRoot.ConnectionString;

               Output("/// <summary>");
               Output("/// Default connection string");
               Output("/// </summary>");
               Output($"public static string ConnectionString {{ get; set; }} = @\"{connectionString}\";");
               NL();
            }

            Output("/// <inheritdoc />");
            Output($"public {modelRoot.EntityContainerName}(DbContextOptions<{modelRoot.EntityContainerName}> options) : base(options)");
            Output("{");
            Output("}");
            NL();

            Output("partial void CustomInit(DbContextOptionsBuilder optionsBuilder);");
            NL();
         }

         protected void WriteDbContext()
         {
            List<string> segments = new List<string>();
            ModelClass[] classesWithTables = null;

            // Note: TablePerConcreteType not yet available, but it doesn't hurt for it to be here since they shouldn't make it past the designer's validations
            switch (modelRoot.InheritanceStrategy)
            {
               case CodeStrategy.TablePerType:
                  classesWithTables = modelRoot.Classes.Where(mc => (!mc.IsDependentType || !string.IsNullOrEmpty(mc.TableName)) && mc.GenerateCode).OrderBy(x => x.Name).ToArray();

                  break;

               case CodeStrategy.TablePerConcreteType:
                  classesWithTables = modelRoot.Classes.Where(mc => (!mc.IsDependentType || !string.IsNullOrEmpty(mc.TableName)) && !mc.IsAbstract && mc.GenerateCode).OrderBy(x => x.Name).ToArray();

                  break;

               case CodeStrategy.TablePerHierarchy:
                  classesWithTables = modelRoot.Classes.Where(mc => (!mc.IsDependentType || !string.IsNullOrEmpty(mc.TableName)) && mc.Superclass == null && mc.GenerateCode).OrderBy(x => x.Name)
                                               .ToArray();

                  break;
            }

            Output("using System;");
            Output("using System.Collections.Generic;");
            Output("using System.Linq;");
            Output("using System.ComponentModel.DataAnnotations.Schema;");
            Output("using Microsoft.EntityFrameworkCore;");
            NL();

            BeginNamespace(modelRoot.Namespace);

            WriteDbContextComments();

            string baseClass = string.IsNullOrWhiteSpace(modelRoot.BaseClass) ? "Microsoft.EntityFrameworkCore.DbContext" : modelRoot.BaseClass;
            Output($"{modelRoot.EntityContainerAccess.ToString().ToLower()} partial class {modelRoot.EntityContainerName} : {baseClass}");
            Output("{");

            if (classesWithTables?.Any() == true)
               WriteDbSets();

            WriteContextConstructors();
            WriteOnConfiguring(segments);
            WriteOnModelCreate(segments, classesWithTables);

            Output("}");

            EndNamespace(modelRoot.Namespace);
         }

         protected void WriteDbSets()
         {
            Output("#region DbSets");
            PluralizationService pluralizationService = ModelRoot.PluralizationService;

            foreach (ModelClass modelClass in modelRoot.Classes.Where(x => !x.IsDependentType).OrderBy(x => x.Name))
            {
               string dbSetName;

               if (!string.IsNullOrEmpty(modelClass.DbSetName))
                  dbSetName = modelClass.DbSetName;
               else
               {
                  dbSetName = pluralizationService?.IsSingular(modelClass.Name) == true
                                 ? pluralizationService.Pluralize(modelClass.Name)
                                 : modelClass.Name;
               }

               if (!string.IsNullOrEmpty(modelClass.Summary))
               {
                  NL();
                  Output("/// <summary>");
                  WriteCommentBody($"Repository for {modelClass.FullName} - {modelClass.Summary}");
                  Output("/// </summary>");
               }

               Output($"{modelRoot.DbSetAccess.ToString().ToLower()} virtual Microsoft.EntityFrameworkCore.DbSet<{modelClass.FullName}> {dbSetName} {{ get; set; }}");
            }

            NL();
            Output("#endregion DbSets");
            NL();
         }

         protected void WriteOnConfiguring(List<string> segments)
         {
            Output("/// <inheritdoc />");
            Output("protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)");
            Output("{");

            segments.Clear();

            if (modelRoot.GetEntityFrameworkPackageVersionNum() >= 2.1 && modelRoot.LazyLoadingEnabled)
               segments.Add("UseLazyLoadingProxies()");

            if (segments.Any())
            {
               segments.Insert(0, "optionsBuilder");

               Output(segments);
               NL();
            }

            Output("CustomInit(optionsBuilder);");
            Output("}");
            NL();
         }

         protected void WriteOnModelCreate(List<string> segments, ModelClass[] classesWithTables)
         {
            Output("partial void OnModelCreatingImpl(ModelBuilder modelBuilder);");
            Output("partial void OnModelCreatedImpl(ModelBuilder modelBuilder);");
            NL();

            Output("/// <inheritdoc />");
            Output("protected override void OnModelCreating(ModelBuilder modelBuilder)");
            Output("{");
            Output("base.OnModelCreating(modelBuilder);");
            Output("OnModelCreatingImpl(modelBuilder);");
            NL();

            if (!string.IsNullOrEmpty(modelRoot.DatabaseSchema))
               Output($"modelBuilder.HasDefaultSchema(\"{modelRoot.DatabaseSchema}\");");

            List<Association> visited = new List<Association>();
            List<string> foreignKeyColumns = new List<string>();

            ConfigureModelClasses(segments, classesWithTables, foreignKeyColumns, visited);

            NL();

            Output("OnModelCreatedImpl(modelBuilder);");
            Output("}");
         }
      }

      #endregion Template
   }
}