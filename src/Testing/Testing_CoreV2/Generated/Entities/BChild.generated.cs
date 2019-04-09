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
   public partial class BChild : INotifyPropertyChanged
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected BChild()
      {
         BParentCollection = new System.Collections.Generic.HashSet<Testing.BParentCollection>();
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
      /// Backing field for Id
      /// </summary>
      protected int _Id;
      /// <summary>
      /// When provided in a partial class, allows value of Id to be changed before setting.
      /// </summary>
      partial void SetId(int oldValue, ref int newValue);
      /// <summary>
      /// When provided in a partial class, allows value of Id to be changed before returning.
      /// </summary>
      partial void GetId(ref int result);

      /// <summary>
      /// Identity, Required, Indexed
      /// </summary>
      [Key]
      [Required]
      public int Id
      {
         get
         {
            int value = _Id;
            GetId(ref value);
            return (_Id = value);
         }
         set
         {
            int oldValue = _Id;
            SetId(oldValue, ref value);
            if (oldValue != value)
            {
               _Id = value;
               OnPropertyChanged();
            }
         }
      }

      /*************************************************************************
       * Persistent navigation properties
       *************************************************************************/

      protected Testing.BParentRequired _BParentRequired;
      partial void SetBParentRequired(Testing.BParentRequired oldValue, ref Testing.BParentRequired newValue);
      partial void GetBParentRequired(ref Testing.BParentRequired result);

      /// <summary>
      /// Required
      /// </summary>
      public virtual Testing.BParentRequired BParentRequired
      {
         get
         {
            Testing.BParentRequired value = _BParentRequired;
            GetBParentRequired(ref value);
            return (_BParentRequired = value);
         }
         set
         {
            Testing.BParentRequired oldValue = _BParentRequired;
            SetBParentRequired(oldValue, ref value);
            if (oldValue != value)
            {
               _BParentRequired = value;
               OnPropertyChanged();
            }
         }
      }

      protected Testing.BParentRequired _BParentRequired_1;
      partial void SetBParentRequired_1(Testing.BParentRequired oldValue, ref Testing.BParentRequired newValue);
      partial void GetBParentRequired_1(ref Testing.BParentRequired result);

      /// <summary>
      /// Required
      /// </summary>
      public virtual Testing.BParentRequired BParentRequired_1
      {
         get
         {
            Testing.BParentRequired value = _BParentRequired_1;
            GetBParentRequired_1(ref value);
            return (_BParentRequired_1 = value);
         }
         set
         {
            Testing.BParentRequired oldValue = _BParentRequired_1;
            SetBParentRequired_1(oldValue, ref value);
            if (oldValue != value)
            {
               _BParentRequired_1 = value;
               OnPropertyChanged();
            }
         }
      }

      protected Testing.BParentRequired _BParentRequired_2;
      partial void SetBParentRequired_2(Testing.BParentRequired oldValue, ref Testing.BParentRequired newValue);
      partial void GetBParentRequired_2(ref Testing.BParentRequired result);

      /// <summary>
      /// Required
      /// </summary>
      public virtual Testing.BParentRequired BParentRequired_2
      {
         get
         {
            Testing.BParentRequired value = _BParentRequired_2;
            GetBParentRequired_2(ref value);
            return (_BParentRequired_2 = value);
         }
         set
         {
            Testing.BParentRequired oldValue = _BParentRequired_2;
            SetBParentRequired_2(oldValue, ref value);
            if (oldValue != value)
            {
               _BParentRequired_2 = value;
               OnPropertyChanged();
            }
         }
      }

      public virtual ICollection<Testing.BParentCollection> BParentCollection { get; private set; }

      public virtual ICollection<Testing.BParentCollection> BParentCollection_2 { get; private set; }

      protected Testing.BParentOptional _BParentOptional;
      partial void SetBParentOptional(Testing.BParentOptional oldValue, ref Testing.BParentOptional newValue);
      partial void GetBParentOptional(ref Testing.BParentOptional result);

      public virtual Testing.BParentOptional BParentOptional
      {
         get
         {
            Testing.BParentOptional value = _BParentOptional;
            GetBParentOptional(ref value);
            return (_BParentOptional = value);
         }
         set
         {
            Testing.BParentOptional oldValue = _BParentOptional;
            SetBParentOptional(oldValue, ref value);
            if (oldValue != value)
            {
               _BParentOptional = value;
               OnPropertyChanged();
            }
         }
      }

      protected Testing.BParentOptional _BParentOptional_1;
      partial void SetBParentOptional_1(Testing.BParentOptional oldValue, ref Testing.BParentOptional newValue);
      partial void GetBParentOptional_1(ref Testing.BParentOptional result);

      public virtual Testing.BParentOptional BParentOptional_1
      {
         get
         {
            Testing.BParentOptional value = _BParentOptional_1;
            GetBParentOptional_1(ref value);
            return (_BParentOptional_1 = value);
         }
         set
         {
            Testing.BParentOptional oldValue = _BParentOptional_1;
            SetBParentOptional_1(oldValue, ref value);
            if (oldValue != value)
            {
               _BParentOptional_1 = value;
               OnPropertyChanged();
            }
         }
      }

      protected Testing.BParentOptional _BParentOptional_2;
      partial void SetBParentOptional_2(Testing.BParentOptional oldValue, ref Testing.BParentOptional newValue);
      partial void GetBParentOptional_2(ref Testing.BParentOptional result);

      public virtual Testing.BParentOptional BParentOptional_2
      {
         get
         {
            Testing.BParentOptional value = _BParentOptional_2;
            GetBParentOptional_2(ref value);
            return (_BParentOptional_2 = value);
         }
         set
         {
            Testing.BParentOptional oldValue = _BParentOptional_2;
            SetBParentOptional_2(oldValue, ref value);
            if (oldValue != value)
            {
               _BParentOptional_2 = value;
               OnPropertyChanged();
            }
         }
      }

      public virtual event PropertyChangedEventHandler PropertyChanged;

      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }

   }
}

