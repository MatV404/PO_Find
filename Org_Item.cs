namespace PO_Org
{
    public class Org_Item
    {
        public string IČO_organizácie;
        public string Názov_organizácie;
        public string Obec;
        public string Adresa;
        public string Forma_podnikania;
        public string Charakteristika_organizácie;
        public string URI;
        public string Orgán_verejnej_moci;
        public string Stav_elektronickej_schránky;

        public Org_Item(string ičo, string nazov,
                        string obec, string adresa,
                        string forma, string charakteristika,
                        string uri, string organ, string stav)
        {
            IČO_organizácie = ičo;
            Názov_organizácie = nazov;
            Obec = obec;
            Adresa = adresa;
            Forma_podnikania = forma;
            Charakteristika_organizácie = charakteristika;
            URI = uri;
            Orgán_verejnej_moci = organ;
            Stav_elektronickej_schránky = stav;
        }
    }
}
