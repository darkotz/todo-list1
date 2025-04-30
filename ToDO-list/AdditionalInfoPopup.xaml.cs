using CommunityToolkit.Maui.Views;
using ToDO_list;

namespace ToDO_list;

public partial class AdditionalInfoPopup : Popup
{

   

    public AdditionalInfoPopup()
    {
        InitializeComponent();
        BindingContext = new MainPage();
    }

    void OnSaveClicked(object sender, EventArgs e)
    {
        var result = new AdditionalInfoResult
        {
            ExtraInfo = infoEntry.Text,
            Importance = TypePicker.SelectedItem?.ToString()
        };

        Close(result);
    }
}