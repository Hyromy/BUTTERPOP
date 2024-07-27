using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using BUTTERPOP.db;
using BUTTERPOP.crud.renta;
using System.Threading.Tasks;

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

        public void validateInputsCard(String number, String mm, String aa, String cvv)
        {
            if (String.IsNullOrEmpty(number) ||
                String.IsNullOrEmpty(mm) ||
                String.IsNullOrEmpty(aa) ||
                String.IsNullOrEmpty(cvv))
            {
                String reason = "Es necesario que completes todos los campos";
                throw new ArgumentNullException(reason);
            }
            else if (number.Length < 16)
            {
                String reason = "El número de tarjeta debe tener 16 digitos";
                throw new ArgumentException(reason);
            }
            else if (mm.Length < 2)
            {
                String reason = "El mes (mm) debe ser a 2 cifras";
                throw new ArgumentException(reason);
            }
            else if (aa.Length < 2)
            {
                String reason = "El año (aa) debe ser a 2 cifras";
                throw new ArgumentException(reason);
            }
            else if (cvv.Length < 3)
            {
                String reason = "La clave de seguridad debe tener 3 cifras";
                throw new ArgumentException(reason);
            }
        }

        /// <summary>
        /// Convierte un mes y año en un objeto DateTime
        /// </summary>
        /// <param name="month">mes a 2 cifras</param>
        /// <param name="year">año a 2 cifras</param>
        /// <returns>Objeto DateTime</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DateTime monthYearToDate(String month, String year)
        {
            int y = int.Parse("20" + year);
            int m = int.Parse(month);

            if (0 > m || m > 12)
            {
                throw new ArgumentOutOfRangeException("El mes solo puede ser 1 - 12");
            } 
            else
            {
                return new DateTime(y, m, 1);
            }
        }

        /// <summary>
        /// Calcula el precio de renta de una película
        /// </summary>
        /// <param name="price">precio por semana de la pelicula</param>
        /// <param name="weeks">semanas de renta</param>
        /// <returns>Precio final de la renta</returns>
        public float CalculatePrice(float price, int weeks)
        {
            float cobro = 0;
            for (int i = 1; i <= weeks; i++)
            {
                cobro += price / (int) Math.Pow(2, i - 1);
            }

            return cobro;
        }

        /// <summary>
        /// Verifica si el cliente tiene una renta activa de una película
        /// </summary>
        /// <param name="pelicula">registro de pelicula</param>
        /// <param name="cliente">registro de cliente</param>
        /// <exception cref="ArgumentException"></exception>
        public async Task ComprobateRent(Table.Pelicula pelicula, Table.Cliente cliente)
        {
            CRUD_Renta crud = new CRUD_Renta();
            List<Table.Renta> rentas = await crud.GetRentasByCorreo(cliente.correo);
            
            foreach (Table.Renta renta in rentas)
            {
                if (renta.id_pelicula == pelicula.id_pelicula &&
                    renta.fin_fecha_renta > DateTime.Now)
                {
                    String endRent = renta.fin_fecha_renta.ToString("dd/MM/yyyy HH:mm");
                    String reason = $"Ya tienes una renta activa de esta película. Tu renta termina {endRent}";
                    throw new ArgumentException(reason);
                }
            }
        }
    }
}