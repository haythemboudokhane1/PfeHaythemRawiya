using AppUser.Models;
using AppUser.Views.EspacePecheur.GererProfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppUser
{
	public partial class App : Application
	{
        public static Pecheur currentpecheur = new Pecheur();

		public App ()
		{

			InitializeComponent();

			MainPage = new GererPublication();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
