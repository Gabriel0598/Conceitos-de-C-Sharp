//Namespace relativa a herança
namespace Classes.Herança
{
    //Criação de classe ponto
    public class Ponto
    {
        public int x, y;
        private int distancia;
        
        //Construtor:
        public Ponto(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        protected void CalcularDistancia()
        {
            //Método protegido, classes filha de Ponto terão acesso a este método;
            CalcularDistancia2();
        }

        private void CalcularDistancia2()
        {
            CalcularDistancia2();
            //Como é privado apenas esta classe pode acessar;
        }

        public virtual void CalcularDistancia3()
        {
            //Virtual permite que uma classe filha sobrescreva a operação dele;
            //Dentro desta classe ponto, este método tem um comportamento...
            //Mas quando é chamado na classe ponto3d, lá é possível que o comportamente dele seja outro, tendo em vista que sobrescreve;
        }
    }
}