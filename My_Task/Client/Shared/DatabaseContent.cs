using Microsoft.AspNetCore.Components;
using My_Task.Shared;
using System.Net.Http.Json;

namespace My_Task.Client.Shared
{
    public class DatabaseContent
    {
        [Inject] public HttpClient Http { get; set; }

        public IList<TaskItem> Data;
        public string? error = "";

        public async Task FetchItems()
        {
            try
            {
                string requestUri = "api/TaskItems";

                Data = await Http.GetFromJsonAsync<IList<TaskItem>>(requestUri);
            }
            catch (Exception)
            {
                error = "an error occured";
            }
        }

        public IList<TaskItem> GetItems()
        {
            return Data;
        }

    }
}
