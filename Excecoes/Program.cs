using System;

namespace Excecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exceção é um obj herdado das subclasses SystemException ou ApplicationException
            // SystemException é exceções de sistemas, feita pelo .NET

            //Exception
            //      SystemException
            //          IndexOutOfRangeException (Tenta acessar a posição de um array e ela não existe)
            //          NullReferenceException
            //          InvalidCastException
            //          OutOfMemoryException
            //          ArgumenteException
            //              ArgumentNullException
            //              ArgumenteOutOfRangeException
            //          ExternalException
            //              ComExcepiton
            //              SEHException
            //          ArithmeticException
            //              DivideByZeroException
            //              OverflowException (Estourar o limite de um certo numero)

            // ApplicationException = é exceções personalizadas pelo programador

            // Quando você não trata uma exceção, seu programa quebra, mostrando a linha do erro, a exceção estourada indentificada pelo sistema e uma msg padrão

            // Estrutura Try-catch
            // Try { Execução normal do trecho do codigo que pode acarretar em uma exceção (erro)}
            // Catch (ExceçãoEspecificada var)
            // { Codigo a ser executado caso estoure a execução que voce especificou. Podendo conter varios catch, um para cada exceção especifica }

            // Exemplo : trantando exceções da classe pronta .NET SystemException

            try
            {
                int n1 = int.Parse(Console.ReadLine());
                int n2 = int.Parse(Console.ReadLine());
                int r = n1 / n2;
                Console.WriteLine(r);
            }
            catch (DivideByZeroException)
            {
                // Se tentar dividir por zero, vai estourar essa exceção
                Console.WriteLine("Divisão por zero não é permitida");
            }
            catch (FormatException e)
            {
                // Se tentar digitar letra ao inves de numero, sendo que o programa espera um int
                // Mostrei minha msg 'Erro', mas também trouxe a msg padrão desta exceção, usando a variavel 'e'
                Console.WriteLine("Erro! " + e.Message);
            }
        }
    }
}
