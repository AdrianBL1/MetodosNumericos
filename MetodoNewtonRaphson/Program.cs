using System;

namespace MetodoNewtonRaphson
{
    class Program
    {
        // Método Newton Raphson
        static void Main(String[] args)
        {
            double x1 = 0;
            double x2 = 0;
            int n = 0;

            Console.WriteLine("Ingresa el valor inicial: ");
            x1 = Convert.ToDouble(Console.ReadLine());

            double epsilon = 1.0e-10;

            //Se verifica que la derivada no sea igual a cero
            if (derivada(x1) == 0.0)
                Console.WriteLine("La derivada de x1 es cero");

            for (n = 0; n < 100; n++)
            {
                //Se Calcula x2
                x2 = NewtonRaphson(x1);

                //Se verifica si ya se está lo suficientemente cerca
                if (Math.Abs(x1 - x2) < epsilon)
                    break;

                //Se actualiza x1
                x1 = x2;
            }

            Console.WriteLine("Las iteraciones fueron {0}", n);
            Console.WriteLine("x={0}",x1);
        }

        static double funcion(double x)
        {
            return x * x - 2;
        }

        static double derivada(double x)
        {
            return 2 * x;
        }

        static double NewtonRaphson(double x)
        {
            return x - funcion(x) / derivada(x);
        }
    }
}