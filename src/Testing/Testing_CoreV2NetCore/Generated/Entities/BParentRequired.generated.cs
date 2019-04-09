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

namespace Testing_CoreV2NetCore
{
   public partial class BParentRequired
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected BParentRequired()
      {
         BChildCollection = new System.Collections.Generic.HashSet<Testing_CoreV2NetCore.BChild>();

         Init();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="bchildrequired"></param>
      public BParentRequired(Testing_CoreV2NetCore.BChild bchildrequired)
      {
         if (bchildrequired == null) throw new ArgumentNullException(nameof(bchildrequired));
         BChildRequired = bchildrequired;

         BChildCollection = new System.Collections.Generic.HashSet<Testing_CoreV2NetCore.BChild>();
         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="bchildrequired"></param>
      public static BParentRequired Create(Testing_CoreV2NetCore.BChild bchildrequired)
      {
         return new BParentRequired(bchildrequired);
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

      public virtual Testing_CoreV2NetCore.BChild BChildOptional { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      public virtual Testing_CoreV2NetCore.BChild BChildRequired { get; set; }

      public virtual ICollection<Testing_CoreV2NetCore.BChild> BChildCollection { get; private set; }

   }
}

