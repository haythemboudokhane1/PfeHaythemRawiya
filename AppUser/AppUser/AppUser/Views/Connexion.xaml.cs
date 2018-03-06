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
	public partial class Connexion : ContentPage
	{

        String chemainApi = "http://localhost:65074/api/Abonnees";
        String chemainApiPecheur = "http://localhost:65074/api/Pecheurs";
        String chemainApiCommercant = "http://localhost:65074/api/Commercants";
        public Connexion ()
		{
			InitializeComponent ();
		}

        private async void btnInscription_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new InscriptionUtilisateurs());
        }

        private async void btnConnect_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var jsonAbonne = await client.GetStringAsync(chemainApi);
            var mylistAbonne = JsonConvert.DeserializeObject<List<Abonnee>>(jsonAbonne);


            var jsonPecheur = await client.GetStringAsync(chemainApiPecheur);
            var mylistPecheur = JsonConvert.DeserializeObject<List<Pecheur>>(jsonPecheur);


            var jsonCommercant = await client.GetStringAsync(chemainApiCommercant);
            var mylistCommercant = JsonConvert.DeserializeObject<List<Commercant>>(jsonCommercant);

            if (mylistAbonne.Where(Abonnee=>Abonnee.adressEmail==txtemail.Text && Abonnee.motDePasse==txtpw.Text).Count()>0)
            {
                await Navigation.PushModalAsync(new Accueil());
                    
            }
            else if (mylistPecheur.Where(Pecheur => Pecheur.adressEmail == txtemail.Text && Pecheur.motDePasse == txtpw.Text).Count() > 0)
            {
                await Navigation.PushModalAsync(new AccueilPecheur());
            }
            else if (mylistCommercant.Where(Commercant=> Commercant.adressEmail == txtemail.Text && Commercant.motDePasse == txtpw.Text).Count() > 0)
            {
                await Navigation.PushModalAsync(new AccueilCommercant());
            }
            else
            {
                await DisplayAlert("Erreur", "Vérifier Vos Données ", "ok");
            }
        }
    }
}