using MvcCoreConciertos.Models;
using System.Net.Http.Headers;

namespace MvcCoreConciertos.Services
{
    public class ServiceApiConciertos
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceApiConciertos
            (KeysModel keys)
        {
            this.UrlApi = keys.ApiConciertos;
            this.header = new MediaTypeWithQualityHeaderValue
                ("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
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

        public async Task<List<CategoriaEvento>> GetCategoriasAsync()
        {
            string request = "api/categorias";
            List<CategoriaEvento> categorias = 
                await this.CallApiAsync<List<CategoriaEvento>>(request);
            return categorias;
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            string request = "api/eventos";
            List<Evento> eventos = 
                await this.CallApiAsync<List<Evento>>(request);
            return eventos;
        }

        public async Task<List<Evento>> GetEventosByCategoriaAsync(int idcategoria)
        {
            string request = "api/eventos/" + idcategoria;
            List<Evento> eventos =
                await this.CallApiAsync<List<Evento>>(request);
            return eventos;
        }
    }
}
