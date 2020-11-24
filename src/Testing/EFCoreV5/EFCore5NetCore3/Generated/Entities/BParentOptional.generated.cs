//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v3.0.0.4
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

namespace Testing
{
   public partial class BParentOptional
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected BParentOptional()
      {
         BChildCollection = new System.Collections.Generic.HashSet<global::Testing.BChild>();
         BChildRequired = global::Testing.BChild.CreateBChildUnsafe();
         BChildOptional = global::Testing.BChild.CreateBChildUnsafe();

         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static BParentOptional CreateBParentOptionalUnsafe()
      {
         return new BParentOptional();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="bchildrequired"></param>
      public BParentOptional(global::Testing.BChild bchildrequired)
      {
         if (bchildrequired == null) throw new ArgumentNullException(nameof(bchildrequired));
         this.BChildRequired = bchildrequired;

         this.BChildCollection = new System.Collections.Generic.HashSet<global::Testing.BChild>();

         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="bchildrequired"></param>
      public static BParentOptional Create(global::Testing.BChild bchildrequired)
      {
         return new BParentOptional(bchildrequired);
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

      protected global::Testing.BChild _bChildRequired;
      partial void SetBChildRequired(global::Testing.BChild oldValue, ref global::Testing.BChild newValue);
      partial void GetBChildRequired(ref global::Testing.BChild result);

      /// <summary>
      /// Required
      /// </summary>
      public virtual global::Testing.BChild BChildRequired
      {
         get
         {
            global::Testing.BChild value = _bChildRequired;
            GetBChildRequired(ref value);
            return (_bChildRequired = value);
         }
         set
         {
            global::Testing.BChild oldValue = _bChildRequired;
            SetBChildRequired(oldValue, ref value);
            if (oldValue != value)
            {
               _bChildRequired = value;
            }
         }
      }

      protected ICollection<global::Testing.BChild> _bChildCollection;
      public virtual ICollection<global::Testing.BChild> BChildCollection
      {
         get
         {
            return _bChildCollection;
         }
         private set
         {
            _bChildCollection = value;
         }
      }

      protected global::Testing.BChild _bChildOptional;
      partial void SetBChildOptional(global::Testing.BChild oldValue, ref global::Testing.BChild newValue);
      partial void GetBChildOptional(ref global::Testing.BChild result);

      public virtual global::Testing.BChild BChildOptional
      {
         get
         {
            global::Testing.BChild value = _bChildOptional;
            GetBChildOptional(ref value);
            return (_bChildOptional = value);
         }
         set
         {
            global::Testing.BChild oldValue = _bChildOptional;
            SetBChildOptional(oldValue, ref value);
            if (oldValue != value)
            {
               _bChildOptional = value;
            }
         }
      }

   }
}

