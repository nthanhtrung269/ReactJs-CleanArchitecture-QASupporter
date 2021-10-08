using QASupporter.Domain.SharedKernel;

namespace QASupporter.Domain.Models
{
    public partial class Dbf2SqlMapping : AuditableEntity<int>, IAggregateRoot
    {
        public string FoxproTable { get; set; }

        public string FoxproColumn { get; set; }

        public string SqlTable { get; set; }

        public string SqlColumn { get; set; }

        public string Notes { get; set; }
    }
}
