using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;

namespace AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.TTP
{
    /// <summary>
    /// Klasa reprezentująca dostępność przedmiotów w danych miastach
    /// </summary>
    class Instancja : IPomocniczy
    {
        public double ZwrocDlugosc()
        {
            throw new System.NotImplementedException();
        }

        public short ZwrocDo()
        {
            throw new System.NotImplementedException();
        }

        public short ZwrocOd()
        {
            throw new System.NotImplementedException();
        }

        public ushort[] ZwrocPrzedmioty(string dostepnePrzedmioty, int iloscPrzedmiotow)
        {
            dostepnePrzedmioty = dostepnePrzedmioty.Replace(" ", "").Trim();
            string[] elementy = dostepnePrzedmioty.Split(',');

            ushort[] przedmioty = new ushort[iloscPrzedmiotow];
            for (int i = 0; i < iloscPrzedmiotow; i++)
            {
                for (int j = 0; j < elementy.Length; j++)
                {
                    elementy[j] = elementy[j].Replace(" ", "").Trim();
                    if ((i + 1) == int.Parse(elementy[j]))
                    {
                        przedmioty[i] = 1;
                        break;
                    }
                    else
                    {
                        przedmioty[i] = 0;
                    }
                }
            }

            return przedmioty;
        }

        public double ZwrocWage()
        {
            throw new System.NotImplementedException();
        }

        public double ZwrocWartosc()
        {
            throw new System.NotImplementedException();
        }
    }
}
