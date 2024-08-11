using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using JustDelivery.Services;
using JustDelivery.ViewModels;
using JustDelivery.Pages;

namespace JustDelivery;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseMauiCommunityToolkit();

#if DEBUG
        builder.Logging.AddDebug();
#endif
		AddBurgerServices(builder.Services);

        return builder.Build();
	}

	private static IServiceCollection AddBurgerServices(IServiceCollection services)
	{
		services.AddSingleton<BurgerService>();

		services.AddSingleton<HomePage>()
				.AddSingleton<HomeViewModel>();

		services.AddTransientWithShellRoute<AllBurgersPage, AllBurgerViewModel>(nameof(AllBurgersPage));

        services.AddTransientWithShellRoute<DetailPage, DetailsViewModel>(nameof(DetailPage));

		services.AddSingleton<CartViewModel>();
		services.AddTransient<CartPage>();
        return services;
	}
}
