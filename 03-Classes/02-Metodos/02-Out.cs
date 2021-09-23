namespace Classes.Metodos
{
    public class Out
    {
        static void Dividir(int x, int y, out int resultado, out int resto)
        {
            resultado = x / y;
            resto = x % y;
            //Operador mod;
        }
        
        public static void Dividir() 
        {
            //Out tipo variável realiza a saída destes valores no parâmetro do método:
            Dividir(10, 3, out int resultado, out int resto);
            System.Console.WriteLine("{0} {1}", resultado, resto);// Escreve "3 1"
            //Aloca posições na memória para o resultado e resto;
        }
    }
}