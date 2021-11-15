namespace NewVisionPayment.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NewVisionPayment.Models;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Fluent;
    using Microsoft.Extensions.Configuration;
    using System;

    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public static  List<NewVisionCustomer> customers { get; set; } = new List<NewVisionCustomer>();

        public event Action OnChange;

        public async Task AddItemAsync(NewVisionCustomer customer)
        {
            await this._container.CreateItemAsync<NewVisionCustomer>(customer, new PartitionKey(customer.Id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<NewVisionCustomer>(id, new PartitionKey(id));
        }

        public async Task<NewVisionCustomer> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<NewVisionCustomer> response = await this._container.ReadItemAsync<NewVisionCustomer>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<List<NewVisionCustomer>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<NewVisionCustomer>(new QueryDefinition(queryString));
            List<NewVisionCustomer> results = new List<NewVisionCustomer>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, NewVisionCustomer customer)
        {
            await this._container.UpsertItemAsync<NewVisionCustomer>(customer, new PartitionKey(id));
        }
    }
}