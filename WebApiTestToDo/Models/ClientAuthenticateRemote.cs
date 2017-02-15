using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApiTestToDo.Models
{
    public class ClientAuthenticateRemote
    {
        public Task<String> authenticate()
        {

            using (var client = new System.Net.Http.HttpClient())
            {

                try
                {
                    client.BaseAddress = new Uri("http://www.lowestroomrates.com");
                    var query = new System.Net.Http.FormUrlEncodedContent(new[]
                    {
                     new KeyValuePair<string, string>("sign", "tak12e"),
                     new KeyValuePair<string, string>("pin", "vS0GKOzRwyZBSJX8gO2bHH4XVYhv-bNi2Eyuf4ZhvHs1uXmTq"),
                    });

                    var result =  client.PostAsync("/src/authenticate.php", query).Result;
                    string resultContent = result.Content.ReadAsStringAsync().Result;
                    return Task.FromResult(resultContent);
                }
                catch (Exception e)
                {
                    Logging.Logger.log(e.Message);
                }
            }

            return Task.FromResult("");
        }
    }
}