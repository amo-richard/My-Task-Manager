using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
namespace My_Task.Client.Shared
{
    partial class SideNav
    {

        [Inject] public IJSRuntime js { get; set; }
        public string? StatusString { get; set; }
        private bool Status { get; set; }
        bool Collapse = false;
        string ArrowProperties = "";
        string Hidable = "";
        string CenterFlex = "";
        string StatusColor = "#707070";
        string StatusText = "Away";
        bool AddClick = false;
        private string? bghome { get; set; } = "active";
        private string? bgdashboard { get; set; }
        private string? bgAdd { get; set; }
        private bool AddState = false;
        string? RemovePaddingLeft = "";

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
            // Call the JavaScript function to check the internet connection status
            Status = await js.InvokeAsync<bool>("networkStatus.isOnline");

            // Register an event listener to update the status dynamically
            js.InvokeVoidAsync("networkStatus.updateStatus", DotNetObjectReference.Create(this));

            StatusText = Status ? "Online" : "Away";
            StatusColor = Status ? "#18BC49" : "#707070";

            bghome = navigation.Uri == "" ? "active" : "";


        }

        [JSInvokable]
        public void UpdateStatus(bool isOnline)
        {
            Status = isOnline;
            StateHasChanged(); // Trigger a re-render to update the UI
        }

        public void Hide()
        {

            Collapse = Collapse ? false : true;
            Hidable = Collapse ? "hidable" : "";
            CenterFlex = Collapse ? "center-flex" : "";
            ArrowProperties = Collapse ? "arrow-properties" : "";
            RemovePaddingLeft = Collapse ? "remove-padding" : "";

        }

        private void Dashboard()
        {
            AddTask.Hide();
            bgAdd = "";
            bghome = "";
            bgdashboard = "active";
            navigation.NavigateTo("dashboard", replace: false);
        }

        private void Home()
        {
            AddTask.Hide();
            bgAdd = "";
            AddState = false;
            bghome = "active";
            bgdashboard = "";
            navigation.NavigateTo("", replace: false);

        }

        private void Add()
        {
            AddTask.Update();
            AddClick = AddClick ? !AddClick : !AddClick;
            bgAdd =AddClick? "active" : "";
        }
    }
}
