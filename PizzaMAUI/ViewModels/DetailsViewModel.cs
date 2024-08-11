using System;


namespace JustDelivery.ViewModels
{
    [QueryProperty(nameof(Burger), nameof(Burger))]
    public partial class DetailsViewModel : ObservableObject, IDisposable
    {
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;

            _cartViewModel.CartCleared += OnCartCleared;
            _cartViewModel.CartItemRemoved += OnCartItemRemoved;
            _cartViewModel.CartItemUpdated += OnCartItemUpdated;
        }

        private void OnCartCleared(object? _, EventArgs e) => Burger.CartQuantity = 0;

        private void OnCartItemRemoved(object? _, Burger p) =>
            OnCartItemChanged(p, 0);

        private void OnCartItemUpdated(object? _, Burger p) =>
            OnCartItemChanged(p, p.CartQuantity);

        private void OnCartItemChanged(Burger p, int quantity)
        {
            if(p.Name == Burger.Name)
            {
                Burger.CartQuantity = quantity;
            }
        }

        [ObservableProperty]
        private Burger _burger;

        [RelayCommand]
        private void AddToCart()
        {
            Burger.CartQuantity++;
            _cartViewModel.UpdateCartItemCommand.Execute(Burger);
        }

        [RelayCommand]
        private void RemoveFromCart()
        {
            if (Burger.CartQuantity > 0)
            {
                Burger.CartQuantity--;
                _cartViewModel.UpdateCartItemCommand.Execute(Burger);
            }
        }

        [RelayCommand]
        private async Task ViewCart()
        {
            if(Burger.CartQuantity > 0)
            {
                await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
            }
            else
            {
                await Toast.Make("Please select the quantity using the plus (+) button", ToastDuration.Short)
                    .Show();
            }
        }

        public void Dispose()
        {
            _cartViewModel.CartCleared -= OnCartCleared;
            _cartViewModel.CartItemRemoved -= OnCartItemRemoved;
            _cartViewModel.CartItemUpdated -= OnCartItemUpdated;
        }
    }
}

