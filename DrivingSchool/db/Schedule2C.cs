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
    
    public partial class Schedule2C
    {
        public int id { get; set; }
        public Nullable<int> studentId { get; set; }
        public Nullable<int> teacherId { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
    
        public virtual Students Students { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
