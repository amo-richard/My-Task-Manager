using My_Task.Client.Models;

namespace My_Task.Client.Services
{
    public class StyleLists
    {
        public List<ItemStyle> Priority = new List<ItemStyle>{
            new ItemStyle{TextColor="rgb(189,181,230)", BackgroundColor="rgba(189,181,230,.2)",FieldName = "low"},
            new ItemStyle{TextColor="rgb(81,231,236)", BackgroundColor="rgba(81,231,236,.2)",FieldName = "medium"},
            new ItemStyle{TextColor="rgb(255,10,156)", BackgroundColor="rgba(255,10,156,.2)",FieldName = "high"}
        };

        public List<ItemStyle> Status = new List<ItemStyle>{
            new ItemStyle{TextColor="rgb(189,181,230)", BackgroundColor="rgba(189,181,230,.2)",FieldName = "to do"},
            new ItemStyle{TextColor="rgb(4,103,252)", BackgroundColor="rgba(4,103,252,.2)",FieldName = "in progress"},
            new ItemStyle{TextColor="rgb(0,251,71)", BackgroundColor="rgba(0,251,71,.2)",FieldName = "completed"}
        };
    }
}
