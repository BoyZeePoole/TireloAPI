//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.Subs = new HashSet<Person>();
            this.PersonCourses = new HashSet<PersonCours>();
        }
    
        public System.Guid Id { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string CoyNumber { get; set; }
        public Nullable<System.Guid> fk_Role_Id { get; set; }
        public Nullable<System.Guid> fk_Section_Id { get; set; }
        public Nullable<System.Guid> fk_Manager_Id { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Subs { get; set; }
        public virtual Person Manager { get; set; }
        public virtual Role Role { get; set; }
        public virtual Section Section { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonCours> PersonCourses { get; set; }
    }
}
