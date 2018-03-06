using AdminApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace AdminApp.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class GererPecheur : Page
    {
        String chemainApi = "http://localhost:65074/api/Pecheurs";
        public GererPecheur()
        {
            this.InitializeComponent();
            affichePecheur();
        }
        private async void affichePecheur()
        {
            var client = new HttpClient();
            String json = await client.GetStringAsync(chemainApi);
            var mylist = JsonConvert.DeserializeObject<List<Pecheur>>(json);
            listePecheur.ItemsSource = mylist;
        }

    }
}
