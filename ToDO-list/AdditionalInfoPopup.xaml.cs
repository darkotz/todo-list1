using CommunityToolkit.Maui.Views;

namespace ToDO_list;

public partial class AdditionalInfoPopup : Popup
{
    public AdditionalInfoPopup()
    {
        InitializeComponent();
    }

    void OnSaveClicked(object sender, EventArgs e)
    {
        Close(infoEntry.Text); // Возвращаем введенный текст
    }
}