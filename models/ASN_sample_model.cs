using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Subscription_tracker.models
{
    public class ASN_sample_model
    {
        public int Shipment_id { get; set; }
        
        public int Ship_from_id { get; set; }
        
        public required string Ship_from_name { get; set; }
        
        public  required string Ship_from_address { get; set; }
        
        public required string Ship_from_city { get; set; }
        
        public required string Ship_from_state { get; set; }
        
        public int Portal_code_to { get; set; }
    }
}