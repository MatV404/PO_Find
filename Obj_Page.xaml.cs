using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class Obj_Page : Page
    {
        public Obj_Page()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //See Org_Page for more info
            base.OnNavigatedTo(e);
            var Test = e.Parameter;
            Obj_Item Item = (Obj_Item)Test;

            if (Item.Názov != "")
            {
                NazovText.Text = Item.Názov;
            }
            
            if (Item.Skupina != "")
            {
                SkupinaText.Text = Item.Skupina;
            }

            if (Item.Kategória != "")
            {
                KategoriaText.Text = Item.Kategória;
            }
            
            if (Item.Popis != "")
            {
                PopisText.Text = Item.Popis;
            }

            if (Item.Dátum_do != "")
            {
                PopisText.Text = Item.Dátum_do;
            }

            if (Item.Dátum_od != "")
            {
                PopisText.Text = Item.Dátum_od;
            }

            if (Item.Dátum_aktualizácie != "")
            {
                PopisText.Text = Item.Dátum_aktualizácie;
            }

            if (Item.Kontakt_na_prevádzkovateľa != "")
            {
                PopisText.Text = Item.Kontakt_na_prevádzkovateľa;
            }

            if (Item.Ulica != "")
            {
                PopisText.Text = Item.Ulica;
            }

            if (Item.Adresa != "")
            {
                PopisText.Text = Item.Adresa;
            }
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //See Org_Page for more info.
            string term = NazovText.Text;
            string search = "";

            foreach(char character in term)
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

            string search_url = @"http://google.com/search?q="+search;

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
