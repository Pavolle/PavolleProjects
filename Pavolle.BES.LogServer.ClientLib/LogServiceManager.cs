using Newtonsoft.Json;
using Pavolle.BES.LogServer.Common.Enums;
using Pavolle.BES.LogServer.Common.Utils;
using Pavolle.BES.LogServer.ViewModels.Request;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System.Net.Http.Headers;
using System.Text;

namespace Pavolle.BES.LogServer.ClientLib
{
    public class LogServiceManager : Singleton<LogServiceManager>
    {
        string _serviceUrl;
        string _appCode;
        string _appId;
        private LogServiceManager() 
        {
        }

        public void Initialize(string serviceUrl)
        {
            _serviceUrl = serviceUrl;
        }

        public void SystemDebug(string message)
        {
            Log(new LogRequest
            {
                LogContent = message,
                LogLevel = ELogLevel.Debug.ToString(),
                SystemLog = true,
                SendToLogServerTime = DateTime.Now,
                UserOperationLog = false
            });
        }

        public void SystemInfo(string message)
        {
            Log(new LogRequest
            {
                LogContent = message,
                LogLevel = ELogLevel.Info.ToString(),
                SystemLog = true,
                SendToLogServerTime = DateTime.Now,
                UserOperationLog = false
            });
        }

        public void SystemWarning(string message)
        {
            Log(new LogRequest
            {
                LogContent = message,
                LogLevel = ELogLevel.Info.ToString(),
                SystemLog = true,
                SendToLogServerTime = DateTime.Now,
                UserOperationLog = false
            });
        }

        public void SystemError(string message)
        {
            Log(new LogRequest
            {
                LogContent = message,
                LogLevel = ELogLevel.Error.ToString(),
                SystemLog = true,
                SendToLogServerTime = DateTime.Now,
                UserOperationLog = false
            });
        }

        private void Log(LogRequest request)
        {
            Post<ResponseBase>(_serviceUrl, LogServerConsts.LogUrlConst.Route + "/" + LogServerConsts.LogUrlConst.SaveRoutePrefix, request);
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
                    client.DefaultRequestHeaders.Add("AppCode", _appCode);
                    client.DefaultRequestHeaders.Add("AppId", _appId);

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