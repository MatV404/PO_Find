namespace PO_Org
{
    public class Obj_Item
    {
        public string Názov;
        public string Skupina;
        public string Kategória;
        public string Popis;
        public string Dátum_do;
        public string Dátum_od;
        public string Dátum_aktualizácie;
        public string Kontakt_na_prevádzkovateľa;
        public string Ulica;
        public string Adresa;

        public Obj_Item(string názov, 
                        string skupina, 
                        string kategória, 
                        string popis, 
                        string dátum_do, 
                        string dátum_od, 
                        string dátum_aktualizácie, 
                        string kontakt_na_prevádzkovateľa, 
                        string ulica, 
                        string adresa)
        {
            Názov = názov;
            Skupina = skupina;
            Kategória = kategória;
            Popis = popis;
            Dátum_do = dátum_do;
            Dátum_od = dátum_od;
            Dátum_aktualizácie = dátum_aktualizácie;
            Kontakt_na_prevádzkovateľa = kontakt_na_prevádzkovateľa;
            Ulica = ulica;
            Adresa = adresa;
        }
    }
}
