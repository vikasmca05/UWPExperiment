using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.AppService;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClientApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private AppServiceConnection synclist;
        private AppServiceConnection remotesynclist;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ConnectService_Clicked(object sender, RoutedEventArgs e)
        {
            // Add the connection.
            if (this.synclist == null)
            {
                this.synclist = new AppServiceConnection();

                // Here, we use the app service name defined in the app service provider's Package.appxmanifest file in the <Extension> section.
                this.synclist.AppServiceName = "com.vikasmca.synclist";

                // Use Windows.ApplicationModel.Package.Current.Id.FamilyName within the app service provider to get this value.
                this.synclist.PackageFamilyName = "378daa96-83e5-4b59-a7db-6510233d3412_x02972355w8my";
                //378daa96 - 83e5 - 4b59 - a7db - 6510233d3412_1.0.0.0_x86__x02972355w8my

                        var status = await this.synclist.OpenAsync();
                if (status != AppServiceConnectionStatus.Success)
                {
                    if(status == AppServiceConnectionStatus.AppNotInstalled)
                        ConnectService.Content = "AppNotInstalled";
                    if (status == AppServiceConnectionStatus.AppServiceUnavailable)
                        ConnectService.Content = "AppServiceUnavailable";
                    if (status == AppServiceConnectionStatus.AppUnavailable)
                        ConnectService.Content = "AppUnavailable";
                    if (status == AppServiceConnectionStatus.Unknown)
                        ConnectService.Content = "Unknown";
                    return;
                }
            }

            var message = new ValueSet();
            message.Add("Command", "Item");

            AppServiceResponse response = await this.synclist.SendMessageAsync(message);
            string result = "";

            if (response.Status == AppServiceResponseStatus.Success)
            {
                // Get the data  that the service sent  to us.
                if (response.Message["Status"] as string == "OK")
                {
                    result = response.Message["Result"] as string;
                }
            }
            ConnectService.Content = result;

        }

        // This method returns an open connection to a particular app service on a remote system.
        // param "remotesys" is a RemoteSystem object representing the device to connect to.
        //private async void openRemoteConnectionAsync(RemoteSystem remotesys)
        //{
        //    // Set up a new app service connection. The app service name and package family name that
        //    // are used here correspond to the AppServices UWP sample.
        //    AppServiceConnection connection = new AppServiceConnection
        //    {
        //        AppServiceName = "com.vikasmca.remotesynclist",
        //        PackageFamilyName = "e07d58c8-05e6-47ce-aec5-0b1f12b9efdc_x02972355w8my"
        //    };
        //}
        private async void ConnectRemoteService_Clicked(object sender, RoutedEventArgs e)
        {
            // Add the connection.
            if (this.remotesynclist == null)
            {
                this.remotesynclist = new AppServiceConnection();

                // Here, we use the app service name defined in the app service provider's Package.appxmanifest file in the <Extension> section.
                this.remotesynclist.AppServiceName = "com.vikasmca.remotesynclist";

                // Use Windows.ApplicationModel.Package.Current.Id.FamilyName within the app service provider to get this value.
                this.remotesynclist.PackageFamilyName = "e07d58c8-05e6-47ce-aec5-0b1f12b9efdc_x02972355w8my";
                //378daa96 - 83e5 - 4b59 - a7db - 6510233d3412_1.0.0.0_x86__x02972355w8my

                var status = await this.remotesynclist.OpenAsync();
                if (status != AppServiceConnectionStatus.Success)
                {
                    if (status == AppServiceConnectionStatus.AppNotInstalled)
                        ConnectService.Content = "AppNotInstalled";
                    if (status == AppServiceConnectionStatus.AppServiceUnavailable)
                        ConnectService.Content = "AppServiceUnavailable";
                    if (status == AppServiceConnectionStatus.AppUnavailable)
                        ConnectService.Content = "AppUnavailable";
                    if (status == AppServiceConnectionStatus.Unknown)
                        ConnectService.Content = "Unknown";
                    return;
                }
            }

            var message = new ValueSet();
            message.Add("Command", "Item");

            AppServiceResponse response = await this.remotesynclist.SendMessageAsync(message);
            string result = "";

            if (response.Status == AppServiceResponseStatus.Success)
            {
                // Get the data  that the service sent  to us.
                if (response.Message["Status"] as string == "OK")
                {
                    result = response.Message["Result"] as string;
                }
            }
            ConnectService.Content = result;


        }
    }
}
