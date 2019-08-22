using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace AppPrismSample.ViewModels
{
    public class APageViewModel : BaseViewModel
    {
        private Timer _timer;

        public ICommand BackCommand { get; set; }
        public APageViewModel(INavigationService navigationService) : base(navigationService)
        {
            BackCommand = new Command(async () => await Back());
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            _timer = new Timer(1000);

            _timer.Elapsed += (sender, args) =>
            {
                Debug.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}: Timer run");
            };

            _timer.Start();
        }

        private async Task Back()
        {
            await NavigationService.GoBackAsync();
        }

        public override void Destroy()
        {
            //_timer.Stop();

            base.Destroy();
        }
    }
}
