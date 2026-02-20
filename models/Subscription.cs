using System.ComponentModel.DataAnnotations;

namespace Subscription_tracker.models
{
    public class Subscription
    {
        public int ItemId { get; set; }
        
        [Required(ErrorMessage = "Amount required")]
        [Range(1, 100000, ErrorMessage = "Amount must be greater than 0")]
        public string? Subs_amount { get; set; }
        
        public int? Subs_total { get; set; }
        
        [Required(ErrorMessage = "Subscription name required")]
        public required string? Subs_name { get; set; }
        
        [Required(ErrorMessage = "Select a plan")]
        public required string? Subs_plan { get; set; }
    }
}