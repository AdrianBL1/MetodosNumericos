using System;

namespace MetodosRaiz
{
    class Program
    {
        // Variable auxiliar para almacenar la función que seleccionó el usuario
        static string aux;
        static void Main(string[] args)
        {
            string op; //Variable para guardar la opcion que seleccionó el usuario
            // Todas las funciones definidas
            string[] funciones = new string[] { "f(x) = e^(-x) (1/2 cos(x) + 3.2 sin(x))", };

            double a, b, tol;
            a = b = tol = 0;

            // Menu principal
            while (true)
            {
                Console.WriteLine("\n////// Calcular la raiz de... //////");
                Console.WriteLine("\n------ Funciones ------");
                Console.WriteLine($"\n1) {funciones[0]}");
                Console.WriteLine("2) Salir");
                Console.WriteLine("\n Seleccione una opcion");
                Console.Write("  > ");
                op = Console.ReadLine();
                aux = op;

                if (op.Equals("1"))
                {
                    // Se le piden al usuario el rango en donde se encuentra la raiz que 
                    // desea calcular antes de seleccionar el metodo para calcularla.
                    // Si los datos no son validos se vuelven a pedir.
                    while (true)
                    {
                        Console.WriteLine("\n\n --- Ingrese el rango de la raiz a calcular ---");
                        Console.Write("  > a = ");
                        a = Convert.ToDouble(Console.ReadLine());
                        Console.Write("  > b = ");
                        b = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("\n\n --- Ingrese la tolerancia mayor a 0 ---");
                        Console.Write("  > tol = ");
                        tol = Convert.ToDouble(Console.ReadLine());

                        if (HayRaiz(a, b) && tol > 0) break;
                        else Console.WriteLine($"\n Error: no hay raiz en rango[{a}, {b}] o la tolerancia es invalida ):");
                    }

                    // Menu para seleccionar el metodo a ejecutar para calcular la raiz de 
                    // la funcion previamente seleccionada por el usuario.
                    while (true)
                    {
                        Console.WriteLine("\n\n////// Metodos para calcular la raiz //////");
                        Console.WriteLine($"{funciones[Convert.ToInt16(aux) - 1]}  -------->   [{a}, {b}] con una tolerancia de menor a {tol}%\n");
                        Console.WriteLine("\n1) Metodo de Biseccion");
                        Console.WriteLine("2) Metodo de La Regla Falsa");
                        Console.WriteLine("3) Metodo de Newton-Raphson");
                        Console.WriteLine("4) Metodo de la Secante");
                        Console.WriteLine("5) Regresar");
                        Console.WriteLine("\n Seleccione una opcion");
                        Console.Write("  > ");
                        op = Console.ReadLine();

                        if (op.Equals("1")) Console.WriteLine("\n - Raiz ---> " + MetodoBiseccion(a, b, tol));
                        else if (op.Equals("2")) Console.WriteLine("\n - Raiz ---> " + MetodoReglaFalsa(a, b, tol));
                        else if (op.Equals("3"))
                        {
                            double pInicial;

                            while (true)
                            {
                                Console.WriteLine("\n\n --- Ingrese el punto inicial ---");
                                Console.Write("\n > ");
                                pInicial = Convert.ToDouble(Console.ReadLine());

                                if (pInicial >= a && pInicial <= b) break;
                                else Console.WriteLine($"\n Error: el punto inicial no se encuentra dentro del rango [{a}, {b}]");
                            }

                            Console.WriteLine("\n - Raiz ---> " + MetodoNewtonRaphson(a, b, pInicial, tol));
                        }
                        else if (op.Equals("4")) Console.WriteLine("\n - Raiz ---> " + MetodoSecante(a, b, tol));
                        else if (op.Equals("5")) break;
                        else Console.WriteLine($"\n  - La opcion {op} no existe, intentelo de nuevo :(");
                    }
                }
                else if (op.Equals("2"))
                {
                    Console.WriteLine("\n  - Bye\n");
                    break;
                }
                else
                {
                    Console.WriteLine($"\n  - La opcion {op} no existe, intentelo de nuevo :(");
                }
            }
        }

        // Funcion que devuelve el valor de la funcion seleccionada por el usuario en el 
        // primer menu con ayuda de la variable auxiliar.
        static double f(double x) { return Math.Exp(-x) * (0.5 * Math.Cos(x) + 3.2 * Math.Sin(x)); }

        // Funcion que devuelve el valor de la funcion resultante de ka derivada
        // de la funcion original (seleccionada por el usuario en el 
        // primer menu) con ayuda de la variable auxiliar.
        static double Df(double x)
        {
            return Math.Exp(-x) * (2.7 * Math.Cos(x) - 3.7 * Math.Sin(x));
        }

        // Funcion para comprobar si existe raiz en un rango.
        // La funcion recibe el rango a validar con los valores
        // a y b, esta devuelve true si existe raiz, de lo 
        // contrario devuelve false.
        static Boolean HayRaiz(double a, double b)
        {
            if (f(a) * f(b) < 0) return true;
            else return false;
        }

        // Funcion que devuelve el punto medio de un rango.
        // recibe como parametros a y b que conforman el
        // rango a utilizar.
        static double PuntoMedio(double a, double b) { return (a + b) / 2; }

        // Funcion que devuelve el valor absoluto de un
        // numero.
        static double Abs(double n)
        {
            if (n < 0) return n * -1;
            else return n;
        }

        // Funcion que devulve el error de aproximacion.
        // Recibe como parametro una aproximacion previa
        // (preAprox) y una aproximacion posterior (posAprox)
        static double Error(double preAprox, double posAprox)
        {
            return Abs((posAprox - preAprox) / posAprox) * 100;
        }

        // Funcion que ejecuta el metodo de biseccion para calcular
        // la raiz que se encuentra en el rango [a, b] tomando en 
        // cuenta una tolerancia dada por el usuario.
        // Devuelve como valor la aproximacion a la raiz deseada.
        static double MetodoBiseccion(double a_, double b_, double tol)
        {
            double a, b, preM, posM;
            preM = posM = 0;
            a = a_;
            b = b_;

            while (true)
            {
                //Console.WriteLine($"\n[ a = {a}, b = {b} ]");
                // Se calcula el punto medio
                posM = PuntoMedio(a, b);

                // Si exite raiz entre a y el punto medio
                // el nuevo rango será [a, puntoMedio].
                // de lo contrario el rango será [b, puntoMedio].
                //Console.WriteLine($"f({a}) = {f(a)}, f({posM}) = {f(posM)}");
                if (HayRaiz(a, posM)) b = posM;
                else a = posM;

                // Cuando el error sea menor a la tolerancio
                // se muestra el error y se detiene el ciclo.
                if (Error(preM, posM) < tol)
                {
                    Console.WriteLine($"\n - Error ---> {Error(preM, posM)}");
                    break;
                }

                // La aproximacion actual pasa a ser la aproximacion
                // anterior.
                preM = posM;
            }

            // Una vez acabado el ciclo, posM es la aproximacion deseada
            // y se devuelve como valor de la funcion.
            return posM;
        }

        static double MetodoReglaFalsa(double a_, double b_, double tol)
        {
            double a, b, preC, posC;
            a = a_;
            b = b_;
            preC = posC = 0;

            while (true)
            {
                // Se calcula la aproximacion siguiente
                //Console.WriteLine(posC);
                posC = a - ((f(a) * (b - a)) / (f(b) - f(a)));
                // Si la raiz se encuentra en el rango [a, nuevo punto]
                // pasará a ser el nuevo rango, de no ser asi el rango
                // será [b, nuevo punto].
                if (HayRaiz(a, posC)) b = posC;
                else a = posC;

                // Si el error es menor a la tolerancia, se imprime
                // el error y se detiene el ciclo.
                if (Error(preC, posC) < tol)
                {
                    Console.WriteLine($"\n - Error ---> {Error(preC, posC)}");
                    break;
                }

                // La aproximacion actual pasa a ser la aproximacion
                // anterior.
                preC = posC;
            }

            // Una vez acabado el ciclo, posC es la aproximacion deseada
            // y se devuelve como valor de la funcion.
            return posC;
        }

        static double MetodoNewtonRaphson(double a_, double b_, double p, double tol)
        {
            double a, b, preP, posP;
            a = a_;
            b = b_;
            preP = p;

            while (true)
            {
                // Se calcula la siguiente aproximacion o el 
                // nuevo punto.
                posP = preP - (f(preP) / Df(preP));

                // Si el error es menor a la tolerancia se imprime
                // el error y el ciclo se detiene.
                if (Error(preP, posP) < tol)
                {
                    Console.WriteLine($"\n - Error ---> {Error(preP, posP)}");
                    break;
                }
                // La aproximacion actual pasa a ser la aproximacion
                // anterior.
                preP = posP;
            }

            // Una vez acabado el ciclo, posP es la aproximacion deseada
            // y se devuelve como valor de la funcion.
            return posP;
        }

        static double MetodoSecante(double a_, double b_, double tol)
        {
            double p0, p1, p;

            p0 = a_;
            p1 = b_;
            p = 0;

            while (true)
            {
                // Se calcula la siguiente aproximacion o el 
                // nuevo punto.
                p = p1 - ((f(p1) * (p1 - p0)) / (f(p1) - f(p0)));

                // Si el error es menor a la tolerancia se imprime
                // el error y el ciclo se detiene.
                if (Error(p0, p1) < tol)
                {
                    Console.WriteLine($"\n - Error ---> {Error(p, p1)}");
                    break;
                }

                p0 = p1;
                p1 = p;
            }
            // Una vez acabado el ciclo, posC es la aproximacion deseada
            // y se devuelve como valor de la funcion.
            return p1;
        }
    }
}