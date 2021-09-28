namespace NewVisionPayment.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using NewVisionPayment.Models;

    public interface ICosmosDbService
    {
        event Action OnChange;

        List<NewVisionCustomer> customers { get; set; }

        Task<List<NewVisionCustomer>> GetItemsAsync(string query);
        Task<NewVisionCustomer> GetItemAsync(string id);
        Task AddItemAsync(NewVisionCustomer customer);
        Task UpdateItemAsync(string id, NewVisionCustomer customer);
        Task DeleteItemAsync(string id);
    }
}