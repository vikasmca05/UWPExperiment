using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OptimaBluetooth
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScanDevices : Page
    {
        private DeviceWatcher deviceWatcher = null;

        private TypedEventHandler<DeviceWatcher, DeviceInformation> handlerAdded = null;
        private TypedEventHandler<DeviceWatcher, DeviceInformationUpdate> handlerUpdated = null;
        private TypedEventHandler<DeviceWatcher, DeviceInformationUpdate> handlerRemoved = null;
        private TypedEventHandler<DeviceWatcher, Object> handlerEnumCompleted = null;
        private TypedEventHandler<DeviceWatcher, Object> handlerStopped = null;

        public ScanDevices()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<DeviceInformationDisplay> ResultCollection
        {

        }
        private void StopWatcherButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartWatcherButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
