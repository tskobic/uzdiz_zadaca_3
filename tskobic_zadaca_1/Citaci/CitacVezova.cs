﻿using tskobic_zadaca_1.Modeli;
using tskobic_zadaca_1.Static;

namespace tskobic_zadaca_1.Citaci
{
    public class CitacVezova
    {
        public List<Vez> ProcitajPodatke(string putanja)
        {
            string[] retci = File.ReadAllLines(putanja);
            List<Vez> vezovi = new List<Vez>();

            for (int i = 1; i < retci.Length; i++)
            {
                string[] celije = retci[i].Split(";");


                if (celije.Length != 7)
                {
                    Ispis.GreskaBrojCelija(retci[i], putanja);
                }
                else
                {
                    bool greska = false;

                    for (int j = 0; j < celije.Length; j++)
                    {
                        if (j == 0 || j > 2)
                        {
                            if (!Validacija.ProvjeriPretvorbuUInt(celije[j]))
                            {
                                greska = true;
                                Ispis.GreskaPretvorbeUInt(retci[i], celije[j], putanja);
                                break;
                            }
                        }
                        if (j == 2 && !Konstante.VrsteVezova.Contains(celije[j]))
                        {
                            greska = true;
                            Ispis.GreskaNedozvoljenaVrsta(retci[i], celije[j], putanja, "vez");
                            break;
                        }
                    }
                    if (!greska)
                    {
                        int id = int.Parse(celije[0]);
                        int cijenaPoSatu = int.Parse(celije[3]);
                        int maksDuljina = int.Parse(celije[4]);
                        int maksSirina = int.Parse(celije[5]);
                        int maksDubina = int.Parse(celije[6]);

                        if (Validacija.ProvjeriVezove(celije[2]))
                        {
                            vezovi.Add(new Vez(id, celije[1], celije[2],
                                cijenaPoSatu, maksDuljina, maksSirina, maksDubina));
                        }
                    }
                }
            }

            return vezovi;
        }
    }
}
