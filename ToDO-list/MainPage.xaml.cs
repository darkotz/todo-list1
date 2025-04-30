using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace ToDO_list
{
    public partial class MainPage : ContentPage
    {


        private ObservableCollection<string> Tasks { get; set; } = new();
        public List<string> TaskType { get; set; }

        public MainPage()
        {
            InitializeComponent();
            TasksListView.ItemsSource = Tasks;
            TaskType = new List<string> { "❗", "❗❗", "❗❗❗" };

        }

        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            var popup = new AdditionalInfoPopup();
            var result = await this.ShowPopupAsync(popup) as AdditionalInfoResult;

            string baseText = NewTaskEntry.Text;
            

            if (!string.IsNullOrWhiteSpace(baseText))
            {
                string finalTask = baseText;
                if (result != null) { 

                    if (!string.IsNullOrWhiteSpace(result.ExtraInfo))
                        finalTask += $" — {result.ExtraInfo}";
                    if (!string.IsNullOrWhiteSpace(result.Importance))
                    finalTask = $"{result.Importance} {finalTask}";
                }

                Tasks.Add(finalTask); 
                NewTaskEntry.Text = "";
            }

        }

        private void OnDeleteTaskClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string task)
            {
                Tasks.Remove(task);
            }
        }

        
    }
}
