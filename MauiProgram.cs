using Microsoft.Extensions.Logging;
using Plugin.Maui.SwipeCardView;
using SwipeCardViewDemo.Services;
using SwipeCardViewDemo.ViewModels;
using SwipeCardViewDemo.Views;

namespace SwipeCardViewDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSwipeCardView()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MovieCharacterViewModel>();
            builder.Services.AddSingleton<IMovieCharacterService, MovieCharacterService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
