using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;
using NewVisionPayment.Models;
using NewVisionPayment.Services;
using NewVisionPayment.Controllers;

// This is our customer object that will be passed as a parameter
namespace NewVisionPayment.Classes
{
    public class chooseCustomer
    {
        // A customer object that unless given a full set of values will be created as a blank object
        public static NewVisionCustomer ChosenCustomer { get; set; } = new NewVisionCustomer();

    }
}
