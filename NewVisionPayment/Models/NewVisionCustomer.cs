using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace NewVisionPayment.Models
{
    public class NewVisionCustomer
    {

        //[JsonProperty(PropertyName = "id")]
        public String Id { get; set; }

        //[JsonProperty(propertyName = reference)]
        public String reference { get; set; }

        //[JsonProperty(PropertyName = "lastname")]
        public string lastName { get; set; }

        //[JsonProperty(PropertyName = "firstname")]
        public string firstName { get; set; }

        //[JsonProperty(PropertyName = "addressline1")]
        public string addressLine1 { get; set; }

        //[JsonProperty(PropertyName = "addressline2")]
        public string addressLine2 { get; set; }

        //[JsonProperty(PropertyName = "city")]
        public string city { get; set; }

        //[JsonProperty(PropertyName = "postcode")]
        public string postcode { get; set; }

        //[JsonProperty(PropertyName = "fineamount")]
        public float fineAmount { get; set; }

        //[JsonProperty(PropertyName = "deadline")]
        public string deadLine { get; set; }

        //[JsonProperty(PropertyName = "paymentplan")]
        public bool paymentPlan { get; set; }

        //[JsonProperty(PropertyName = "minimumpayment")]
        public float minimumPayment { get; set; }

        //[JsonProperty(PropertyName = "finepaid")]
        public bool finePaid { get; set; }

    }
}
