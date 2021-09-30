using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;
using NewVisionPayment.Models;
using NewVisionPayment.Services;
using NewVisionPayment.Controllers;


namespace NewVisionPayment.Services
{
    public class customerMoney
    {
        public string ChosenCustomer { get; set; }

        public float amountToPay { get; set; } = 0;

        public  float amountLeft { get; set; }

    }
}
