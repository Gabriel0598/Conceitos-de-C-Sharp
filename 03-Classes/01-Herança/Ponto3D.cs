namespace Classes.Herança
{
    //Classe Ponto3D herda da classe ponto;
    //public class classeFilha: classeMãe
    public class Ponto3D : Ponto
    {
        public int z;
        public Ponto3D(int x, int y, int z) : base(x, y)
        {
            this.z = z;
            CalcularDistancia();
        }

        public static void Calcular()
        {
            //Por ser estático pertence a esta classe;
            //Não é necessário instanciar um objeto para chamar método;
            //Basta chamar o método da classe ponto;
        }
        public override void CalcularDistancia3()
        {
            //Este override permite mudar o comportamento do método (herdado da classe mãe) aqui...
            //Valendo a operação apenas para este escopo;
            base.CalcularDistancia3();
        }
    }
}