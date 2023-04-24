using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace FC_CIP.Models.Logica
{
    public class CL_Recursos
    {
        public static string ClearText(string texto)
        {
            // Eliminar los espacios en blanco del principio y del final de la cadena
            texto = texto.Trim();

            // Reemplazar múltiples espacios en blanco por un solo espacio
            texto = Regex.Replace(texto, @"\s+", " ");

            return texto;
        }
        
        public static string ClearText(string texto, bool SinEspacios)
        {
            // Eliminar todos los espacios en blanco de la cadena
            texto = Regex.Replace(texto, @"\s", "");

            return texto;
        }

        public static decimal ClearText(decimal number)
        {
            var result = number.ToString();
            // Eliminar todos los espacios en blanco de la cadena
            result = Regex.Replace(result, @"\s", "");

            return Decimal.Parse(result);
        }

        public static decimal ValidatePhone(decimal number)
        {
            // Expresión regular que valida números de celular de 10 dígitos
            string patron = @"^\d{10}$";
            string texto = ClearText(number.ToString(), true);
            if (Regex.IsMatch(texto, patron))
            {
                number = Decimal.Parse(texto);
                return number;
            }
            else
            {
                return 1;
            }
        }


        public static string ConvertSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            using(SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(
                    enc.GetBytes(
                        ClearText(texto)));
                foreach(byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
            }
            return Sb.ToString();
        }

        public static bool EnviarCorreo(string correo, string asunto, string mensaje)
        {
            bool result = false;
            correo = ClearText(correo);
            asunto = ClearText(asunto);
            mensaje = ClearText(mensaje);

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                // Correo desde remitente
                mail.From = new MailAddress("luisytoforever10@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("luisytoforever10@gmail.com", "lagkqawbadrfiubu"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true
                };
                smtp.Send(mail);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
             
        }

        #region Funciones Asincronas
        public static async Task<string> ClearTextAsync(string text)
        {
            // Eliminar los espacios en blanco del principio y del final de la cadena
            text = text.Trim();

            // Reemplazar múltiples espacios en blanco por un solo espacio
            text = Regex.Replace(text, @"\s+", " ");

            return await Task.FromResult(text);
        }

        public static async Task<string> ClearTextAsync(string text, bool SinEspacios)
        {
            // Eliminar todos los espacios en blanco de la cadena
            text = Regex.Replace(text, @"\s", "");

            return await Task.FromResult(text);
        }

        public static async Task<decimal> ClearTextAsync(decimal number)
        {
            var result = number.ToString();
            // Eliminar todos los espacios en blanco de la cadena
            result = Regex.Replace(result, @"\s", "");

            return await Task.FromResult(Decimal.Parse(result));
        }

        public static async Task<decimal> ValidatePhoneAsync(decimal number)
        {
            // Expresión regular que valida números de celular de 10 dígitos
            string patron = @"^\d{10}$";
            string text = number.ToString();
            if (Regex.IsMatch(text, patron))
            {
                number = Decimal.Parse(text);
                return await Task.FromResult(number);
            }
            else
            {
                throw new ArgumentException("El número de celular ingresado no es válido");
            }
        }
        #endregion

    }
}