using System;
using System.Collections.Generic;
using System.Text;

namespace Polinomial
{
    class Polynomial
    {
        private double[] coef;
        private int m_Step;

        public double[] Coef { get { return coef;} set { coef = value; } }
        public int M_Step { get { return m_Step; } set { m_Step = value; } }
        public double this[int index]
        {
            get 
            {
                return coef[index];            
            }
            set
            {
                if (value != 0 && m_Step >= 0)
                {
                    coef[index] = value;
                }

                if(value != 0 && m_Step <= 0)
                {
                    m_Step = 0;
                    coef = new double[m_Step + 1];
                    coef[index] = value;
                }
         
                if(value == 0 && m_Step >= 0)
                {
                    double[] arr = new double[this.coef.Length - 1];
                    int j = 0;
                    for (int i = 0; i < this.coef.Length; i++, j++)
                    {
                        if (i == index)
                        {
                            j--;
                            continue;
                        }
                        arr[j] = this.coef[i];
                    }

                    this.coef = arr;
                }

                if (value == 0 && m_Step <= 0) { return; }
              

            }
        
        }

        public Polynomial() { }
        public Polynomial(double [] arr, int step)
        {
            m_Step = step;
            coef = arr;
        }

        public static Polynomial operator +(Polynomial A, Polynomial B)
        {
            Polynomial C = new Polynomial();

            C.Coef = new double[A.M_Step + 1];
            C.M_Step = A.M_Step;

            for (int i = 0; i < A.Coef.Length; i++)
            {
                C.Coef[i] = A.Coef[i] + B.Coef[i];
            }

            return C;
        }


        public static Polynomial operator -(Polynomial A, Polynomial B)
        {
            Polynomial C = new Polynomial();

            C.Coef = new double[A.M_Step + 1];
            C.M_Step = A.M_Step;

            for (int i = 0; i < A.Coef.Length; i++)
            {
                C.Coef[i] = A.Coef[i] - B.Coef[i];
            }

            return C;
        }

        public static Polynomial operator *(Polynomial A, Polynomial B)
        {
            Polynomial C = new Polynomial();

            C.Coef = new double[A.M_Step + 1 + B.M_Step];
            C.M_Step = A.M_Step + B.M_Step;

            for (int i = 0; i <= A.m_Step; i++)
            {
                for (int j = 0; j <= B.m_Step; j++)
                {
                    C[i + j] += A[i] * B[j];
                }
            }

            return C;
        }

        public void Show()
        {
            for (int i = 1; i <= this.m_Step; i++)
            {
                Console.WriteLine($" + {this[i]}x^{i}");
            }
            
        }


        public static implicit operator Polynomial(double []coeff)
        {
            return new Polynomial(coeff, 0);
        }

        public void Parse(string polynom)
        {
            string[] monom = polynom.Replace(" ", String.Empty).Split('+');

            m_Step = monom.Length - 1;
            coef = new double[m_Step + 1];

            for (int i = 0; i <= m_Step; i++)
            {
                if (!double.TryParse(monom[i].Split('x')[0], out coef[i]))
                    throw new ArgumentException("Bad coefficient");
            }
        }

    }
}
