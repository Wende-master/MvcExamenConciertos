using ApiConciertosAWSExamen.Models;
using MvcExamenConciertos.Models;
using System.Net.Http.Headers;

namespace MvcExamenConciertos.Services
{
    public class ServiceApiConciertos
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue Header;

        public ServiceApiConciertos(KeysModel keys)
        {
            this.UrlApi = keys.ApiConciertos;
            this.Header =
                new MediaTypeWithQualityHeaderValue("application/json");

        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response =
                    await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            string request = "api/eventos";
            List<Evento> eventos =
                await this.CallApiAsync<List<Evento>>(request);
            return eventos;
        }

        public async Task<List<Evento>> FindConciertosByCategoriaAsync(int idcategoria)
        {
            string request = "api/eventos/findconciertos/" + idcategoria;
            List<Evento> eventos =
                await this.CallApiAsync<List<Evento>>(request);
            return eventos;
        }

        public async Task<List<CategoriaEvento>> GetCategoriaEventosAsync()
        {
            string request = "api/categorias";
            List<CategoriaEvento> categorias =
                await this.CallApiAsync<List<CategoriaEvento>>(request);
            return categorias;
        }
    }
}
