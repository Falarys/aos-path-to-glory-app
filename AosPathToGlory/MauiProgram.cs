using Microsoft.Extensions.Logging;

namespace AosPathToGlory
{
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
                });

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<EmpirePage>();
            builder.Services.AddTransient<LineUpPage>();
            builder.Services.AddTransient<ArmyListPage>();
            builder.Services.AddTransient<WizardPage>();
            builder.Services.AddSingleton<AosPathToGloryDatabase>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            Routing.RegisterRoute("wizard", typeof(WizardPage));
            Routing.RegisterRoute("armylist", typeof(ArmyListPage));

            return builder.Build();
        }
    }
}