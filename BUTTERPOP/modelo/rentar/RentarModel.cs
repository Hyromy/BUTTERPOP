using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BUTTERPOP.modelo.rentar
{
    public class RentarModel
    {
        /// <summary>
        /// Recibe un string con fecha y hora y verifica si hay menos de 30 días
        /// respecto a la hora y fecha actual
        /// </summary>
        /// <param name="time">String con formato (yyyy-MM-dd HH:mm:ss)</param>
        /// <returns>Valor lógico sobre si la diferencia es menor a 30 días</returns>
        /// <exception cref="FormatException"></exception>
        public bool isActiveRent(String time)
        {
            String format = "yyyy-MM-dd HH:mm:ss";
            DateTime inputTime;

            try
            {
                inputTime = DateTime.ParseExact(time, format, CultureInfo.InvariantCulture);
            }
            catch
            {
                String errMessage = $"No se ha podido convertir la fecha ingresada. " +
                    $"Se requiere un formato({format})";
                throw new FormatException(errMessage);
            }

            DateTime currentTime = DateTime.Now;
            TimeSpan diference = inputTime - currentTime;
            int days = (int)diference.Days;

            Console.WriteLine(days.ToString());

            return 0 <= days && days < 30;
        }

        /// <summary>
        /// Recibe un DateTime y verifica si hay menos de 30 días respecto a la hora y fecha actual
        /// </summary>
        /// <param name="time"></param>
        /// <returns>Valor lógico sobre si la diferencia es menor a 30 días</returns>
        public bool isActiveRent(DateTime time)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan diference = time - currentTime;
            int days = (int) diference.Days;

            return 0 <= days && days < 30;
        }

        public void validateInput()
        {

        }
    }
}