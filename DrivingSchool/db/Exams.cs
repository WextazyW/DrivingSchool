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
    
    public partial class Exams
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exams()
        {
            this.Results = new HashSet<Results>();
        }
    
        public int ExamID { get; set; }
        public System.DateTime ExamDate { get; set; }
        public Nullable<int> ExamPoints { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Results> Results { get; set; }
    }
}
