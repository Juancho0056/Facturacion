using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VentasApp.Application.Common.Interfaces;

namespace VentasApp.Infrastructure.Services
{
    public class UtilService : IUtilService
    {

        public bool IsGuid(string guid)
        {
            Regex isGuid =
             new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$",
            RegexOptions.Compiled);

            bool isValid = false;

            if (guid != null)
            {
                if (isGuid.IsMatch(guid))
                {
                    isValid = true;
                }
            }
            return isValid;
        }
        public bool validateEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public async Task<string> getHtmlBodyAccount(string Username, string Password)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"  
<table id='m_8522219401217819128inception' align='center' bgcolor='#ffffff' cellpadding='0' cellspacing='0' >
<tbody>
   <tr>
      <td id='m_8522219401217819128outie' width='100%' style='width:100%;border-collapse:collapse;padding:32px 0'>
         <table align='center' bgcolor='white' width='100%' cellpadding='0' cellspacing='0' style='border-collapse:collapse;width:100%;max-width:570px;margin:0 auto;background:#fff;'>
            <tbody>
               <tr>
                  <td style='border-collapse:collapse;background:#fff;border-color:#172b4d !important;border-style:solid;border-width:3px 1px 1px'>
                     <table  width='100%' bgcolor='white' cellpadding='0px' cellspacing='0' style='border-collapse:collapse;max-width:100%;width:100%'>
                        <tbody>
                           <tr>
                              <td style='border-collapse:collapse;background:#172b4d !important;'>
                                 <table id='m_8522219401217819128branding' align='left' cellpadding='0' cellspacing='0' style='border-collapse:collapse;background:#172b4d !important;'>
                                    <tbody>
                                       <tr>
                                          <td id='m_8522219401217819128logo' style='border-collapse:collapse;padding:19px 0 0 32px;'>
                                             <img alt='VentasApp' border='0' height='50' src='http://energiasproductivas.com/assets/img/ep/logo-mix.png' width='150' style='outline:none;text-decoration:none;display:block;color:#2dbe60;border:none' class='CToWUd'>
                                          </td>
                                       </tr>
                                    </tbody>
                                 </table>
                              </td>
                           </tr>
                        </tbody>
                     </table>
                     <table id='m_8522219401217819128main' width='100%' cellpadding='0' cellspacing='0' style='border-collapse:collapse;max-width:100%;width:100%;'>
                        <tbody>
                           <tr>
                              <td style='border-collapse:collapse'>
                                 <table width='100%' cellpadding='32' cellspacing='0' style='border-collapse:collapse;max-width:100%;width:100%'>
                                    <tbody>
                                       <tr>
                                          <td style='border-collapse:collapse;word-wrap:break-word' align='center'>

                                             <table style='border-collapse:collapse' cellpadding='0' cellspacing='0'>
                                                <tbody>
                                                   <tr>
                                                      <td style='padding-top:24px;border-collapse:collapse;word-wrap:break-word align=center'>
                                                         <h1 class='m_8522219401217819128u-headingMobileAnchor' style= ' font-weight:normal;font-family:HelveticaNeue,helvetica,arial,sans-serif;color:#172b4d !important;font-size:24px;line-height:22px;margin:0 0 32px;text-align:center'>
                                                            ¡<span style='word-wrap:break-word;word-break:break-all'>VentasApp</span> ha compartido contigo datos de acceso al portal web!
                                                         </h1>
                                                         <table align='center' style='border-collapse:collapse;width:75%;clear:both' width='65%' cellpadding='0' cellspacing='0'>
                                                            <tbody>
                                                               <tr>
                                                                  <td style='width:100%;height:25px;border-top-width:1px;border-top-color:#e7e4e3;border-top-style:solid;border-collapse:collapse' width='100%' height='32'>&nbsp;</td>
                                                               </tr>
                                                            </tbody>
                                                         </table>
                                                      </td>
                                                   </tr>
                                                   <tr>
                                                      <td style='border-collapse:collapse;text-align:center;word-wrap:break-word'>
                                                         <p style='color:#65646a;font-family:HelveticaNeue,helvetica,arial,sans-serif;font-size:18px;line-height:24px;margin:0 0 24px'>
                                                            <span style='word-wrap:break-word;word-break:break-all'>Usuario:</span>
                                                        <span style='word-wrap:break-word;word-break:break-all'>{0}</span><br>
                                                     <span style='word-wrap:break-word;word-break:break-all'>Password:</span>
<span style='word-wrap:break-word;word-break:break-all'>{1}</span>                                                </p>
                                                      </td>
                                                   </tr>
                                                   <tr>
                                                      <td style='padding-bottom:8px;padding-top:24px;border-collapse:collapse;text-align:center' align='center'>
                                                         <div><a href='http://ventas.com/login' style='color:#4a8db8;text-decoration:none;line-height:32px;font-family:sans-serif;font-size:15px;font-weight:bold;text-align:center;border-radius:2px;display:inline-block;background:#172b4d !important;padding:0 30px;border:1px solid #172b4d !important' target='_blank' data-saferedirecturl='http://ventas.com/login'><span style='color:#fff'>
         Ir al portal                                    </span></a>
                                                         </div>
                                                      </td>
                                                   </tr>
                                                </tbody>
                                             </table>
                                          </td>
                                       </tr>
                                    </tbody>
                                 </table>
                                 <table cellpadding='32' width='100%' cellspacing='0' style='border-collapse:collapse;max-width:100%;width:100%'>
                                    <tbody>
                                       <tr>
                                          <td align='center' bgcolor='#ffffff' style='border-top-style:solid;border-top-width:1px;border-top-color:#e7e4e3;border-collapse:collapse;background:#ffffff'>
                                             <p style='text-align: left;color:#65646a;font-family:HelveticaNeue,helvetica,arial,sans-serif;font-size:12px;line-height:20px;margin:0 0 14px'>Este mensaje es solamente para la persona a la que va dirigido. Puede contener información  confidencial  o  legalmente  protegida.  Este correo ha sido enviado automaticamente, favor no responder a esta direccion de correo, ya que no se encuentra habilitada para recibir mensajes.</p>
                                          </td>
                                       </tr>
                                    </tbody>
                                 </table>
                              </td>
                           </tr>
                        </tbody>
                     </table>
                  </td>
               </tr>
            </tbody>
         </table>
         <table class='m_8522219401217819128footer' width='100%' cellpadding='20' align='center' style='border-collapse:collapse;max-width:578px;width:100%;margin:0 auto 20px auto;text-align:center'>
            <tbody>
               <tr>
                  <td>
                     <p style='color:#747778;font-size:11px;line-height:15px;text-align:center;margin-top:0;margin-bottom:0;margin-right:0;margin-left:0;padding-top:0px;padding-right:0px;padding-bottom:0px;padding-left:0px'>Para solicitudes de soporte, por favor contacta con nosotros visitando nuestra <a href='http://ventasapp.com' style='color:#4a8db8;text-decoration:none' target='_blank' data-saferedirecturl='http://ventasapp.com/'>página</a>.</p>
                     <p style='color:#747778;font-size:11px;line-height:15px;text-align:center;margin-top:0;margin-bottom:0;margin-right:0;margin-left:0;padding-top:0px;padding-right:0px;padding-bottom:0px;padding-left:0px'>Energías Productivas te ha enviado este correo electrónico.</p>
                  </td>
               </tr>
            </tbody>
         </table>
      </td>
   </tr>
</tbody>
</table>
", Username, Password);
            return sb.ToString();
        }
    }
}
