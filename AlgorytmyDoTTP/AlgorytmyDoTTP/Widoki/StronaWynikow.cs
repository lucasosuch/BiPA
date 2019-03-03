using System.Drawing;
using System.Windows.Forms;

namespace AlgorytmyDoTTP.Widoki
{
    public partial class StronaWynikow : Form
    {
        public StronaWynikow()
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

        public void WyswietlTekst(string tekst)
        {
            wynikiBadnia.Text = tekst;
        }
    }
}
