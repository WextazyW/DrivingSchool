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
    
    public partial class Results
    {
        public int ResultID { get; set; }
        public Nullable<int> ExamID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public int Score { get; set; }
        public bool Passed { get; set; }
    
        public virtual Exams Exams { get; set; }
        public virtual Students Students { get; set; }
    }
}