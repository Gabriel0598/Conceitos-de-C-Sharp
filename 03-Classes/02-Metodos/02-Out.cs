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
            //Out tipo vari�vel realiza a sa�da destes valores no par�metro do m�todo:
            Dividir(10, 3, out int resultado, out int resto);
            System.Console.WriteLine("{0} {1}", resultado, resto);// Escreve "3 1"
            //Aloca posi��es na mem�ria para o resultado e resto;
        }
    }
}