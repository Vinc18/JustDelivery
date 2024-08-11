using JustDelivery.Pages;

namespace JustDelivery.Pages
{
    public partial class CheckoutPage : ContentPage
    {
        public CheckoutPage()
        {
            InitializeComponent();
        }

        private async void loginBtn_Clicked(object sender, System.EventArgs e)
        {
            

            if (IsValidCredentials(emailEntry.Text, passwordEntry.Text))
            {
                await Shell.Current.GoToAsync(nameof(SuccessPage), animate: true);
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid email or password", "OK");
            }

        }

        private bool IsValidCredentials(string email, string password)
        {

            return (email == "vmadmin" && password == "sml12345");
        }
    }
}
