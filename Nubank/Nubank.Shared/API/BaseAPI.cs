using Newtonsoft.Json;
using Nubank.API.Exceptions;
using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace Nubank.API
{
    public abstract class BaseAPI
    {
        private static HttpClient httpClient;

        static BaseAPI()
        {
            var defaultFilter = new HttpBaseProtocolFilter();
            defaultFilter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            defaultFilter.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;

            httpClient = new HttpClient(defaultFilter);
        }

        protected static async Task<bool> IsNetworkAvailable(bool showErrorMessage = true)
        {
            var isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
            string message = "Parece que você está sem internet! Por favor, verifique a sua conexão e tente novamente.";

            if (!isNetworkAvailable && showErrorMessage)
                await new MessageDialog(message).ShowAsync();

            return isNetworkAvailable;
        }

        protected static async Task<T> TryGetDeserializedAsync<T>(string uri)
        {
            return await TryGetDeserializedAsync<T>(new Uri(uri));
        }

        protected static async Task<T> TryGetDeserializedAsync<T>(Uri uri)
        {
            if (!(await IsNetworkAvailable(true))) return default(T);

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                int statusCode = (int)response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content);
                }

                else if (statusCode >= 500 && statusCode < 600)
                    throw new HttpServerGenericErrorException("Desculpe, estamos enfrentando problemas técnicos. Por favor, tente novamente mais tarde.");

                //else if (statusCode >= 400 && statusCode < 500)
                else
                    throw new HttpClientGenericErrorException("Houve algum erro com o seu pedido.");
            }
            catch (APIException e)
            {
                await new MessageDialog(e.Message).ShowAsync();
                return default(T);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception at TryGetDeserializedAsync: {0}", e);
                return default(T);
            }
        }
    }
}
