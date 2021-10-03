using QASupporter.Application.Configuration.Queries;
using QASupporter.Application.CqrsHandlers.ReadModels;
using System.Collections.Generic;

namespace QASupporter.Application.CqrsHandlers.GetAllDbf2SqlMappingByKeyword
{
    public class GetAllDbf2SqlMappingByKeywordQuery : IQuery<IList<BaseDbf2SqlMappingDto>>
    {
        public string Keyword { get; }
        public string ModifiedBy { get; }

        public GetAllDbf2SqlMappingByKeywordQuery(string keyword, string modifiedBy)
        {
            Keyword = keyword;
            ModifiedBy = modifiedBy;
        }
    }
}
