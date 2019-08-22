using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppPrismSample.Views;
using Prism.Navigation;
using Xamarin.Forms;

namespace AppPrismSample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand NavigateCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateCommand = new Command(async () => await Navigate());
        }

        private async Task Navigate()
        {
            await NavigationService.NavigateAsync(nameof(APage));
        }

        public override void Destroy()
        {
            Debug.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}: MainPageViewModel Destroy");
            base.Destroy();
        }
    }
}
