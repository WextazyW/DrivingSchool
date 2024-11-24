//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DrivingSchool.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cars
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cars()
        {
            this.MaintenanceHistory = new HashSet<MaintenanceHistory>();
        }
    
        public int CarID { get; set; }
        public string LicensePlate { get; set; }
        public string Status { get; set; }
        public Nullable<int> InstructorID { get; set; }
        public string Model { get; set; }
        public Nullable<int> Year { get; set; }
    
        public virtual Instructors Instructors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceHistory> MaintenanceHistory { get; set; }
    }
}
