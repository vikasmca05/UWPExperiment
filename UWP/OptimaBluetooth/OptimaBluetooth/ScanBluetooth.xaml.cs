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
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Enumeration;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238



namespace OptimaBluetooth
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScanBluetooth : Page
    {
      
        public ScanBluetooth()
        {
            this.InitializeComponent();
            StartSync();
        }
        public async void StartSync()
        {
            var selector = BluetoothDevice.GetDeviceSelector();
            var devices = await DeviceInformation.FindAllAsync(selector);

            BluetoothLEAdvertisementWatcher watcher = new BluetoothLEAdvertisementWatcher();
            watcher.Received += OnAdvertisementReceived;
            watcher.Start();
        }
        private async void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs eventArgs)
        {
            // Do whatever you want with the advertisement
            // Enumerate devices with the object push service
  
        }
    }



}
