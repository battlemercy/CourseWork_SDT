//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElectronicDiary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Homework
    {
        public int ID { get; set; }
        public Nullable<int> Subject_ID { get; set; }
        public Nullable<int> Teacher_ID { get; set; }
        public string Task { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
