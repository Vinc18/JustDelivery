﻿namespace JustDelivery;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
		Routing.RegisterRoute(nameof(CheckoutPage), typeof(CheckoutPage));
        Routing.RegisterRoute(nameof(SuccessPage), typeof(SuccessPage));
    }
}
