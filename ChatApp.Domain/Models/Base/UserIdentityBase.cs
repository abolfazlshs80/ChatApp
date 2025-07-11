
using ChatApp.Domain.Enums;
using Project.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Models.Base
{
    public class UserIdentityBase : BaseIdentity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? VerificationCode { get; set; } = 0;
        public UserStatus? Status { get; set; }

        [NotMapped]
        public string Nickname
        {
            get
            {
                return $"{FirstName} {LastName}".Trim();
            }
        }
    }
}
