using System;

namespace MedodoBiseccion
{
    class Program
    {
        //Metodo Biseccion
        static void Main(String[] args)
        {
            double x1 = 0;
            double x2 = 0;
            double x3 = 0;

            int conteo = 0;
            int n = 100;
            double epsilon = 1.0e-10;

            //Se solicita el valor de x1
            Console.WriteLine("Ingresa el valor de x1");
            x1 = Convert.ToDouble(Console.ReadLine());

            //Se solicita el valor de x2
            Console.WriteLine("Ingresa el valor de x2");
            x2 = Convert.ToDouble(Console.ReadLine());

            //Se lleva a cabo la biseccion
            while (!(funcion(x3) == 0.0 && Math.Abs(x1 - x2) < epsilon))
            {
                x3 = (x1 + x2) / 2.0;

                if (funcion(x1) * funcion(x3) < 0)
                    x2 = x3;
                else x1 = x3;

                conteo++;
                Console.WriteLine("{0} {1}", conteo, x3);

                if (conteo > 100)
                    break;
            }

            Console.WriteLine("La iteraciones fueron {0}", conteo);
            Console.WriteLine("x={0}", x1);
        }

        //Se define la funcion a la que se le desea encontrar la raiz
        static double funcion(double x)
        {
            return (-4 * x * x * x) + (6 * x * x) + 2 * x;
        }
    }
}