using System.Windows.Input;

namespace JustDelivery.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly BurgerService _burgersService;

  

        public HomeViewModel(BurgerService burgerService)
        {
            _burgersService = burgerService; 
            Burgers = new ObservableCollection<Burger>(_burgersService.GetPopularBurgers());

        }
       
        public ObservableCollection<Burger> Burgers { get; set; }

        [RelayCommand]
        private async Task GoToAllBurgersPage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(AllBurgerViewModel.FromSearch)] = fromSearch
            };
            await Shell.Current.GoToAsync(nameof(AllBurgersPage), animate: true, parameters);
        }

        [RelayCommand]
        private async Task GoToDetailsPage(Burger burger)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Burger)] = burger
            };
            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }
    }
}
