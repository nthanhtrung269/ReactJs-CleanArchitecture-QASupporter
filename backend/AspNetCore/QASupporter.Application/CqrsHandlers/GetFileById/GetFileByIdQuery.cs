using QASupporter.Application.Configuration.Queries;
using QASupporter.Application.CqrsHandlers.ReadModels;

namespace QASupporter.Application.CqrsHandlers.GetFileById
{
    public class GetFileByIdQuery : IQuery<BaseFileDto>
    {
        public int Id { get; }

        public GetFileByIdQuery(int id)
        {
            Id = id;
        }
    }
}
