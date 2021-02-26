using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TransactionProcessor.Entities;
using Microsoft.AspNetCore.Components;
using TransactionProcessor.Entities.ViewModel;

namespace TransactionAdministrationPortal
{
    public class EntityService : IEntityService
    {
        private HttpClient HttpClient;
        private IApplicationConfiguration ApplicationConfiguration;

        public EntityService(IApplicationConfiguration applicationConfiguration,
            HttpClient httpClient)
        {
            ApplicationConfiguration = applicationConfiguration;
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<EntityModel>> GetEntities()
            => await HttpClient.GetJsonAsync<List<EntityModel>>($"{ApplicationConfiguration.ApiUrl}/entity");

        public async Task<EntityModel> GetEntity(string entityName)
            => await HttpClient.GetJsonAsync<EntityModel>($"{ApplicationConfiguration.ApiUrl}/entity/{entityName}");

        public async Task<EntityTableModel> GetEntityTable(string entityName)
            => await HttpClient.GetJsonAsync<EntityTableModel>($"{ApplicationConfiguration.ApiUrl}/entity/{entityName}/Table");
    }
}
