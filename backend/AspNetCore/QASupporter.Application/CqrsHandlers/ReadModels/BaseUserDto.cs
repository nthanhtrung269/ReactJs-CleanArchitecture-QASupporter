using QASupporter.Domain.SharedKernel;

namespace QASupporter.Application.CqrsHandlers.ReadModels
{
    public class BaseUserDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}