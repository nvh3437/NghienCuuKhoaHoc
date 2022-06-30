using Newtonsoft.Json;

namespace NghienCuuKhoaHoc.Services
{
    public class Notification
    {
        public Notification() { }
        public Notification(NotificationType type, string message)
        {
            Type = type;
            Message = message;
        }
        public NotificationType Type { get; set; }
        public string Message { get; set; }
        public void Change(NotificationType type, string message)
        {
            Type = type;
            Message = message;
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public Notification ToNotification(string TempData)
        {
            return JsonConvert.DeserializeObject<Notification>(TempData);
        }
        public string GetClass()
        {
            switch (Type)
            {
                case NotificationType.Warning: return "alert-warning";
                case NotificationType.Success: return "alert-success";
                default: return "alert-danger";
            }
        }
    }
    public enum NotificationType
    {
        Danger,
        Warning,
        Success
    }
    public static class NotificationExtend
    {
        public static Notification ToNotification(this string TempData)
        {
            return JsonConvert.DeserializeObject<Notification>(TempData);
        }
    }
}
