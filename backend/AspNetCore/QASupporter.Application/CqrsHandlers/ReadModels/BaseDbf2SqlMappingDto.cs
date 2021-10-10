using System;

namespace QASupporter.Application.CqrsHandlers.ReadModels
{
    public class BaseDbf2SqlMappingDto
    {
        public int Dbf2SqlMappingId { get; set; }

        public string FoxproTable { get; set; }

        public string FoxproColumn { get; set; }

        public string SqlTable { get; set; }

        public string SqlColumn { get; set; }

        public string Notes { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}