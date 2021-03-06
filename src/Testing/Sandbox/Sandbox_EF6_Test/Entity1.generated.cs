//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v3.0.0.5
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Sandbox_EF6_Test
{
   public partial class Entity1
   {
      partial void Init();

      /// <summary>
      /// Default constructor
      /// </summary>
      public Entity1()
      {
         Entity2 = new System.Collections.Generic.HashSet<global::Sandbox_EF6_Test.Entity2>();

         Init();
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Identity, Indexed, Required
      /// </summary>
      [Key]
      [Required]
      public int Id { get; protected set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      protected ICollection<global::Sandbox_EF6_Test.Entity2> _entity2;
      public virtual ICollection<global::Sandbox_EF6_Test.Entity2> Entity2
      {
         get
         {
            return _entity2;
         }
         private set
         {
            _entity2 = value;
         }
      }

   }
}

