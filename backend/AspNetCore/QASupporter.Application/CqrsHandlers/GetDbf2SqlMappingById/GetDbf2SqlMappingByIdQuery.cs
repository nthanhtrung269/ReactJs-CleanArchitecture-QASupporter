using QASupporter.Application.Configuration.Queries;
using QASupporter.Application.CqrsHandlers.ReadModels;

namespace QASupporter.Application.CqrsHandlers.GetDbf2SqlMappingById
{
    public class GetDbf2SqlMappingByIdQuery : IQuery<BaseDbf2SqlMappingDto>
    {
        public int Id { get; }

        public GetDbf2SqlMappingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
