using AlgorytmyDoTTP.Struktura.Algorytmy.Abstrakcyjny.Analityka;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgorytmyDoTTP.Widoki
{
    public partial class RezultatBadania : Form
    {
        public RezultatBadania()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        public void PokazWykresy(string[] nazwyPlikow)
        {
            Image obraz = Image.FromFile(@".\Wykresy\" + nazwyPlikow[0] + ".png");

            wykresSrednia.Image = obraz;
            wykresSrednia.Height = obraz.Height;
            wykresSrednia.Width = obraz.Width;

            obraz = Image.FromFile(@".\Wykresy\" + nazwyPlikow[1] + ".png");

            wykresMin.Image = obraz;
            wykresMin.Height = obraz.Height;
            wykresMin.Width = obraz.Width;

            obraz = Image.FromFile(@".\Wykresy\" + nazwyPlikow[2] + ".png");

            wykresMax.Image = obraz;
            wykresMax.Height = obraz.Height;
            wykresMax.Width = obraz.Width;
        }

        public void WyswietlInformacjeZwrotna(float[][] ranking, float[][] srednie, float[][] minima, float[][] maxima)
        {
            string tekst = "";

            for (int i = 0; i < srednie.Length; i++)
            {
                int iteracja = (int)(ranking[i][0] + 1);

                tekst += "Iteracja: " + iteracja + ", zdobyła " + ranking[i][1] + " punktów" + Environment.NewLine +
                        "---" + Environment.NewLine +
                        "Wykres Średniej z iteracji " + iteracja + " badania: " + Environment.NewLine +
                        "- średnia: " + srednie[i][0] + Environment.NewLine +
                        "- mediana: " + srednie[i][1] + Environment.NewLine +
                        "- odchylenie standardowe: " + srednie[i][2] + Environment.NewLine +
                        "---" + Environment.NewLine +
                        "Wykres Minimów z itracji " + iteracja + " badania: " + Environment.NewLine +
                        "- średnia: " + minima[i][0] + Environment.NewLine +
                        "- mediana: " + minima[i][1] + Environment.NewLine +
                        "- odchylenie standardowe: " + minima[i][2] + Environment.NewLine +
                        "---" + Environment.NewLine +
                        "Wykres Maksimów z itracji " + iteracja + " badania: " + Environment.NewLine +
                        "- średnia: " + maxima[i][0] + Environment.NewLine +
                        "- mediana: " + maxima[i][1] + Environment.NewLine +
                        "- odchylenie standardowe: " + maxima[i][2] + Environment.NewLine +
                        "----------------------------------------------------------------------" + Environment.NewLine;
            }

            wynikiBadnia.Text = tekst;
        }
    }
}
