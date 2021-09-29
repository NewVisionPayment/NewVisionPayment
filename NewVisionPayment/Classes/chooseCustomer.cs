using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;
using NewVisionPayment.Models;
using NewVisionPayment.Services;
using NewVisionPayment.Controllers;


namespace NewVisionPayment.Classes
{
    public class chooseCustomer
    {

        public static NewVisionCustomer ChosenCustomer { get; set; } = new NewVisionCustomer();

    }
}
