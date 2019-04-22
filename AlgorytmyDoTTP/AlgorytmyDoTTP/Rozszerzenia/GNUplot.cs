using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BiPA.Rozszerzenia
{
    class GNUPlot
    {
        private readonly string sciezkaGNUPlot = @"./gnuplot.exe.lnk";
        Process procesGnuplot = new Process();

        public GNUPlot()
        {
            try
            {
                PathResolver pathResolver = new PathResolver();
                string sciezka = pathResolver.GetShortcutTargetFile(sciezkaGNUPlot);

                if (!File.Exists(sciezka))
                {
                    sciezka = pathResolver.GetShortcutTargetFile(sciezkaGNUPlot).Replace(" (x86)", "");
                }

                procesGnuplot.StartInfo.FileName = sciezka;
                procesGnuplot.StartInfo.UseShellExecute = false;
                procesGnuplot.StartInfo.RedirectStandardInput = true;
                procesGnuplot.StartInfo.RedirectStandardOutput = true;
                procesGnuplot.Start();
            } catch(System.ComponentModel.Win32Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (System.Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RysujWykresBadania(double[][] wartosci, int szerokosc, int wysokosc, string tytul, string nazwaPliku, string[] nazwyWykresow)
        {
            StreamWriter SW = procesGnuplot.StandardInput;
            StreamReader SR = procesGnuplot.StandardOutput;

            string[] tablicaWartosci = new string[wartosci.Length];
            string[] nazwyPol = new string[wartosci.Length];

            SW.WriteLine("set grid");
            SW.WriteLine("set title '"+ tytul + "'");
            SW.WriteLine("set terminal pngcairo size "+ szerokosc + ", "+ wysokosc);

            for (short i = 0; i < wartosci.Length; i++)
            {
                tablicaWartosci[i] += " ";
                for (short j = 0; j < wartosci[i].Length; j++)
                {
                    tablicaWartosci[i] += wartosci[i][j].ToString().Replace(",", ".") + ",";
                }

                SW.WriteLine("array "+ nazwyWykresow[i] + "[" + wartosci[i].Length + "] = [" + tablicaWartosci[i] + "]");
                nazwyPol[i] = nazwyWykresow[i] + " w linespoints";
            }

            SW.WriteLine("plot " + string.Join(", ", nazwyPol));
            SW.WriteLine("exit");

            Image png = Image.FromStream(SR.BaseStream);
            png.Save(@".\Wykresy\"+ nazwaPliku + ".png");
        }

        public void ZakonczProcesGNUPlot()
        {
            procesGnuplot.Close();
        }
    }
}
