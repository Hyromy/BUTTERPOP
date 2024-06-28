using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUTTERPOP.utils
{
    public class Conversor
    {
        /// <summary>
        /// Convierte un número decimal a su equivalente en una base 'n' entre 2 (0 - 1) y 36 (0 - z)
        /// </summary>
        /// <param name="baseNumber">Valor de la base a convertir</param>
        /// <param name="decNumber">Número de entrada en base 10</param>
        /// <returns>Conversión del número ingresado en la base especificada</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public String toBaseN(int baseNumber, long decNumber)
        {
            if (2 > baseNumber || baseNumber > 36)
            {
                String reason = "Base numérica no soportada, valores disponibles: 2 - 36";
                throw new ArgumentOutOfRangeException(reason);
            }

            int size = (int) Math.Floor(Math.Log(baseNumber, decNumber) + 1);
            long[] cells = new long[size];
            int i = 0;
            while (decNumber >= baseNumber)
            {
                cells[i] = decNumber %  baseNumber;
                decNumber = (int) (decNumber / baseNumber);
                i++;
            }
            cells[size - 1] = decNumber;
            cells.Reverse();

            String value = "";
            for (int it = 0; it < cells.Length; it++)
            {
                if (cells[it] >= 10)
                {
                    value += (char) (cells[it] + 87);
                }
                else
                {
                    value += cells[it].ToString();
                }
            }

            return value;
        }

        /// <summary>
        /// Convierte un número de una base 'n' entre 2 (0 - 1) y 36 (0 - z) a su equivalente decimal
        /// </summary>
        /// <param name="baseNumber">Valor de la base a convertir</param>
        /// <param name="number">Número de entrada en base 'n'</param>
        /// <returns>Conversión del número ingresado en base 10</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="FormatException"></exception>
        public int toBase10(int baseNumber, String number)
        {
            if (2 > baseNumber || baseNumber > 36)
            {
                String reason = "Base numérica no soportada, valores disponibles: 2 - 36";
                throw new ArgumentOutOfRangeException(reason);
            }

            int output = 0;
            int x = 0;
            int exp = number.Length - 1;
            foreach(char c in number)
            {
                if (char.IsDigit(c))
                {
                    x = int.Parse(c.ToString());
                }
                else
                {
                    x = (int) c - 87;
                }

                if (x >= baseNumber)
                {
                    String reason = $"No es posible convertir {c} a base {baseNumber.ToString()}";
                    throw new FormatException(reason);
                }

                output += (int) (x * Math.Pow(baseNumber, exp));
                exp--;
            }

            return output;
        }
    }
}