using AppUser.Models;
using Newtonsoft.Json;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppUser.Views.EspacePecheur.GererProfil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GererPublication : TabbedPage
    {
        byte[] imagesource;
        public GererPublication ()
        {
            InitializeComponent();
            imgcamera.Source = ImageSource.FromFile("camera.png");
        }

        private async void btnimage_Tapped(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Erreur", "resseaye", "ok");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            imgcamera.Source = ImageSource.FromStream(() => file.GetStream());
            MemoryStream ms = new MemoryStream();
            file.GetStream().CopyTo(ms);
            imagesource = ms.ToArray();

        }
        String chemainApiPecheur = "";
        private async void btnenreg_Clicked(object sender, EventArgs e)
        {
            PublicationPecheur PU = new PublicationPecheur { nom = txtNomPublication.Text , lieu= txtlieupub.Text, poids= Double.Parse(txtPoids.Text), photoPoisson=imagesource, dateDePeche=DateTime.Now, IdPecheur=App.currentpecheur.Id, choix= choixpub };
            var json = JsonConvert.SerializeObject(PU);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            await client.PostAsync(chemainApiPecheur, content);
        }

        String choixpub = "http://localhost:65074/api/Pecheurs";
        private void swChoix_Toggled(object sender, ToggledEventArgs e)
        {
            bool test = swChoix.IsToggled;
            if (test)
            {
                choixpub = "a vendre";
            }
            else
            {
                choixpub = "";
            }
        }
    }
}