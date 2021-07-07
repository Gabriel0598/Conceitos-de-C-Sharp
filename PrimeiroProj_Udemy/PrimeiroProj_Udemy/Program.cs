using System;
using System.Globalization;

namespace PrimeiroProj_Udemy
{
    //Apostilas UNIP
    namespace ApostilaUNIP
    {

        class Banco
        {
            public string nomeFantasia;
            public long CNPJ; //Número muito grande você precisa usar long;
        }

        class Conta //Essa classe é o modelo base para a criação de objetos que herdarão os atributos dessa classe
        {
            public double saldo; //Atributo saldo da Classe conta - variável saldo;
            public double limite; //Atributo público (Ponto flutuante);
            public int numeroConta; //Atributo público (Número inteiro);
        }

        class Operacoes_Conta
        {
            static void Operacoes(string[] args)
            {
                //DADOS DO BANCO
                Banco nomeInstituicao = new Banco();
                nomeInstituicao.nomeFantasia = "Bradesco";
                nomeInstituicao.CNPJ = 60746948000112;

                //DADOS DA PRIMEIRA CONTA
                Conta conta1 = new Conta(); // Classe em que o objeto pertence/ Nome do objeto (Referência)/ = para atribuição/ New para instanciar esse objeto na memória/ Repetição do nome da classe/ Abre e fecha parentêses
                conta1.saldo = 1000.00; // Nome do objeto/ variável herdada da classe mãe/ atribuição de valor a essa variável para esse objeto específico;
                conta1.limite = 3000.00;
                conta1.numeroConta = 12345;

                Console.WriteLine("BANCO"); //Escrita de texto
                Console.WriteLine(); //Quebra de linha
                Console.WriteLine("INSTITUIÇÃO: " + nomeInstituicao.nomeFantasia + ".");
                Console.WriteLine("CNPJ: " + nomeInstituicao.CNPJ + ".");

                Console.WriteLine(); //Quebra de linha

                Console.WriteLine("DADOS DA CONTA"); //Escrita de texto
                Console.WriteLine();

                Console.WriteLine("NUMERO DA CONTA: " + conta1.numeroConta + "."); // Texto/ Atributo do objeto conta1 (Nesse caso o número da conta)/ Ponto final;
                Console.WriteLine("SALDO: R$ " + conta1.saldo.ToString("F2") + "."); // Texto/ Atributo do objeto conta1/ ToString para exibir casas decimais ("F + Números de casas")/ Ponto final;
                Console.WriteLine("LIMITE: R$ " + conta1.limite.ToString("F2") + ".");
            }
        }
    }


    //-----------------------------------------------------------------------------------------------------------------------


    //Aula 28 YT - CFB Cursos (Classes e objetos)/ 29 - Construtores
    namespace Classes_Objetos_Construtores
    {
        public class Jogador //Classe - Modelo base para montar objetos (Modificador de acesso como público, se vc não criar ele vem private implicitamente por padrão)
        {
            public int energia; //Variáveis (Tipo Inteiro) - com modificador de acesso público;
            public bool vivo; //Variáveis (Verdadeiro ou Falso)
            public string nome;
            //Modificador de acesso pode ser usado na classe, atributos e métodos sendo public/ private/ protectec/ package;
            public Jogador(string n) //Método construtor
            {
                energia = 100; //Atribuição de valor nesse escopo
                vivo = true; //Boolean sendo verdadeiro
                nome = n;
            }
            ~Jogador() // ~ Define método destrutor
            {
                //Destrói na memória o método construído;
                Console.WriteLine("Jogador foi destruído");
            }
        }

        class AulaTesteYT
        {
            static void Objeto()
            {
                string nome1;
                Console.WriteLine("Digite o nome do jogador 1: ");
                nome1 = Console.ReadLine();
                Jogador j1 = new Jogador(nome1); //New reserva memória para criação de objeto, ao se usar new ele cria um novo objeto na memória;
                Jogador j2 = new Jogador("Gabriel"); //Jogador = Classe de origem/ j2 = Referência (Nome do objeto)/ new = cria objeto na memória/ Jogador = Classe de origem para criação desse objeto;

                j1.energia = 50;
                j2.energia = 100;
                Console.WriteLine("Energia do jogador 1: {0}", j1.energia);
                Console.WriteLine("Energia do jogador 2: {0}", j2.energia);

                Console.WriteLine("Nome do jogador 1: ", j1.nome);
                Console.WriteLine("Nome do jogador 2: ", j2.nome);
            }
        }
    }


    //----------------------------------------------------------------------------------------------------------------------

    //Aula 34 YT - Herança
    namespace Heranca
    {
        class Veiculo //Classe Base
        {
            //Atributos
            public int rodas;
            public int velMax;
            private bool ligado;

            //Métodos
            public void ligar()
            {
                ligado = true;
            }

            public void desligar()
            {
                ligado = false;
            }

            public string getLigado()
            {
                if (ligado)
                {
                    return "Sim";
                }
                else
                {
                    return "Não";
                }
            }
        }

        class Carro : Veiculo //Nome da classe filha/ : para indicar a herança/ Nome da classe mãe
                              //Ou seja, a classe Carro (que é derivada) herda os atributos e métodos da classe Veiculo
        {
            public string nomeCarro;
            public string cor;
            public Carro(string nomeCarro, string cor)
            {
                desligar(); //Só acessa esse método se for público
                rodas = 4; //Este atributo precisa ser público para conseguir que essa classe filha tenha acesso
                velMax = 120; //Se estivesse privado não conseguiria acessar, mesmo esta filha herdando tudo da classe mãe
                this.nomeCarro = nomeCarro;
                this.cor = cor;
            }
        }

        class Aula34
        {
            static void Heranca()
            {
                Carro carro1 = new Carro("Corsa", "Prata");

                Console.WriteLine("Cor: " + carro1.cor);
                Console.WriteLine("Nome: " + carro1.nomeCarro);
                Console.WriteLine("Rodas: " + carro1.rodas);
                Console.WriteLine("Velocidade Maxima: " + carro1.velMax);
                Console.WriteLine("Ligado: " + carro1.getLigado());
            }
        }
    }



    //----------------------------------------------------------------------------------------------------------------------


    //Polimofismo - YT
    namespace Polimorfismo
    {
        class Imposto
        {
            //Métodos
            public virtual void valeAlimentacao(double salario) //Ao usar virtual estou indicando que o valor pode sofrer alterações, que o que consta dentro da chave será sobrecrito em outros escopos
            {
                Console.WriteLine("Desconto padrão do vale alimentação: R$" + (salario * 0.1));
            }
            public void valeTransporte(double salario)
            {
                Console.WriteLine("Desconto padrão do vale transporte: R$" + (salario * 0.06));
            }
        }

        class Gerente : Imposto
        {
            //Método
            public override void valeAlimentacao(double salario) //Override garante sobrescrita de método, sem uso dele o IntelliSense passa a apontar avisos de possíveis falhas
            {
                Console.WriteLine("Desconto gerente do vale alimentação: R$" + (salario * 0.15));
            }
        }

        class Atendente : Imposto
        {
            //Método
            public override void valeAlimentacao(double salario) //Override para sobrescrita de método
            {
                Console.WriteLine("Desconto atendente do vale alimentação: R$" + (salario * 0.12));
            }
        }
        class Estagiario : Imposto
        {

        }

        class PagamentoBeneficios
        {
            static void Pagamentos(string[] args)
            {
                //Instanciar Estagiário
                Imposto objetoE = new Estagiario();
                objetoE.valeAlimentacao(1000.00);
                objetoE.valeTransporte(1000.00);
                Console.WriteLine("---------------------");

                //Instanciar Gerente
                Imposto objetoG = new Gerente();
                objetoG.valeAlimentacao(5000.00);
                objetoG.valeTransporte(5000.00);
                Console.WriteLine("----------------------");

                //Instanciar Atendente
                Imposto objetoA = new Atendente();
                objetoA.valeAlimentacao(2000.00);
                objetoA.valeTransporte(2000.00);
            }
        }
    }


    //---------------------------------------------------------------------------------------------------------------------


    //Encapsulamento - YT
    namespace Encapsulamento
    {
        class Aluno
        {
            //Atributos
            private double nota1, nota2;

            //Média
            private double media()
            {
                return (nota1 + nota2) / 2;
            }

            //Mensagem
            public void mensagem()
            {
                Console.Write("Informe a primeira nota: ");
                nota1 = double.Parse(Console.ReadLine());

                Console.Write("Informe a segunda nota: ");
                nota2 = double.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("A média é: " + media().ToString("F2"));
            }
        }

        class CalculoMedia
        {
            static void Calculo(string[] args)
            {
                Aluno Joao = new Aluno();
                Joao.mensagem();
            }
        }
    }


    //----------------------------------------------------------------------------------------------------------------------


    //Aula 32 YT - Operador This
    namespace OperadorThis
    {
        class Calculos
        {
            public int v1, v2;

            public Calculos(int v1, int v2)
            {
                this.v1 = v1; //This especifíca que o primeiro v1 é o atributo (previamente declarado), e não o paramêtro que veio neste método;
                this.v2 = v2; //This aponta para o atributo correto;
            }

            public int Somar()
            {
                return v1 + v2;
            }
        }

        class Aula32
        {
            static void Soma()
            {
                Calculos calculos1 = new Calculos(10, 2);

                Console.WriteLine(calculos1.Somar());
            }
        }
    }


    //----------------------------------------------------------------------------------------------------------------------


    //Aulas Udemy
    class Program
    {
        static void Main(string[] args)
        {
            //Aula 209
            CultureInfo CI = CultureInfo.InvariantCulture; //Conversão de vírgula para ponto

            int idade;
            double salario, altura;
            char genero;
            string nome;

            idade = 32;
            salario = 4000.9;
            altura = 1.72;
            genero = 'F';
            nome = "Maria Silva";

            Console.WriteLine(idade);
            Console.WriteLine(salario);
            Console.WriteLine(altura);
            Console.WriteLine(genero);
            Console.WriteLine(nome);

            Console.WriteLine("Good morning");
            Console.WriteLine("Good evening");

            //Aula 211
            int x, y;
            x = 10;
            y = 20;

            Console.WriteLine(x);
            Console.WriteLine(y);

            double x1 = 2.3456;
            Console.WriteLine(x1.ToString("F2", CI));

            Console.WriteLine("A funcionaria " + nome + ", sexo " + genero + ", ganha "
                + salario.ToString("F2", CI) + " e tem " + idade + " anos");

            int x2, y2;
            x2 = 10;
            y2 = 20;
            Console.WriteLine(x2);
            Console.WriteLine(y2);

            int x3;
            double y3;
            x3 = 5;
            y3 = 2 * x3;
            Console.WriteLine(x3);
            Console.WriteLine(y3.ToString("F2", CI));

            //Aula 212
            double b1, b2, h, area;
            b1 = 6.0;
            b2 = 8.0;
            h = 5.0;
            area = (b1 + b2) / 2.0 * h;
            Console.WriteLine(area.ToString("F2", CI));

            int a, b;
            double resultado;
            a = 5;
            b = 2;
            resultado = (double)a / b;
            Console.WriteLine(resultado.ToString("F1", CI));

            double a1;
            int b3;
            a1 = 5.2;
            b3 = (int)a1;
            Console.WriteLine(b3);

            //Aula 213
            double salario1, salario2;
            string nome1, nome2;
            int idade1;
            char sexo;

            Console.WriteLine("Digite o nome da primeira pessoa: ");
            nome1 = Console.ReadLine();
            Console.WriteLine("Digite o salario da primeira pessoa: ");
            salario1 = double.Parse(Console.ReadLine(), CI);

            Console.WriteLine("Digite o nome da segunda pessoa: ");
            nome2 = Console.ReadLine();
            Console.WriteLine("Digite o salario da segunda pessoa: ");
            salario2 = double.Parse(Console.ReadLine(), CI);

            Console.WriteLine("Digite uma idade: ");
            idade1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o sexo (F/M): ");
            sexo = char.Parse(Console.ReadLine());

            Console.WriteLine("NOME 1 = " + nome1);
            Console.WriteLine("SALARIO 1 = " + salario1.ToString("F2", CI));
            Console.WriteLine("NOME 2 = " + nome2);
            Console.WriteLine("SALARIO 2 = " + salario2.ToString("F2", CI));
            Console.WriteLine("IDADE = " + idade1);
            Console.WriteLine("SEXO = " + sexo);


            //Aula214 - Debug
            int x4, y4, z4;

            x4 = int.Parse(Console.ReadLine());
            Console.WriteLine(x4);
            y4 = x4 * 2;
            Console.WriteLine(y4);
            z4 = int.Parse(Console.ReadLine());
            Console.WriteLine(z4);


            //Aula 215
            int hora;
            Console.WriteLine("Digite uma hora do dia: ");
            hora = int.Parse(Console.ReadLine());
            if (hora < 12)
            {
                Console.WriteLine("Bom dia!");
            }
            else
            {
                Console.WriteLine("Boa tarde");
            }

            int x5, soma3;

            soma3 = 0;
            Console.Write("Digite o primeiro numero: ");
            x5 = int.Parse(Console.ReadLine());

            while (x5 != 0)
            {
                soma3 = soma3 + x5;
                Console.Write("Digite outro numero: ");
                x5 = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("SOMA: " + soma3);


            int N, i, x6, soma4;
            Console.Write("Quantos numeros serao digitados? ");
            N = int.Parse(Console.ReadLine());

            soma4 = 0;
            for (i = 1; i <= N; i++)
            {
                Console.Write("Digite um numero: ");
                x6 = int.Parse(Console.ReadLine());
                soma4 = soma4 + x6;
            }
            Console.WriteLine("SOMA = " + soma4);


            //Aula 216 - Vetores
            int N1;
            Console.Write("Quantos numeros voce vai digitar?");
            N1 = int.Parse(Console.ReadLine());

            double[] vet = new double[N1];

            for (int i1 = 0; i1 < N1; i1++)
            {
                Console.Write("Digite um numero: ");
                vet[i1] = double.Parse(Console.ReadLine(), CI);
            }

            Console.WriteLine();

            Console.WriteLine("NUMEROS DIGITADOS: ");
            for (int i2 = 0; i2 < N1; i2++)
            {
                Console.WriteLine(vet[i2].ToString("F1", CI));
            }


            //Aula 217 - Matrizes
            int M2, N2;

            Console.Write("Quantas linhas vai ter a Matriz? ");
            M2 = int.Parse(Console.ReadLine());
            Console.Write("Quantas colunas vai ter a Matriz? ");
            N2 = int.Parse(Console.ReadLine());

            int[,] mat = new int[M2, N2];

            for (int i3 = 0; i3 < M2; i3++)
            {
                for (int j = 0; j < N2; j++)
                {
                    Console.Write("Elemento[" + i3 + "," + j + "]: ");
                    mat[i3, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine();
            Console.WriteLine("MATRIZ DIGITADA: ");

            for (int i4 = 0; i4 < M2; i4++)
            {
                for (int j2 = 0; j2 < N2; j2++)
                {
                    Console.Write(mat[i4, j2] + " ");
                }
                Console.WriteLine();
            }

            //Aula 218
            double largura, altura2, area2, perimetro, diagonal;

            Console.Write("Base do retangulo: ");
            largura = double.Parse(Console.ReadLine(), CI);
            Console.Write("Altura do retangulo: ");
            altura2 = double.Parse(Console.ReadLine(), CI);

            area2 = largura * altura2;
            perimetro = 2 * (largura + altura2);
            //diagonal = Math.Sqrt(largura * largura + altura * altura);
            diagonal = Math.Sqrt(Math.Pow(largura, 2.0) + Math.Pow(altura2, 2.0));

            Console.WriteLine("AREA = " + area2.ToString("F4", CI));
            Console.WriteLine("PERIMETRO = " + perimetro.ToString("F4", CI));
            Console.WriteLine("DIAGONAL = " + diagonal.ToString("F4", CI));


            //Aula 219
            string nome3, nome4;
            int idade3, idade4;
            double media;

            Console.WriteLine("Dados da primeira pessoa: ");
            Console.Write("Nome: ");
            nome3 = Console.ReadLine();
            Console.Write("Idade: ");
            idade3 = int.Parse(Console.ReadLine());

            Console.WriteLine("Dados da segunda pessoa: ");
            Console.Write("Nome: ");
            nome4 = Console.ReadLine();
            Console.Write("Idade: ");
            idade4 = int.Parse(Console.ReadLine());

            media = (idade3 + idade4) / 2.0;

            Console.WriteLine("A idade media de " + nome3 + " e " + nome4 + " e de " + media.ToString("F1", CI) + " anos.");

            //Aula 220
            int a4, b4, c4, menor;

            Console.Write("Primeiro valor: ");
            a4 = int.Parse(Console.ReadLine());

            Console.Write("Segundo valor: ");
            b4 = int.Parse(Console.ReadLine());

            Console.Write("Terceiro valor: ");
            c4 = int.Parse(Console.ReadLine());

            if (a4 < b4 && a4 < c4)
            {
                menor = a4;
            }
            else if (b4 < c4)
            {
                menor = b4;
            }
            else
            {
                menor = c4;
            }

            Console.WriteLine("MENOR = " + menor);

            //Aula 221
            int x7, y7;

            Console.WriteLine("Digite os dois numeros: ");
            x7 = int.Parse(Console.ReadLine());
            y7 = int.Parse(Console.ReadLine());

            while (x7 != y7)
            {
                if (x7 < y7)
                {
                    Console.WriteLine("CRESCENTE!");
                }
                else
                {
                    Console.WriteLine("DECRESCENTE!");
                }
                Console.WriteLine("Digite outros dois numeros: ");
                x7 = int.Parse(Console.ReadLine());
                y7 = int.Parse(Console.ReadLine());
            }

            //Aula 222
            int x8, y8, troca, soma5;
            Console.WriteLine("Digite dois numeros: ");
            x8 = int.Parse(Console.ReadLine());
            y8 = int.Parse(Console.ReadLine());

            if (x8 > y8)
            {
                troca = x8;
                x8 = y8;
                y8 = troca;
            }

            soma5 = 0;
            for (int i2 = x8 + 1; i2 < y8; i2++)
            {
                if (i2 % 2 != 0)
                {
                    soma5 = soma5 + i2;
                }
            }

            Console.WriteLine("SOMA DOS IMPARES = " + soma5);

            //Aula 223
            int N3;
            double soma6, media2;
            Console.Write("Quantos numeros voce vai digitar? ");
            N3 = int.Parse(Console.ReadLine());

            double[] vet2 = new double[N3];

            for (int i3 = 0; i3 < N3; i3++)
            {
                Console.Write("Digite um numero: ");
                vet2[i3] = double.Parse(Console.ReadLine(), CI);
            }

            Console.WriteLine();

            Console.Write("VALORES = ");
            for (int i3 = 0; i3 < N3; i3++)
            {
                Console.Write(vet2[i3].ToString("F1", CI) + " ");
            }

            Console.WriteLine();

            soma6 = 0;
            for (int i3 = 0; i3 < N3; i3++)
            {
                soma6 = soma6 + vet2[i3];
            }

            Console.WriteLine("SOMA = " + soma6.ToString("F2", CI));

            media2 = soma6 / N3;

            Console.WriteLine("MEDIA = " + media2.ToString("F2", CI));

            //Aula 224
            int N4, cont;
            Console.Write("Qual a ordem da matriz? ");
            N4 = int.Parse(Console.ReadLine());

            int[,] mat2 = new int[N4, N4];

            for (int i4 = 0; i4 < N4; i4++)
            {
                for (int j3 = 0; j3 < N4; j3++)
                {
                    Console.Write("Elemento [" + i4 + "," + j3 + "]: ");
                    mat2[i4, j3] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("DIAGONAL PRINCIPAL: ");
            for (int i4 = 0; i4 < N4; i4++)
            {
                Console.Write(mat2[i4, i4] + " ");
            }
            Console.WriteLine();

            cont = 0;
            for (int i4 = 0; i4 < N4; i4++)
            {
                for (int j3 = 0; j3 < N4; j3++)
                {
                    if (mat2[i4, j3] < 0)
                    {
                        cont++;
                    }
                }
            }

            Console.WriteLine("QUANTIDADE DE NEGATIVOS = " + cont);
        }

    }

}
