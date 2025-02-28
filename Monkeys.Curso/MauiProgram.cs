using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Monkeys.Curso.Helpers;

namespace Monkeys.Curso;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddDependencyContainer();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
