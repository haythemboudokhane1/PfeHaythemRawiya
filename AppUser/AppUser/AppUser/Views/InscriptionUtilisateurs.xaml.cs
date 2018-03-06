using AppUser.Models;
using AppUser.Views.EspaceAbonne;
using AppUser.Views.EspaceCommercant;
using AppUser.Views.EspacePecheur;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppUser.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InscriptionUtilisateurs : TabbedPage
    {
        String chemainApi = "http://localhost:65074/api/Abonnees";
        String chemainApiPecheur = "http://localhost:65074/api/Pecheurs";
        String chemainApiCommercant = "http://localhost:65074/api/Commercants";
        public InscriptionUtilisateurs ()
        {
            InitializeComponent();
            pckExp.Items.Add("débutant");
            pckExp.Items.Add("Professionnel ");
        }

        private async void btninscrir_Clicked(object sender, EventArgs e)
        {
            Abonnee A = new Abonnee  { nom = txtnom.Text , prenom = txtprenom.Text , adressEmail = txtEmail.Text , motDePasse = txtmdp.Text , confirmerMotDePasse = txtcmdp.Text };
            var json = JsonConvert.SerializeObject(A);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response= await client.PostAsync(chemainApi, content);
            if (response.IsSuccessStatusCode)
            {
                await Navigation.PushModalAsync(new Accueil());
            }
        }

        private async void bntinscrirVendeur_Clicked(object sender, EventArgs e)
        {
            Commercant C = new Commercant { nom = txtNom.Text, prenom = txtpre.Text, NumeroTelephone = int.Parse(txtNumTel.Text), motDePasse = txtmdp.Text, ConfirmerMotDePasse = txtConfirmermotdepasse.Text, adressEmail = txtAEmail.Text, };
            var json = JsonConvert.SerializeObject(C);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response = await client.PostAsync(chemainApiCommercant, content);
            if (response.IsSuccessStatusCode)
            {
                await Navigation.PushModalAsync(new AccueilCommercant());
            }
        }
         
        private async void btninscrirpecheur_Clicked(object sender, EventArgs e)
        {
            Pecheur P = new Pecheur { nom = txtnomm.Text , NumeroTelephone =int.Parse( txtnumeroTelephone.Text), Experience = pckExp.SelectedItem.ToString(), motDePasse = txtmotdepasse.Text, confirmerMotDePasse = txtConfirmermotdepasse.Text, adressEmail = txtAEmail.Text , prenom =txtprenomm.Text , adressMagasin=txtadrMag.Text };
            var json = JsonConvert.SerializeObject(P);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response=   await client.PostAsync(chemainApiPecheur, content);
            if (response.IsSuccessStatusCode)
            {
                await Navigation.PushModalAsync(new AccueilPecheur());
            }
        }
    }
}