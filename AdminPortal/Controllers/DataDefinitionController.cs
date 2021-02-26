using AdminPortal.Entities;
using AdminPortal.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AdminPortal.Controllers
{
    public class DataDefinitionController : Controller
    {
        const string url = "http://localhost:13938/api";

        protected HttpClient HttpClient;

        public DataDefinitionController(HttpClient httpClient)
            => HttpClient = httpClient;

        public ActionResult Add()
            => View(new BasicItem
            {
                BaseUrlAction = _ => Url.Action(nameof(Index))
            });

        [HttpPost]
        public async Task<ActionResult> Add(BasicItem item)
        {
            await HttpClient.SendJsonAsync(HttpMethod.Post, $"{url}/datadefinition/{item.Id}", item);
            return RedirectToAction(nameof(Detail), new { id = item.Id });
        }

        public async Task<ActionResult> Delete(long id)
             => View((await HttpClient.GetJsonAsync<DataDefinition>($"{url}/datadefinition/{id}"))
                 .ToBasicItem(BaseUrlAction));

        [HttpPost]
        public async Task<ActionResult> Delete(BasicItem item)
        {
            await HttpClient.DeleteAsync($"{url}/datadefinition/{item.Id}");
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Detail(long id)
            => View((await HttpClient.GetJsonAsync<DataDefinition>($"{url}/datadefinition/{id}"))
                .ToBasicItem(BaseUrlAction));

        public async Task<ActionResult> Edit(long id)
            => View((await HttpClient.GetJsonAsync<DataDefinition>($"{url}/datadefinition/{id}"))
                .ToBasicItem(BaseUrlAction));

        [HttpPost]
        public async Task<ActionResult> Edit(BasicItem item)
        {
            await HttpClient.SendJsonAsync(HttpMethod.Put, $"{url}/datadefinition/{item.Id}", item);
            return RedirectToAction(nameof(Detail), new { id = item.Id });
        }

        // GET: DataDefinition
        public async Task<ActionResult> Index()
            => View((await HttpClient.GetJsonAsync<DataDefinition[]>($"{url}/datadefinition"))
                .ToBasicTable(BaseUrlAction));

        private Func<BasicItem, string> BaseUrlAction { get => _ => Url.Action(nameof(Index)); }
    }
}
