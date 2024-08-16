using Microsoft.Extensions.Logging;

namespace Numero3716370
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
            //constructor que agrega el servicio que se ejecuta una sola vez
            builder.Services.AddSingleton<LocalDbService>();
            builder.Services.AddTransient<MainPage>();
                #if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
