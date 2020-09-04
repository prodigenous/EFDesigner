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
   public partial class BParentCollection
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected BParentCollection()
      {
         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static BParentCollection CreateBParentCollectionUnsafe()
      {
         return new BParentCollection();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="bchildrequired"></param>
      public BParentCollection(global::Testing.BChild bchildrequired)
      {
         if (bchildrequired == null) throw new ArgumentNullException(nameof(bchildrequired));
         this.BChildRequired = bchildrequired;


         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="bchildrequired"></param>
      public static BParentCollection Create(global::Testing.BChild bchildrequired)
      {
         return new BParentCollection(bchildrequired);
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Backing field for Id
      /// </summary>
      internal int _id;
      /// <summary>
      /// When provided in a partial class, allows value of Id to be changed before setting.
      /// </summary>
      partial void SetId(int oldValue, ref int newValue);
      /// <summary>
      /// When provided in a partial class, allows value of Id to be changed before returning.
      /// </summary>
      partial void GetId(ref int result);

      /// <summary>
      /// Identity, Indexed, Required
      /// </summary>
      [Key]
      [Required]
      public int Id
      {
         get
         {
            int value = _id;
            GetId(ref value);
            return (_id = value);
         }
         protected set
         {
            int oldValue = _id;
            SetId(oldValue, ref value);
            if (oldValue != value)
            {
               _id = value;
            }
         }
      }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      /// <summary>
      /// Required
      /// </summary>
      public virtual global::Testing.BChild BChildRequired { get; set; }

      public virtual global::Testing.BChild BChildOptional { get; set; }

   }
}

