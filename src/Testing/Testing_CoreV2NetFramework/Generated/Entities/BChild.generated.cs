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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Testing
{
   public partial class BChild
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected BChild()
      {
         BParentCollection = new System.Collections.Generic.HashSet<Testing.BParentCollection>();
         BParentCollection_1 = new System.Collections.Generic.HashSet<Testing.BParentCollection>();
         BParentCollection_2 = new System.Collections.Generic.HashSet<Testing.BParentCollection>();

         Init();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="bparentrequired"></param>
      /// <param name="bparentrequired_1"></param>
      /// <param name="bparentrequired_2"></param>
      public BChild(Testing.BParentRequired bparentrequired, Testing.BParentRequired bparentrequired_1, Testing.BParentRequired bparentrequired_2)
      {
         if (bparentrequired == null) throw new ArgumentNullException(nameof(bparentrequired));
         BParentRequired = bparentrequired;

         if (bparentrequired_1 == null) throw new ArgumentNullException(nameof(bparentrequired_1));
         BParentRequired_1 = bparentrequired_1;

         if (bparentrequired_2 == null) throw new ArgumentNullException(nameof(bparentrequired_2));
         BParentRequired_2 = bparentrequired_2;

         BParentCollection = new System.Collections.Generic.HashSet<Testing.BParentCollection>();
         BParentCollection_1 = new System.Collections.Generic.HashSet<Testing.BParentCollection>();
         BParentCollection_2 = new System.Collections.Generic.HashSet<Testing.BParentCollection>();
         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="bparentrequired"></param>
      /// <param name="bparentrequired_1"></param>
      /// <param name="bparentrequired_2"></param>
      public static BChild Create(Testing.BParentRequired bparentrequired, Testing.BParentRequired bparentrequired_1, Testing.BParentRequired bparentrequired_2)
      {
         return new BChild(bparentrequired, bparentrequired_1, bparentrequired_2);
      }

      /*************************************************************************
       * Persistent properties
       *************************************************************************/

      /// <summary>
      /// Identity, Required, Indexed
      /// </summary>
      [Key]
      [Required]
      public int Id { get; set; }

      /*************************************************************************
       * Persistent navigation properties
       *************************************************************************/

      /// <summary>
      /// Required
      /// </summary>
      public virtual Testing.BParentRequired BParentRequired { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      public virtual Testing.BParentRequired BParentRequired_1 { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      public virtual Testing.BParentRequired BParentRequired_2 { get; set; }

      public virtual ICollection<Testing.BParentCollection> BParentCollection { get; private set; }

      public virtual ICollection<Testing.BParentCollection> BParentCollection_1 { get; private set; }

      public virtual ICollection<Testing.BParentCollection> BParentCollection_2 { get; private set; }

      public virtual Testing.BParentOptional BParentOptional { get; set; }

      public virtual Testing.BParentOptional BParentOptional_1 { get; set; }

      public virtual Testing.BParentOptional BParentOptional_2 { get; set; }

   }
}

