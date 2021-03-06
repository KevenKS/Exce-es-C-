using System;
using System.IO;
using Excecoes.Exceptions;

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

            // Estrutura Try-catch-Finally
            // Try { Execução normal do trecho do codigo que pode acarretar em uma exceção (erro)}
            // Catch (ExceçãoEspecificada var) {
            // Codigo a ser executado caso estoure a execução que voce especificou. Podendo conter varios catch, um para cada exceção especifica }
            // Finally {Finally não é obrigatorio, mas pode ser usado após o catch, para executar outra parte de codigo independentemente de ter ocorrido exceções.
            // Exemplo: Fechar arquivos ou conexão com banco de dados}

            // Exemplo : trantando exceções da classe pronta .NET SystemException (DivideByZeroException)

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

            // Exemplo 2 : Uso do bloco finally

            FileStream fs = null;
            try
            {
                fs = new FileStream(@"CaminhoDoArq.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                String line = sr.ReadLine();
                Console.WriteLine(line);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);                
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close(); // Caso arq esteja aberto, fecha-lo
                }
            }


            // Exemplo 3 : Criando exceções personalizada = ApplicationException

            try
            {
                Console.Write("Room number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Check-in date (dd/MM/yyyy): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                Reserva reserva = new Reserva(number, checkIn, checkOut);
                Console.WriteLine("Reservation: " + reserva);

                Console.WriteLine();
                Console.WriteLine("Enter data to update the reservation:");
                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                reserva.UpdateDates(checkIn, checkOut);
                Console.WriteLine("Reservation: " + reserva);
            }
            catch (FormatException e)
            {
                // Formatação não foi a esperada. Digitou string quando se esperava um int (vice-versa)
                Console.WriteLine("Error in format: " + e.Message);
            }
            catch (DomainException e)
            {
                // Exceção personalizada, para verificações no construtor e metodo (UpdateDates) da classe Reserva
                Console.WriteLine("Error in reservation: " + e.Message);
            }
            catch (Exception e)
            {
                // Caso você não preveja um erro, ele caira nessa exceção generica, atraves do upcasting
                Console.WriteLine("Unexpected error: " + e.Message);
            }

        }
    }
}
