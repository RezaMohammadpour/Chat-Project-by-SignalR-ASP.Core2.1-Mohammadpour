using System;
using System.Collections.Generic;

namespace SignalAspCore2_Mohammadpour.Models
{
    public partial class TblAccount
    {
        public TblAccount()
        {
            TblAccountOperation = new HashSet<TblAccountOperation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int? TblEmployeeId { get; set; }

        public TblEmployee TblEmployee { get; set; }
        public ICollection<TblAccountOperation> TblAccountOperation { get; set; }
    }
}
