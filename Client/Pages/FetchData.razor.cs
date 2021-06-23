using BlazorApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Pages
{
    [Authorize]
    public partial class FetchData
    {
        private WeatherForecast[] forecasts;

        [Inject]
        private HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("/api/WeatherForecast");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
