using QASupporter.Domain.SharedKernel;
using System;

namespace QASupporter.Domain.Models
{
    public partial class Dbf2SqlMapping : Entity<int>, IAggregateRoot
    {
        public string FoxproTable { get; set; }

        public string FoxproColumn { get; set; }

        public string SqlTable { get; set; }

        public string SqlColumn { get; set; }

        public string Notes { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
