using AlgorytmyDoTTP.Struktura.ProblemyOptymalizacyjne.Abstrakcyjny;

namespace AlgorytmyDoTTP.Struktura.Algorytmy.Wspinaczkowy.Losowanie
{
    class LosowanieBinarne : ALosowanie
    {
        public LosowanieBinarne(ProblemOptymalizacyjny problem) : base(problem){}

        public override ushort[] WygenerujRozwiazanie()
        {
            ushort[] wynik = new ushort[problem.ZwrocDlugoscGenotypu()];

            for (int i = 0; i < wynik.Length; i++)
            {
                wynik[i] = (ushort)losowy.Next(2);
            }

            return wynik;
        }
    }
}
