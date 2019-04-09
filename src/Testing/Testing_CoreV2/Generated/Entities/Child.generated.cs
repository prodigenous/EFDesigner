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
   public partial class Child : INotifyPropertyChanged
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected Child()
      {
         Children = new System.Collections.Generic.HashSet<Testing.Child>();

         Init();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="parent"></param>
      /// <param name="_master0"></param>
      public Child(Testing.Child parent, Testing.Master _master0)
      {
         if (parent == null) throw new ArgumentNullException(nameof(parent));
         Parent = parent;

         if (_master0 == null) throw new ArgumentNullException(nameof(_master0));
         _master0.Children.Add(this);

         Children = new System.Collections.Generic.HashSet<Testing.Child>();
         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="parent"></param>
      /// <param name="_master0"></param>
      public static Child Create(Testing.Child parent, Testing.Master _master0)
      {
         return new Child(parent, _master0);
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

      public virtual ICollection<Testing.Child> Children { get; private set; }

      protected Testing.Child _Parent;
      partial void SetParent(Testing.Child oldValue, ref Testing.Child newValue);
      partial void GetParent(ref Testing.Child result);

      /// <summary>
      /// Required
      /// </summary>
      public virtual Testing.Child Parent
      {
         get
         {
            Testing.Child value = _Parent;
            GetParent(ref value);
            return (_Parent = value);
         }
         set
         {
            Testing.Child oldValue = _Parent;
            SetParent(oldValue, ref value);
            if (oldValue != value)
            {
               _Parent = value;
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

