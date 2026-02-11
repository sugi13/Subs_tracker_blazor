using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Subscription_tracker.models
{
    public class Detail_entry_model
    {
        public int Shipment_id { get; set; }
        
        public int Purchase_Order_number { get; set; }
        
        public required string Item_description { get; set; }
        
        public  required int Unit_of_measure { get; set; }
        
        public required string Expiry_date { get; set; }
        
        public required int Lot_number { get; set; }
        
        public int Quantity_shipper { get; set; }
    }
}