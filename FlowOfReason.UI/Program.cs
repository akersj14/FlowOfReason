using Avalonia;
using System;
using System.Reflection;
using Avalonia.ReactiveUI;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Splat;

namespace FlowOfReason.UI;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        var collection = new ServiceCollection();
        collection.AddCommonServices();
        var provider = collection.BuildServiceProvider();
        Ioc.Default.ConfigureServices(provider);
        Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
        BuildAvaloniaApp()
             .StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .UseReactiveUI()
            .WithInterFont()
            .LogToTrace();
}