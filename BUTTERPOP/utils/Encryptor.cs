using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace BUTTERPOP.utils
{
    public class Encryptor
    {
        /// <summary>
        /// Convierte un valor alfanumérico a una reprecentacion decimal similar a ASCII
        /// <para>El parámetro usado puede contener '-' para indicar que es negativo</para>
        /// </summary>
        /// <param name="key">Caracter alfanumérico, puede ser un símbolo</param>
        /// <returns>valor similar a ASCII</returns>
        /// <exception cref="ArgumentException"></exception>
        public int alphaToValue(String key)
        {
            if ((!key.StartsWith("-") && key.Length >= 2) || key.Equals("-") || key.Trim().Equals(""))
            {
                String reason = $"El valor '{key}' no es válido, solo se permite un único caracter (se permiten caracteres negativos)";
                throw new ArgumentException(reason);
            }

            int value = 0;
            try
            {
                value = int.Parse(key);
            }
            catch
            {
                char[] c = key.ToCharArray();
                value = (int) c[c.Length -1] - 87;

                if (key.StartsWith("-"))
                {
                    value *= -1;
                }
            }

            return value;
        }

        /// <summary>
        /// Encripta o desencripta un texto con una llave, la cual puede contener una o varios índices
        /// </summary>
        /// <param name="input">Texto a encriptar</param>
        /// <param name="key">Llave de encriptado (único caracter por índice, puede ser negativo)</param>
        /// <returns>Texto encriptado</returns>
        /// <exception cref="ArgumentException"></exception>
        public String encrypt(String input, String[] key)
        {
            String value = "";
            int k = 0;
            char x;
            foreach (char c in input)
            {
                x = (char) (((int) c) + alphaToValue(key[k]));
                value += x;

                k++;
                if (k >= key.Length)
                {
                    k = 0;
                }
            }

            return value;
        }

        /// <summary>
        /// Convierte un texto de entrada en un hash hexadecimal
        /// </summary>
        /// <param name="input">Información de entrada</param>
        /// <param name="time">Fecha y hora de encriptación (puede ser null)</param>
        /// <param name="extraData">Información adicional para el encriptado (puede ser null)</param>
        /// <param name="id">id de encriptación</param>
        /// <returns>Hash hexadecimal del input</returns>
        /// <exception cref="ArgumentException"></exception>
        public String toHash(String input, DateTime time, String extraData, int id)
        {
            if (id == 0 || input.Length == 0)
            {
                String reason = "El id de encriptación no puede ser 0 y el input no puede estar vacío";
                throw new ArgumentException(reason);
            }

            int dirtyHash = 0;
            foreach (char c in input)
            {
                dirtyHash += alphaToValue("" + c);
            }

            if (extraData != null || extraData.Trim().Equals(""))
            {
                foreach (char e in extraData)
                {
                    dirtyHash += alphaToValue("" + e);
                }
            }

            dirtyHash += time.Year;
            dirtyHash += time.Month;
            dirtyHash += time.Day;
            dirtyHash += time.Hour;
            dirtyHash += time.Minute;
            dirtyHash += time.Second;
            dirtyHash *= input.Length;

            Conversor conv = new Conversor();

            String hashKey = conv.toBaseN(16, dirtyHash);
            String hashValue = "";
            long x = 0;
            foreach (char dH in dirtyHash.ToString())
            {
                x = ((long) dH) + alphaToValue("" + dH) * id;
                hashValue += x.ToString();
            }

            String hash16 = conv.toBaseN(16, long.Parse(hashValue));
            return hashKey + hashValue + dirtyHash + hash16;
        }
    }
}