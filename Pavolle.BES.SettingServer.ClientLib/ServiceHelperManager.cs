using Newtonsoft.Json;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.ClientLib
{
    internal class ServiceHelperManager : Singleton<ServiceHelperManager>
    {
        public string _appCode = "";
        public string _appId = "";

        public void Initialize(string appCode, string appId)
        {
            _appCode = appCode;
            _appId = appId;

        }
        private ServiceHelperManager()
        {

        }

        public T Get<T>(string apiUri, string uri)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("AppCode", _appCode);
                    client.DefaultRequestHeaders.Add("AppId", _appId);

                    Task<HttpResponseMessage> response = client.GetAsync(string.Format("{0}/{1}", apiUri, uri));

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

        public T Post<T>(string apiUri, string uri, object param)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var json = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");


                    Task<HttpResponseMessage> response = client.PostAsync(string.Format("{0}/{1}", apiUri, uri), stringContent);
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
