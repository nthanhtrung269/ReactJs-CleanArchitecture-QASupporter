using System;

namespace QASupporter.Application.CqrsHandlers.WriteModels
{
    public class Dbf2SqlMappingDto
    {
        public int Id { get; set; }

        public string FoxproTable { get; set; }

        public string FoxproColumn { get; set; }

        public string SqlTable { get; set; }

        public string SqlColumn { get; set; }

        public string Notes { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}