using AdminApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace AdminApp.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Connexion : Page
    {
      
        public Connexion()
        {
            this.InitializeComponent();
        }

        private void btnshowGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private async void btnCnx_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("http://localhost:65074/api/Administrateurs");
            var mylist = JsonConvert.DeserializeObject<List<Administrateur>>(json);
            List<Administrateur> mesadmins = new List<Administrateur>();
            mesadmins = mylist;
            if (mesadmins.Where(Administrateur=>Administrateur.AdresseEmail==txtemail.Text && Administrateur.MotDePasse==txtpw.Password).Count()>0)
            {
                Frame.Navigate(typeof(Accueil));
            }
            else
            {
                MessageDialog msg = new MessageDialog("Verifier adresse et mot de passe");
                await msg.ShowAsync();
            }
        }
    }
}
