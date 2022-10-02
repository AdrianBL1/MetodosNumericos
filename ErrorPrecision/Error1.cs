using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorPrecision
{
    public class Error1
    {
        // Cuando trabajamos con valores en la computadora debemos tomar
        // en cuenta que los numeros se tienen que representar con una cantidad
        // finita de bits y eso lleva a errores de precision
        public static void Error_1()
        {
            int n = 0;
            float sumatoria = 0;

            for (n = 0; n< 10000; n++)
                sumatoria += 0.1f;

            // No obtenemos
            Console.WriteLine(sumatoria);
            Console.WriteLine(" --- ");

            // Este tipo de error se conoce como error de cancelacion
            // pues elimina cifras significativas
            float a = 100.45678f;
            float b = 100.45655f;

            float c = a - b;

            // El resultado no es 0.00023
            Console.WriteLine(c);
            Console.WriteLine(" --- ");

            double sumatoriaD = 0;

            for (n = 0; n< 10000; n++)
                sumatoriaD += 0.1;

            Console.WriteLine(sumatoriaD);
            Console.WriteLine(" --- ");

            double aD = 100.45678;
            double bD = 100.45655;

            double cD = aD - bD;

            Console.WriteLine(cD);
            Console.WriteLine(" --- ");

        }
}
}
