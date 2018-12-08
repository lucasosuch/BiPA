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
            PokazWykresy();
        }

        public void PokazWykresy()
        {
            Image obraz = Image.FromFile("AVG AE.png");

            wykresSrednia.Image = obraz;
            wykresSrednia.Height = obraz.Height;
            wykresSrednia.Width = obraz.Width;

            obraz = Image.FromFile("MIN AE.png"); 

            wykresMin.Image = obraz;
            wykresMin.Height = obraz.Height;
            wykresMin.Width = obraz.Width;

            obraz = Image.FromFile("MAX AE.png");

            wykresMax.Image = obraz;
            wykresMax.Height = obraz.Height;
            wykresMax.Width = obraz.Width;
        }
    }
}
