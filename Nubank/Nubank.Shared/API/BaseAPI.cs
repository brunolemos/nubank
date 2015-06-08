using Newtonsoft.Json;
using Nubank.API.Exceptions;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Nubank.API
{
    public abstract class BaseAPI
    {
        private static HttpClient httpClient = new HttpClient();

        protected static async Task<T> TryGetDeserializedAsync<T>(string uri)
        {
            return await TryGetDeserializedAsync<T>(new Uri(uri));
        }

        protected static async Task<T> TryGetDeserializedAsync<T>(Uri uri)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                int statusCode = (int)response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content);
                }

                else if (!NetworkInterface.GetIsNetworkAvailable())
                    throw new NoInternetAvailableException("Parece que você está sem internet! Por favor, verifique a sua conexão e tente novamente.");

                else if (statusCode >= 500 && statusCode < 600)
                    throw new HttpServerGenericErrorException("Desculpe, estamos enfrentando problemas técnicos. Por favor, tente novamente mais tarde.");

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
