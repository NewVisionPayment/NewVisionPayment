using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;
using NewVisionPayment.Models;
using NewVisionPayment.Services;
using NewVisionPayment.Controllers;

// A service to provide stateful access to the customer payments objects
// This will be different for every user
namespace NewVisionPayment.Services
{
    public class customerMoney
    {
        public string ChosenCustomer { get; set; }

        public float amountToPay { get; set; } = 0;

        public  float amountLeft { get; set; }

    }
}
