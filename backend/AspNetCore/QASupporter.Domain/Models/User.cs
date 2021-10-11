using QASupporter.Domain.SharedKernel;

namespace QASupporter.Domain.Models
{
    public partial class User : AuditableEntity<int>, IAggregateRoot
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
