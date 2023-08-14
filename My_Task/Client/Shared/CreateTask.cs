
using My_Task.Shared;
namespace My_Task.Client.Shared;

public class CreateTask
{

    public IList<TaskItem>? NewContent = new List<TaskItem>();
    public IList<TaskItem>? dbItems;

    public List<string>? FiltedTaskName = new List<string>();
    public List<string>? TaskName = new List<string>();

    public event Action? Update;
    private void UpdateData() => Update();
    public void AddToNewContent(TaskItem NewItem)
    {
        NewContent.Add(NewItem);
        dbItems.Add(NewItem);
        UpdateData();
    }

    public void NewItems(IList<TaskItem> ParentContent)
    {
        if (NewContent != null)
        {
            foreach (TaskItem Item in NewContent)
            {
                ParentContent.Add(Item);
            }
        }

        UpdateData();
    }

    public void FetchAndUpdate(IList<TaskItem> Data)
    {
        dbItems = Data;
        UpdateData();
    }

    public void UpdateTaskCategory(List<string> item)
    {
        FiltedTaskName = item;
        UpdateData();
    }
}
    