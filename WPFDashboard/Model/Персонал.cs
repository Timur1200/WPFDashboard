//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFDashboard.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Персонал
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Персонал()
        {
            this.Заявки = new HashSet<Заявки>();
        }
    
        public int Код { get; set; }
        public Nullable<int> КодКабинета { get; set; }
        public string Фио { get; set; }
        public Nullable<System.DateTime> ДатаРождения { get; set; }
        public string Адрес { get; set; }
        public string Телефон { get; set; }
        public string Пароль { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заявки> Заявки { get; set; }
        public virtual Кабинет Кабинет { get; set; }
    }
}
