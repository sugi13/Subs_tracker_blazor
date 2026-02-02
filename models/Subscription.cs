

namespace Subscription_tracker.models
{
    public class Subscription
    {
        public int ItemId { get; set; }
        
        public int Subs_amount { get; set; }
        
        public int Subs_total { get; set; }
        
        public required string Subs_name { get; set; }
        
        public required string Subs_plan { get; set; }
    }
}