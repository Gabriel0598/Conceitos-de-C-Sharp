namespace Classes.Metodos
{
    public class Ref
    {
        //ref indica que a variável é recebida por referência;
        static void Inverter(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public static void Inverter()
        {
            //Como ele trás o método inverter ele recebe suas características, sendo assim inverte os números;
            int i = 1, j = 2;
            Inverter(ref i, ref j);
            System.Console.WriteLine($"{i} {j}");// Escreve "2 1"
        }
    }
}