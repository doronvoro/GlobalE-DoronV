using System.ComponentModel.DataAnnotations;

namespace GlobalE.BL
{
    public class TimerRequest
    {
        //TODO: if Hours & Minutes & Seconds equals to 0 ?
        [Range(0, 23, ErrorMessage = "Hours must be between 0 and 23.")]
        public int Hours { get; set; }

        [Range(0, 59, ErrorMessage = "Minutes must be between 0 and 59.")]
        public int Minutes { get; set; }

        [Range(0, 59, ErrorMessage = "Seconds must be between 0 and 59.")]
        public int Seconds { get; set; }

        [Required(ErrorMessage = "WebhookUrl is required.")]
        [Url(ErrorMessage = "WebhookUrl must be a valid URL.")]
        public required string WebhookUrl { get; set; }
    }
}