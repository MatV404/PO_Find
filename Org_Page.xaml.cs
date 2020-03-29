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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PO_Org
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Org_Page : Page
    {
        public Org_Page()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var Test = e.Parameter;
            Org_Item Item = (Org_Item)Test;

            //Determine if information is given. If not, then keep default text.
            if(Item.IČO_organizácie != "")
            {
                ICO_Text.Text = Item.IČO_organizácie;
            }

            if(Item.Názov_organizácie != "")
            {
                Name_Text.Text = Item.Názov_organizácie;
            }

            if(Item.Obec != "")
            {
                Obec_Text.Text = Item.Obec;
            }

            if(Item.Adresa != "")
            {
                Adresa_Text.Text = Item.Adresa;
            }

            if(Item.Forma_podnikania != "")
            {
                Forma_Text.Text = Item.Forma_podnikania;
            }

            if(Item.Charakteristika_organizácie != "")
            {
                Charakt_Text.Text = Item.Charakteristika_organizácie;
            }

            if(Item.URI != "")
            {
                Uri_Text.Text = Item.URI;
            }

            if(Item.Orgán_verejnej_moci != "")
            {
                Organ_Text.Text = Item.Orgán_verejnej_moci;
            }

            if(Item.Stav_elektronickej_schránky != "")
            {
                Stav_Text.Text = Item.Stav_elektronickej_schránky;
            }
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            //Retrieve search term (name of the item), make it link-friendly (no spaces, etc.) and search it up on google.
            string term = Name_Text.Text;
            string search = "";

            foreach (char character in term)
            {
                if (character == ' ')
                {
                    search += "+";
                }

                if (character == '.')
                {
                    search += "";
                }

                if (character == ',')
                {
                    search += "";
                }

                else
                {
                    search += character;
                }
            }

            string search_url = @"http://google.com/search?q=" + search;

            var uri = new Uri(search_url);

            DefaultLaunch();
            async void DefaultLaunch()
            {
                var success = await Windows.System.Launcher.LaunchUriAsync(uri);

                if (success)
                {
                    //Launched
                }

                else
                {
                    //Not Launched
                }
            }
        }
    }
}
