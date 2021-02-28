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
        }
    }
}
