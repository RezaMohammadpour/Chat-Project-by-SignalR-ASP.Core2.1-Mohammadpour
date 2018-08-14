using System;
using System.Collections.Generic;

namespace SignalAspCore2_Mohammadpour.Models
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblAccount = new HashSet<TblAccount>();
            TblTel = new HashSet<TblTel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int? Tel { get; set; }

        public ICollection<TblAccount> TblAccount { get; set; }
        public ICollection<TblTel> TblTel { get; set; }
    }
}
