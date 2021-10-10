namespace QASupporter.Application.CqrsHandlers.WriteModels
{
    public class Dbf2SqlMappingDto
    {
        public int Dbf2SqlMappingId { get; set; }

        public string FoxproTable { get; set; }

        public string FoxproColumn { get; set; }

        public string SqlTable { get; set; }

        public string SqlColumn { get; set; }

        public string Notes { get; set; }
    }
}