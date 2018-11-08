using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace SfImageEditorTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ChoosePhoto_OnClicked(object sender, EventArgs e)
        {
            if (await EnsurePermissions())
            {
                var file = await CrossMedia.Current.PickPhotoAsync(
                    new PickMediaOptions
                    {
                        PhotoSize = PhotoSize.Full
                    });
                if (file != null)
                {
                    Navigation.PushAsync(new PhotoEditPage(file.GetStream()));
                }
            }
        }

        private async Task<bool> EnsurePermissions()
        {
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                Debug.WriteLine("Request permissions");
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }

            Debug.WriteLine("Camera status {0}. Storage status {1}.", cameraStatus, storageStatus);
            return cameraStatus == PermissionStatus.Granted &&
                   storageStatus == PermissionStatus.Granted;
        }
    }
}
