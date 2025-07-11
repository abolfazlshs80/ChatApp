using System.ComponentModel.DataAnnotations;

namespace ChatApp.Domain.Enums
{
    public enum UserStatus
    {
        [Display(Name = "فعال")]
        Active,
        [Display(Name = "غیرفعال")]
        Blocked,
        [Display(Name = "در انتظار تایید ادمین")]
        AwaitingApproval,
        [Display(Name = "محدود شده")]
        Limited,
        [Display(Name = "کاربر جدید")]
        NewUser,
        [Display(Name = "احراز هویت رد شده")]
        FailedRequest
    }
}
