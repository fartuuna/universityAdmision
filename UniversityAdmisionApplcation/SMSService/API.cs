


using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace UniversityAdmisionApplcation.SMSService
{
    public class API
    {
      
        public string Username { get; set; } = "istaqaana";
        public string Password { get; set; } = "uSY1CyddGHV1/jiRNLFAUQ==";
        



        public async Task<HttpResponseMessage> SendSMS(string mobile, string message)

        {
            HttpClient client = null;
            if (client == null)
            {
                client = new HttpClient
                {
                    BaseAddress = new Uri("https://smsapi.hormuud.com/")
                };
            }

            string username = Username;
            string password = Password;
            HttpResponseMessage response =
            client.PostAsync("Token",
            new StringContent(string.Format("grant_type=password&username={0}&password={1}",
            HttpUtility.UrlEncode(username),
            HttpUtility.UrlEncode(password)), Encoding.UTF8,
            "application/x-www-form-urlencoded")).Result;

            string resultJSON = response.Content.ReadAsStringAsync().Result;

            string AccessToken = (JObject.Parse(resultJSON).SelectToken("access_token")).ToString();


            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            HttpResponseMessage Res = await client.PostAsJsonAsync("api/SendSMS", new
          
            {
                mobile = mobile,
                message = message,
            });

            // jsonser serializer = new JavaScriptSerializer();

           // if (Res.IsSuccessStatusCode == true)
           // {
               // var r = Res.Content.ReadAsStringAsync();
           // }
            
            

            return Res;
        }


    }
}
