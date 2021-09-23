namespace Classes.Metodos
{
    public class Ref
    {
        //ref indica que a vari�vel � recebida por refer�ncia;
        static void Inverter(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public static void Inverter()
        {
            //Como ele tr�s o m�todo inverter ele recebe suas caracter�sticas, sendo assim inverte os n�meros;
            int i = 1, j = 2;
            Inverter(ref i, ref j);
            System.Console.WriteLine($"{i} {j}");// Escreve "2 1"
        }
    }
}