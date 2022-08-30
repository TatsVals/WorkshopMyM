using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;
using System.Net.Mail;

namespace WBL
{
    public interface IRecuperarClaveService
    {
        Task<RecuperarClaveEntity> Recuperar(RecuperarClaveEntity entity);
    }

    public class RecuperarClaveService : IRecuperarClaveService
    {
        private readonly IDataAccess sql;

        public RecuperarClaveService(IDataAccess _sql)
        {
            sql = _sql;
        }

        /*public async Task<RecuperarClaveEntity> Recuperar(RecuperarClaveEntity entity)
        {
            try
            {
                var result = await sql.QueryFirstAsync<RecuperarClaveEntity>("EnvioClaveTemporal", new
                {

                    entity.Nombre_Usuario,
                    entity.Correo

                });

                return result;


            }
            catch (Exception ex)
            {

                throw;
            }


        }*/
        public async Task<RecuperarClaveEntity> Recuperar(RecuperarClaveEntity entity)
        {
            try
            {
                Random rnd = new Random();
                entity.ClaveTemporal = rnd.Next(100000, 1000000);
                var result = await sql.QueryFirstAsync<RecuperarClaveEntity>("ClaveTemporal", new
                {

                    entity.Nombre_Usuario,
                    entity.Correo,
                    entity.ClaveTemporal

                });

                if (result.CodeError == 0)
                {
                    string EmailOrigen = "tallermymsystem@gmail.com";
                    String ClaveOrigen = "";
                    String ClaveTemporal = entity.ClaveTemporal.ToString();
                    string EmailDestino = entity.Correo;

                    MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Clave Temporal", "<h3> Su clave temporal es: " + ClaveTemporal + "</ h3 >");

                    oMailMessage.IsBodyHtml = true;

                    SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
                    oSmtpClient.EnableSsl = true;
                    oSmtpClient.UseDefaultCredentials = false;
                    //oSmtpClient.Host = "smtp.gmail.com";
                    oSmtpClient.Port = 587;
                    oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, ClaveOrigen);
                    oSmtpClient.Send(oMailMessage);
                    oSmtpClient.Dispose();

                    return result;
                }
                   else          

                return result;
                


            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
