using System;
using System.Collections.Generic;
using System.Text;

namespace TalentFlow.Application.Common.Models
{
    public class NotificationMessage
    {
        public Guid UserId { get; set; }   // ✅ aligns with Notification entity FK
        public string DeepLinkUrl { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }

}
