using Microsoft.AspNetCore.Components;
using My_Task.Client.Shared;
using My_Task.Shared;
using System.Net.Http.Json;


namespace My_Task.Client.Pages
{
    public partial class Index
    {
        private bool showDetails = false;
        private void CloseDetails()
        {
            showDetails = false;
        }

        private string? DialogName { get; set; }
        private string? DialogDescription { get; set; }

        private char? FirstLetter { get; set; }

        [Inject] public HttpClient Http { get; set; }


        string? error = "";

        int RandValue;
        string message = "";

        string HideDates = "";
        bool DatesHider = false;
        string DateCollapseArrow = "";
        string ModifyHeight = "";
        
        protected override void OnInitialized()
        {
            createTask.Update += StateHasChanged;
        }
        public void Dispose()
        {
            createTask.Update -= StateHasChanged;
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                string requestUri = "api/TaskItems";

                createTask.FetchAndUpdate(await Http.GetFromJsonAsync<IList<TaskItem>>(requestUri));
            }
            catch (Exception)
            {
                error = "an error occured";
            }
            if (createTask.dbItems != null)
            {
                foreach (TaskItem item in createTask.dbItems)
                {
                    if (!string.IsNullOrEmpty(item.TaskItemCategory))
                    {
                        createTask.TaskName.Add(item.TaskItemCategory);
                    }
                }
            }
            createTask.UpdateTaskCategory(createTask.TaskName.Distinct().ToList());
         
        }

        public int RandNumb()
        {
            Random random = new Random();

            return random.Next(0, 5);
        }

        public void HideDateContent()
        {
            DatesHider = DatesHider? false:true;
            HideDates = DatesHider? "no-hight" : "";
            DateCollapseArrow = DatesHider? "hide-date-filter-down" : "";
            ModifyHeight = DatesHider? "modify-height" : "";
        }
    }

    
}
