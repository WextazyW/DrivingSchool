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
    
    public partial class Courses
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public Nullable<int> DurationHours { get; set; }
        public string Category { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}
