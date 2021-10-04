using QASupporter.Application.Configuration.Queries;
using QASupporter.Application.CqrsHandlers.ReadModels;
using System.Collections.Generic;

namespace QASupporter.Application.CqrsHandlers.GetAllUsers
{
    public class GetAllUsersQuery : IQuery<IList<BaseUserDto>>
    {
        public GetAllUsersQuery()
        {
        }
    }
}
