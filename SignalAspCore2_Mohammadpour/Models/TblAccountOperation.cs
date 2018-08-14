using System;
using System.Collections.Generic;

namespace SignalAspCore2_Mohammadpour.Models
{
    public partial class TblAccountOperation
    {
        public int Id { get; set; }
        public int? Operationamount { get; set; }
        public DateTime? Operationdate { get; set; }
        public bool? OperationType { get; set; }
        public int? TblAccountId { get; set; }

        public TblAccount TblAccount { get; set; }
    }
}
