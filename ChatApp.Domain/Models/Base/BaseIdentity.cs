using Microsoft.AspNetCore.Identity;

namespace Project.Domain.Entities.Base
{
    public class BaseIdentity : IdentityUser<string>
    {
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool IsExisting { get; set; } = true;
    }
}

