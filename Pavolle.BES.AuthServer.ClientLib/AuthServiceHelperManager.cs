using Newtonsoft.Json;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ClientLib
{
    public class AuthServiceHelperManager : Singleton<AuthServiceHelperManager>
    {
        string _appCode = "";
        string _appId = "";
        string _serviceUrl = "";

        public void Initialize(string serviceUrl, string appCode, string appId)
        {
            _appCode = appCode;
            _appId = appId;
            _serviceUrl = serviceUrl;
        }
        private AuthServiceHelperManager()
        {

        }

        public T Get<T>(string uri)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_serviceUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("AppCode", _appCode);
                    client.DefaultRequestHeaders.Add("AppId", _appId);

                    Task<HttpResponseMessage> response = client.GetAsync(string.Format("{0}/{1}", _serviceUrl, uri));

                    response.Wait();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        var task = response.Result.Content.ReadAsStringAsync();
                        task.Wait();

                        if (task.Result != null)
                        {
                            T model = JsonConvert.DeserializeObject<T>(task.Result);
                            return model;
                        }
                    }
                    else
                    {
                        var task = response.Result.Content.ReadAsStringAsync();
                        task.Wait();
                        if (task.Result != null)
                        {
                            T model = JsonConvert.DeserializeObject<T>(task.Result);
                            return model;
                        }
                        return default(T);
                    }
                }
                catch (Exception e)
                {
                    //todo Hata mekanizması eklenecek
                }

                return default(T);
            }
        }

        public T Post<T>(string uri, object param)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_serviceUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("AppCode", _appCode);
                    client.DefaultRequestHeaders.Add("AppId", _appId);

                    var json = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");


                    Task<HttpResponseMessage> response = client.PostAsync(string.Format("{0}/{1}", _serviceUrl, uri), stringContent);
                    response.Wait();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        var task = response.Result.Content.ReadAsStringAsync();
                        task.Wait();

                        if (task.Result != null)
                        {
                            T model = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(task.Result);
                            return model;
                        }
                    }
                    else
                    {
                        var task = response.Result.Content.ReadAsStringAsync();
                        task.Wait();
                        if (task.Result != null)
                        {
                            T model = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(task.Result);
                            return model;
                        }
                        return default(T);
                    }
                }
                catch (Exception e)
                {
                }

                return default(T);
            }
        }
    }
}
