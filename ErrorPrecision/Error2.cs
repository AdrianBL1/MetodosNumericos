using System;

namespace ErrorPrecision
{
    public class Error2
    {
        public static void Error_2()
        {
            // El usar flotantes puede llevarnos a errores
            // con cosas aparentemente sencillas como usar
            // la formula general

            float a = 1;
            float b = 200000;
            float c = -3;

            float discriminante = (b * b) - (4 * a * c);
            float x1 = (-b - (float)Math.Sqrt(discriminante)) / (2 * a);
            float x2 = (-b + (float)Math.Sqrt(discriminante)) / (2 * a);

            // El error ocurre al restar b del discriminante por eso tenemos 0
            // vemos nuevamente el error de cancelacion
            Console.WriteLine("x1={0}, x2={1}, d={2}", x1, x2, discriminante);
            Console.WriteLine(" --- ");

            //

            double aD = 1;
            double bD = 200000;
            double cD = -3;

            double discriminanteD = (bD * bD) - (4 * aD * cD);
            double x1D = (-bD - Math.Sqrt(discriminanteD)) / (2 * aD);
            double x2D = (-bD + Math.Sqrt(discriminanteD)) / (2 * aD);

            Console.WriteLine("x1={0}, x2={1}, d={1}", x1D, x2D, discriminanteD);
            Console.WriteLine(" --- ");

            // Con decimal tenemos valores adecuados, pero muchas fenciones son creadas
            // para flotantes, por lo que es necesario hacer type cast

            decimal aDc = 1;
            decimal bDc = 200000;
            decimal cDc = -3;

            decimal discriminanteDc = (bDc * bDc) - (4 * aDc * cDc);
            decimal x1Dc = (-bDc - (decimal)Math.Sqrt((double)discriminanteDc)) / (2 * aDc);
            decimal x2Dc = (-bDc + (decimal)Math.Sqrt((double)discriminanteDc)) / (2 * aDc);

            Console.WriteLine("x1={0}, x2={1}, d={2}", x1Dc, x2Dc, discriminanteDc);

            Console.WriteLine(" --- ");

            // Lo mejor es que usemos double o decimal
            // Si necesitamos presicion infinita lo mejor es usar Maple o Mathematica
        }
    }
}
