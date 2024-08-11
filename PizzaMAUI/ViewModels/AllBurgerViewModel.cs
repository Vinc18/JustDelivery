namespace JustDelivery.ViewModels
{
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class AllBurgerViewModel : ObservableObject
    {
        private readonly BurgerService _burgerService;

        public AllBurgerViewModel(BurgerService burgerService)
        {
            _burgerService = burgerService;
            Burger = new ObservableCollection<Burger>(_burgerService.GetAllBurgers());
        }

        public ObservableCollection<Burger> Burger { get; set; }

        [ObservableProperty]
        private bool _fromSearch;

        [ObservableProperty]
        private bool _searching;

        [RelayCommand]
        private async Task SearchBurgers(string searchTerm)
        {
            Burger.Clear();
            Searching = true;

            await Task.Delay(1000);

            foreach (var burger in _burgerService.SearchBurgers(searchTerm))
            {
                Burger.Add(burger); // Hinzufügen des gefundenen Burgers anstelle von "Burgers"
            }

            Searching = false;
        }

        [RelayCommand]
        private async Task GoToDetailsPage(Burger burger)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Burger)] = burger // Verwenden des übergebenen Burgers anstelle von "Burger"
            };

            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }
    }
}
