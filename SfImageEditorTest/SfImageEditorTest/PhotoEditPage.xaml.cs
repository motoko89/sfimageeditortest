using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Syncfusion.SfImageEditor.XForms;
using Xamarin.Forms;

namespace SfImageEditorTest
{
    public partial class PhotoEditPage : ContentPage
    {
        private Stream photoStream;
        public PhotoEditPage(Stream stream)
        {
            InitializeComponent();
            IPEditor.SetToolbarItemVisibility("Save", false);
            this.photoStream = stream;
            IPEditor.Source = ImageSource.FromStream(() => photoStream);
        }

        private void Handle_ImageSaving(object sender, ImageSavingEventArgs args)
        {
            Debug.WriteLine(DateTime.UtcNow + " Image saving");
            args.Cancel = true;
            var stream = args.Stream;
            Task.Run(async () =>
            {
                // Upload to server
                await Task.Delay(3000);
            });
            Debug.WriteLine(DateTime.UtcNow + " Image saving done");
        }

        private async void SavePhoto_OnClicked(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.UtcNow + " SavePhoto_OnClicked");
            IPEditor.Save(".jpg");
            Debug.WriteLine(DateTime.UtcNow + " SavePhoto_OnClicked ends");
        }

    }
}
