using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using RCMS.Entities;
using RCMS.Manager;
using RCMS.Manager.Interface;
using RCMS.Manager.Manager;

namespace RCMS.WEB
{
    public static class AuditManager
    {

        public static Audit GetAuditLog()
        {
            try
            {
                //  var x = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                Audit audit = new Audit();
                string PCName = Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]).HostName;
            
                //  var  userAgent = Request.Headers["User-Agent"]; 
               
                if (HttpContext.Current.Request.UserAgent != null)
                {
                    string strUserAgent = HttpContext.Current.Request.UserAgent.ToString().ToLower();
                    try
                    {
                        audit.OsInfo = strUserAgent.Split('(', ')')[1];

                    }
                    catch (Exception)
                    {

                        audit.OsInfo = "Not Found";
                    }

                }
                if (HttpContext.Current.Request.UrlReferrer != null)
                {
                    audit.RequestedUrl = HttpContext.Current.Request.UrlReferrer.AbsolutePath;
                }
                else
                {
                    audit.RequestedUrl = "";
                }


                audit.Url = HttpContext.Current.Request.Url.AbsolutePath;
              
                string ip = HttpContext.Current.Request.UserHostAddress;
             //   GetUserCountryByIp(ip);
         //     var x=  QueryGeographicalLocationAsync(ip);
                audit.Browser = HttpContext.Current.Request.Browser.Browser;
                audit.IpAddress = ip;
                audit.PcName = PCName;
               
                audit.AuditTime = DateTime.Now;
                
                return audit;
            }
            catch (Exception ex)
            {

                Audit audit = new Audit();
                audit.Browser = ex.Message;
                audit.IpAddress = "N/A";
                return audit;
            }
        }
       
         public static void AuditOperation()
        {
             try
             {
                 IAuditDbManager _auditManager = new AuditDbManager();
                 var data = GetAuditLog();
                 _auditManager.SaveAuditLog(data);
             }
            catch (Exception ex)
            {

               
                //return audit;
            }
        }
         public static void AuditOperation(string msg)
         {
             try
             {
                 IAuditDbManager _auditManager = new AuditDbManager();
                 var data = GetAuditLog();
                 data.Message = msg;
                 _auditManager.SaveAuditLog(data);
             }
             catch (Exception ex)
             {


                 //return audit;
             }
         }
         public static void AuditOperation(string msg,bool isAdmin)
         {
             try
             {
                 IAuditDbManager _auditManager = new AuditDbManager();
                 var data = GetAuditLog();
                 data.Message = msg;
                 data.IsAdmin = isAdmin;
                 _auditManager.SaveAuditLog(data);
             }
             catch (Exception ex)
             {


                 //return audit;
             }
         }
        //public static string GetUserCountryByIp(string ip)
        //{
        //    try
        //    {
        //        string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
        //      //  ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
        //      //  RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
        //      //  ipInfo.Country = myRI1.EnglishName;
        //    }
        //    catch (Exception)
        //    {
        //      //  ipInfo.Country = null;
        //    }

        //  //  return ipInfo.Country;
        //    return null;
        //}
        //public class IPGeographicalLocation
        //{
        //    [JsonProperty("ip")]
        //    public string IP { get; set; }

        //    [JsonProperty("country_code")]

        //    public string CountryCode { get; set; }

        //    [JsonProperty("country_name")]

        //    public string CountryName { get; set; }

        //    [JsonProperty("region_code")]

        //    public string RegionCode { get; set; }

        //    [JsonProperty("region_name")]

        //    public string RegionName { get; set; }

        //    [JsonProperty("city")]

        //    public string City { get; set; }

        //    [JsonProperty("zip_code")]

        //    public string ZipCode { get; set; }

        //    [JsonProperty("time_zone")]

        //    public string TimeZone { get; set; }

        //    [JsonProperty("latitude")]

        //    public float Latitude { get; set; }

        //    [JsonProperty("longitude")]

        //    public float Longitude { get; set; }

        //    [JsonProperty("metro_code")]

        //    public int MetroCode { get; set; }

        //    private IPGeographicalLocation() { }

           
        //}
        //public static async Task<IPGeographicalLocation> QueryGeographicalLocationAsync(string ipAddress)
        //{
        //    ipAddress = "192.168.1.50";
        //    HttpClient client = new HttpClient();
        //    var url = String.Format(@"http://api.ipstack.com/{0}?access_key=49b60cc2a88e3b3c4e2fd414326ec900",
        //        ipAddress);
        //    string info = new WebClient().DownloadString(url);
        //  //  string result = await client.DownloadString(String.Format(@"http://api.ipstack.com/{0}? access_key = 49b60cc2a88e3b3c4e2fd414326ec900,", ipAddress));

        //   // return JsonConvert.DeserializeObject<IPGeographicalLocation>(result);
        //    return null;
        //    ;
        //}
    }
}