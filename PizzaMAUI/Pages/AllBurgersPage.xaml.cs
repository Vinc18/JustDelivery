namespace JustDelivery.Pages;

public partial class AllBurgersPage : ContentPage
{
    private readonly AllBurgerViewModel _allBurgerViewModel;
    public AllBurgersPage(AllBurgerViewModel allBurgerViewModel)
    {
        InitializeComponent();
        _allBurgerViewModel = allBurgerViewModel;
        BindingContext = _allBurgerViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_allBurgerViewModel.FromSearch)
        {
            await Task.Delay(100);
            searchBar.Focus();
        }
    }

    void searchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.OldTextValue)
            && string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            _allBurgerViewModel.SearchBurgersCommand.Execute(null);
        }
    }
}
