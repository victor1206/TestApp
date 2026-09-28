using TestApp.DTO.CategoriaDTO;
using TestApp.DTO.ProyectoDTO;
using System.Net.Http.Headers;

namespace TestApp.Service
{
    public class ProyectoService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public ProyectoService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<List<ProyectoSalidaDTO>> GetProyecto()
        {
            try
            {
                var token = await _authService.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("El token es nulo o invalido. Iniciar sesión");
                }

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetFromJsonAsync<List<ProyectoSalidaDTO>>("api/proyectos/lista");

                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al obtener los proyectos. Revisar conexión a internet.");
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado al obtener los proyectos.");
            }

        }

        public async Task<ProyectoSalidaDTO> GetProyectoId(Int32 pId)
        {
            try
            {
                var token = await _authService.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("El token es nulo o invalido. Iniciar sesión");
                }

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetFromJsonAsync<ProyectoSalidaDTO>("api/proyectos/" + pId);

                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al obtener el proyecto seleccionado. Revisar conexión a internet.");
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado al obtener el proyecto seleccionado.");
            }

        }

        public async Task<bool> PostProyecto(ProyectoGuardarDTO proyectoGuardar)
        {
            try
            {
                var token = await _authService.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("El token es nulo o invalido. Iniciar sesión");
                }

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.PostAsJsonAsync("api/proyectos", proyectoGuardar);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al guardaar el proyecto. Revisar conexión a internet.");
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado al guardar el proyecto.");
            }

        }

        public async Task<bool> PutProyecto(ProyectoModificarDTO proyectoModificar)
        {
            try
            {
                var token = await _authService.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("El token es nulo o invalido. Iniciar sesión");
                }

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.PutAsJsonAsync("api/proyectos/" + proyectoModificar.id, proyectoModificar);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al modificar el proyecto. Revisar conexión a internet.");
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado al guardar el proyecto.");
            }

        }

        public async Task<bool> DeleteProyecto(Int32 pId)
        {
            try
            {
                var categoria = new CategoriaModificarDTO { id = pId };
                var token = await _authService.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("El token es nulo o invalido. Iniciar sesión");
                }

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.DeleteAsync("api/proyectos/" + pId.ToString());

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al eliminar el proyecto. Revisar conexión a internet.");
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado al eliminar el proyecto.");
            }

        }

    }
}
