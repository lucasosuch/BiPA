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
            Image obraz = Image.FromFile(nazwyPlikow[0] + ".png");

            wykresSrednia.Image = obraz;
            wykresSrednia.Height = obraz.Height;
            wykresSrednia.Width = obraz.Width;

            obraz = Image.FromFile(nazwyPlikow[1] + ".png");

            wykresMin.Image = obraz;
            wykresMin.Height = obraz.Height;
            wykresMin.Width = obraz.Width;

            obraz = Image.FromFile(nazwyPlikow[2] + ".png");

            wykresMax.Image = obraz;
            wykresMax.Height = obraz.Height;
            wykresMax.Width = obraz.Width;
        }

        public void WyswietlInformacjeZwrotna(int iteracja, float[] srednie, float[] minima, float[] maxima)
        {
            string tekst = "Najlepsza iteracja: " + (iteracja + 1) + Environment.NewLine +
                           "---" + Environment.NewLine +
                           "Wykres Średniej z najlepszej iteracji badania: " + Environment.NewLine +
                           "- średnia: " + srednie[0] + Environment.NewLine +
                           "- mediana: " + srednie[1] + Environment.NewLine +
                           "- odchylenie standardowe: " + srednie[2] + Environment.NewLine +
                           "---" + Environment.NewLine +
                           "Wykres Minimów z najlepszej itracji badania: " + Environment.NewLine +
                           "- średnia: " + minima[0] + Environment.NewLine +
                           "- mediana: " + minima[1] + Environment.NewLine +
                           "- odchylenie standardowe: " + minima[2] + Environment.NewLine +
                           "---" + Environment.NewLine +
                           "Wykres Maksimów z najlepszej itracji badania: " + Environment.NewLine +
                           "- średnia: " + maxima[0] + Environment.NewLine +
                           "- mediana: " + maxima[1] + Environment.NewLine +
                           "- odchylenie standardowe: " + maxima[2];

            wynikiBadnia.Text = tekst;
        }
    }
}
