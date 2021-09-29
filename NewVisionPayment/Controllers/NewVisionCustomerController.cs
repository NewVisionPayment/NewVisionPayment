using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewVisionPayment.Models;
using NewVisionPayment.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewVisionPayment.Controllers
{
    public class NewVisionCustomerController : Controller
    {

        private readonly ICosmosDbService _cosmosDbService;
        public NewVisionCustomerController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [HttpGet]
        [ActionName("Get")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAllCustomers()
        {
            return View(await _cosmosDbService.GetItemsAsync("SELECT * FROM c"));
        }

        [ActionName("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("Id, lastName, firstName, addressLine1, addressLine2, city, postcode, fineAmount, deadLine, paymentPlan, minimumPayment, finePaid")] NewVisionCustomer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Id = Guid.NewGuid().ToString();
                await _cosmosDbService.AddItemAsync(customer);
                return RedirectToAction("Get");
            }

            return View(customer);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind("Id, Who, What, Where, When, Completed")] NewVisionCustomer customer)
        {
            if (ModelState.IsValid)
            {
                await _cosmosDbService.UpdateItemAsync(customer.Id, customer);
                return RedirectToAction("Get");
            }

            return View(customer);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            NewVisionCustomer customer = await _cosmosDbService.GetItemAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            NewVisionCustomer customer = await _cosmosDbService.GetItemAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind("Id")] string id)
        {
            await _cosmosDbService.DeleteItemAsync(id);
            return RedirectToAction("get");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            return View(await _cosmosDbService.GetItemAsync(id));
        }

    }

}
