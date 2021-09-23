using System;
using Classes.Herança;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Ponto p1 = new Ponto(10, 20);
            //Instanciando ponto num plano 2D;
            //Possui eixos x e y;
            //p1 está armazenado no heap, esta é apenas uma referência;
            //No caso de structs elas acessam o stack diretamente;

            Ponto p2 = new Ponto3D(10, 20, 30);
            //Instanciando ponto num plano 3D;
            //Possui eixos x, y e z;

            Ponto3D.Calcular();
            //Método estático pertence a classe e não a instância, portanto para chamá - lo é necessário chamar a classe primeiro;
        }
    }
}
