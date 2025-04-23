using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace ToDO_list
{
    public partial class MainPage : ContentPage
    {


        private ObservableCollection<string> Tasks { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();
            TasksListView.ItemsSource = Tasks;
        }

        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            var popup = new AdditionalInfoPopup();
            var result = await this.ShowPopupAsync(popup);

            string baseText = NewTaskEntry.Text;
            string extraInfo = result as string;

            if (!string.IsNullOrWhiteSpace(baseText))
            {
                string finalTask = baseText;
                if (!string.IsNullOrWhiteSpace(extraInfo))
                    finalTask += $" — {extraInfo}";

                Tasks.Add(finalTask); // добавь в список
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
