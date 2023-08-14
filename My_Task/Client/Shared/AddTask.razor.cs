using Microsoft.AspNetCore.Components;
using My_Task.Shared;
using System.Net.Http.Json;
using System.Security.Cryptography;

namespace My_Task.Client.Shared
{
    partial class AddTask
    {
        [Inject] public HttpClient Http { get; set; }
        [Inject] private NavigationManager navigation { get; set; }
        IList<TaskItem> NewData = new List<TaskItem>();

        public bool ClickState = false;
        bool TaskType = false;
        string ClickClass = "";
        string TimeClass = "";
        string error = "Save";
        string Shrink = "";
        string ShowParent = "";
        string HideSubtask = "";
        string HideCategory = "";
        string ShrinkHeight = "";
        string ActivateSubTask = "";

        string? DateStart = "";
        string? DateEnd = "";
        string? TaskStartTime = "";
        string ? TaskEndTime = "";

        bool CategoryItemStatus = false;
        string? CategoryClass ="";
        string? RotateArrow = "";


        protected override void OnInitialized()
        {   
            UpdateShow.Onchange += StateHasChanged;
            createTask.Update += StateHasChanged;

            


        }

        public void Dispose()
        {
            UpdateShow.Onchange -= StateHasChanged;
            createTask.Update-= StateHasChanged;
        }

        public async void UpdateNewData()
        {
            DateStart = StartDate.ToString();
            DateEnd = EndDate.ToString();
            TaskStartTime = TaskTimeStart.ToString();
            TaskEndTime = TaskTimeEnd.ToString();

            if (!string.IsNullOrWhiteSpace(TaskName) && !string.IsNullOrWhiteSpace(TaskCat) && !string.IsNullOrWhiteSpace(
                TaskDescription))
            {
                createTask.AddToNewContent(new TaskItem
                {
                    TaskItemName = TaskName,
                    TaskItemCategory = TaskCat,
                    TaskItemDescription = TaskDescription,
                    TaskItemStart = DateStart,
                    TaskItemEnd = DateEnd,
                    TaskItemParent = TaskP
                });

                TaskType = true;
                ShowParent = TaskType ? "show-parent" : "";
                HideCategory = TaskType ? "hide-category" : "";
                HideSubtask = TaskType ? "hide-category" : "";
                ShrinkHeight = TaskType ? "" : "shrink-height";
                TimeClass = TaskType ? "" : "add-time";
                Shrink = TaskType ? "" : "shrink";

                TaskItem CurrentData = new TaskItem
                {
                    TaskItemName = TaskName,
                    TaskItemCategory = TaskCat,
                    TaskItemDescription = TaskDescription,
                    TaskItemStart = DateStart,
                    TaskItemEnd = DateEnd,
                    TaskItemParent = TaskP
                };
                TaskP = createTask.NewContent[0].TaskItemName;
                TaskName = string.Empty;
                TaskCat = createTask.NewContent[0].TaskItemCategory;
                TaskDescription = string.Empty;
                DateStart = null;
                DateEnd = null;
                string requestUri = "api/TaskItems";

                try
                {
                    var results = await Http.PostAsJsonAsync(requestUri, CurrentData);

                    if (results.IsSuccessStatusCode)
                    {
                    }
                }
                catch (Exception er)
                {
                    error = er.ToString();
                }
            }
        }

        public void ChangeClick()
        {
            ClickState = ClickState ? !ClickState : !ClickState;
            ClickClass = ClickState ? "click" : ""; 
            TimeClass = ClickState ? "add-time" : ""; 
            Shrink = ClickState ? "shrink" : "";
            ShrinkHeight = ClickState ? "shrink-height" : ""; 
            ActivateSubTask = ClickState ? "subtast-activated" : ""; 
        }

        public void Close()
        {
            UpdateShow.Update();
            createTask.NewContent.Clear();
            TaskP = string.Empty;
            TaskName = string.Empty;
            TaskCat = string.Empty;
            TaskDescription = string.Empty;
            DateStart = null;
            DateEnd = null;
            TaskType = false;
            ShowParent = TaskType ? "show-parent" : "";
            HideCategory = TaskType ? "hide-category" : "";
            HideSubtask = TaskType ? "hide-category" : "";
            ShrinkHeight = TaskType ? "" : "shrink-height";
            TimeClass = TaskType ? "" : "add-time";
            Shrink = TaskType ? "" : "shrink";
        }

        public void ShowCategories()
        {
            CategoryItemStatus = CategoryItemStatus? !CategoryItemStatus: !CategoryItemStatus;

            CategoryClass = CategoryItemStatus ? "show-category" : "";
            RotateArrow = CategoryItemStatus ? "rotate-arrow" : "";
        }
    }
}
