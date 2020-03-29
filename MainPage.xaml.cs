using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PO_Org
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            List<Org_Item> org_items = ReadOrgs();
            Task Objs = Task.Run(ReadObjs);

            foreach(var item in org_items)
            {
                SelectList.Items.Add(item.Názov_organizácie); //Displays all the organizations on startup
            }
        }

        public static List<Org_Item> ReadOrgs()
        {
            using (StreamReader r = File.OpenText("Zoznam_Organizácie_mesta.JSON"))
            {
                string json_string = r.ReadToEnd();
                List<Org_Item> org_items = JsonConvert.DeserializeObject<List<Org_Item>>(json_string);

                return org_items;
            }
        }

        public static List<Obj_Item> ReadObjs()
        {
            using (StreamReader r = File.OpenText("Zoznam_Významné_objekty.JSON"))
            {
                string json_string = r.ReadToEnd();
                List<Obj_Item> obj_items = JsonConvert.DeserializeObject<List<Obj_Item>>(json_string);

                return obj_items;
            }
        }
        private void Find_Org(object sender, RoutedEventArgs e)
        {
            SelectList.Items.Clear();
            var org_items = ReadOrgs();
            string Org_Name = Nazov.Text;
            string Org_Street = Street.Text;

            foreach (var entry in org_items)
            {
                if (entry.Názov_organizácie.Contains(Org_Name) && entry.Adresa.Contains(Org_Street))
                {
                    SelectList.Items.Add(entry.Názov_organizácie);
                }
            }
        }

        private void Find_Obj(object sender, RoutedEventArgs e)
        {
            SelectList.Items.Clear();
            var obj_items = ReadObjs();
            string Obj_Name = Nazov.Text;
            string Obj_Street = Street.Text;

            foreach(var item in obj_items)
            {
                if (item.Názov.Contains(Obj_Name) && item.Ulica.Contains(Obj_Street))
                {
                    SelectList.Items.Add(item.Názov);
                }
            }
        }

        private void Show_Orgs(object sender, RoutedEventArgs e)
        {
            SelectList.Items.Clear(); 
            foreach(var item in ReadOrgs())
            {
                SelectList.Items.Add(item.Názov_organizácie);
            }
        }


        private void Show_Objs(object sender, RoutedEventArgs e)
        {
            SelectList.Items.Clear();
            foreach(var item in ReadObjs())
            {
                SelectList.Items.Add(item.Názov);
            }
        }

        private void SelectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var OrgList = ReadOrgs();
            var ObjList = ReadObjs();


            //Search both OrgList and ObjList to determine the information about our selection + which page should be used.
            string Selection = (SelectList.SelectedItem).ToString();
            foreach(var org in OrgList)
            {
                if (org.Názov_organizácie == Selection)
                {
                    this.Frame.Navigate(typeof(Org_Page), org);
                }
            }

            foreach(var obj in ObjList)
            {
                if (obj.Názov == Selection)
                {
                    this.Frame.Navigate(typeof(Obj_Page), obj);
                }
            }
        }
    }
}
