//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiaryWcfService
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.DailyNotes = new HashSet<DailyNotes>();
        }
    
        public System.Guid Guid { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<DailyNotes> DailyNotes { get; set; }
    }
}
