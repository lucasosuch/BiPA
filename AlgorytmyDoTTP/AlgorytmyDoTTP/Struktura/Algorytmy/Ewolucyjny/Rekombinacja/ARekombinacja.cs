namespace AlgorytmyDoTTP.Struktura.Algorytmy.Ewolucyjny.Rekombinacja
{
    abstract class ARekombinacja
    {
        public abstract ushort[] Krzyzowanie(ushort[] przodek1, ushort[] przodek2);
        protected abstract ushort[] Mutacja(ushort[] geny);
    }
}
