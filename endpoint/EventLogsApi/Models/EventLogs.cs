using System.ComponentModel.DataAnnotations;

namespace EventLogsApi.Models
{
    public class EventLogs
    {
        [Key]
        public int EventID { get; set; }
        public string EventType { get; set; }
        [Required(ErrorMessage = "The EventDescription field is required.")]
        public string EventDescription { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
