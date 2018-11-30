using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PullToRefreshTest.ViewModels;
using Xamarin.Forms;

namespace PullToRefreshTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void InspectionsList_Refreshing(object sender, EventArgs e)
        {
            var vm = (MainViewModel)BindingContext;
            vm.SelectedInspection = null;
            vm.IsRefreshing = true;
            Task.Run(async () =>
            {
                await Task.Delay(3000);

                Device.BeginInvokeOnMainThread(() =>
                {
                    vm.IsRefreshing = false;
                });
            });
        }

    }
}
