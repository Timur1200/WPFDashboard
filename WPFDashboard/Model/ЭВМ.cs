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
    
    public partial class ЭВМ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ЭВМ()
        {
            this.Заявки = new HashSet<Заявки>();
        }
    
        public int Код { get; set; }
        public Nullable<int> КодПоставщика { get; set; }
        public Nullable<int> КодКабинета { get; set; }
        public string Имя { get; set; }
        public string Модель { get; set; }
        public string Процессор { get; set; }
        public string Монитор { get; set; }
        public string ОЗУ { get; set; }
        public string ЖесткийДиск { get; set; }
        public string Графика { get; set; }
        public string БлокПитания { get; set; }
        public Nullable<bool> Ремонт { get; set; }
        public Nullable<bool> Списан { get; set; }
        public Nullable<System.DateTime> ДатаСписания { get; set; }
        public Nullable<System.DateTime> Гарантия { get; set; }
        public Nullable<System.DateTime> ДатаНачала { get; set; }
        public string Причина { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заявки> Заявки { get; set; }
        public virtual Кабинет Кабинет { get; set; }
        public virtual Поставщик Поставщик { get; set; }
    }
}
