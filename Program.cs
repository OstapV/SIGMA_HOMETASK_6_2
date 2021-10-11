using System;

namespace Polinomial
{
    using System.Globalization;
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial A = new Polynomial();
            Console.WriteLine("Enter the grade of first polynomial:");  
            A.M_Step = Convert.ToInt32(Console.ReadLine());

            A.Coef = new double[A.M_Step + 1];
 
            Console.WriteLine("Enter the coefficients of first polynomial");
            for (int i = 0; i < A.Coef.Length; i++)
            {
                A.Coef[i] = Double.Parse(Console.ReadLine());
            }

            Polynomial B = new Polynomial();
            Console.WriteLine("Enter the grade of second polynomial:");
            B.M_Step = Convert.ToInt32(Console.ReadLine());
 
            B.Coef = new double[B.M_Step+1];
 
            Console.WriteLine("Enter the coefficients of first polynomial:");
            for (int i = 0; i < B.Coef.Length; i++)
            {
                B.Coef[i] = Double.Parse(Console.ReadLine());
            }

            Console.Write("A= ");
            A.Show();           
            Console.WriteLine("\n");
            Console.Write("B= ");
            B.Show();

            A.Coef[0] = 10;      // using indexator
            Console.Write("A= ");
            A.Show();

            Polynomial C = new Polynomial();
            C = A + B;
            Polynomial D = new Polynomial();
            D = A - B;
            Polynomial E = new Polynomial();
            E = A * B;
            Console.Write("A+B=\n");
            C.Show();
            Console.Write("A-B= ");
            D.Show();
            Console.Write("A*B= ");
            E.Show();    
            Console.ReadLine();

           

            Polynomial test = new Polynomial();
            Console.WriteLine("Please, enter polynomial: ");
            string info = Console.ReadLine();
            test.Parse(info);

        }
    }
}
