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

        private void OnAddTaskClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewTaskEntry.Text))
            {
                Tasks.Add(NewTaskEntry.Text);
                NewTaskEntry.Text = string.Empty;
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
