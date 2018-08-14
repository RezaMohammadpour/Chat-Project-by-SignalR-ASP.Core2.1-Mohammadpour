using System;
using System.Collections.Generic;

namespace SignalAspCore2_Mohammadpour.Models
{
    public partial class TblTel
    {
        public int Id { get; set; }
        public string Tel { get; set; }
        public int? TblEmployeeId { get; set; }

        public TblEmployee TblEmployee { get; set; }
    }
}
