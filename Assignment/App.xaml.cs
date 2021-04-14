using Assignment.State;
using Assignment.State.Authenticators;
using Assignment.State.Navigators;
using Assignment.ViewModels;
using Assignment.ViewModels.Factories;
using Domain.Services;
using Domain.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Assignment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            IServiceProvider serviceProvider = CreateServiceProvider();
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            //this object hold feet, meters value that shared between viewModels
            services.AddSingleton<SharedState>();
            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IConvertService, ConvertService>();
            services.AddSingleton<INavigator, Navigator>();

            services.AddTransient<FeetToMeterViewModel>();
            services.AddTransient<MeterToFeetViewModel>();
            services.AddTransient<MainViewModel>();

            //you must add ViewModel before Add CreateViewmodel
            services.AddSingleton<CreateViewModel<FeetToMeterViewModel>>(services =>
            {
                return () => services.GetRequiredService<FeetToMeterViewModel>();
            });
            services.AddSingleton<CreateViewModel<MeterToFeetViewModel>>(services =>
            {
                return () => services.GetRequiredService<MeterToFeetViewModel>();
            });

            //services.AddSingleton<ViewModelDelegateRenavigator<FeetToMeterViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<MeterToFeetViewModel>>();
            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => new LoginViewModel(
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<MeterToFeetViewModel>>());
            });

            services.AddSingleton<CreateViewModel<MainViewModel>>();

            services.AddSingleton<MainWindow>(services => new MainWindow(services.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }


    }
}
