using QASupporter.Domain.SharedKernel;
using System;

namespace QASupporter.Application.CqrsHandlers.ReadModels
{
    public class UserInfoDto : BaseResponseObject
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}