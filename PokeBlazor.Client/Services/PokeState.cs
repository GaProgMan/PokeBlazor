using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using PokeBlazor.Shared;

namespace PokeBlazor.Client.Services
{
    public class PokeState
    {
        public Pokemon PokemonSearchResult { get; private set; }
        public bool SearchInProgress { get; private set; }

        // Lets components receive change notifications
        // Could have whatever granularity you want (more events, hierarchy...)
        public event Action OnChange;

        // Receive 'http' instance from DI
        private readonly HttpClient http;
        public PokeState(HttpClient httpInstance)
        {
            http = httpInstance;
        }

        public async Task GetPokemon(string id)
        {
            SearchInProgress = true;
            NotifyStateChanged();
            
            PokemonSearchResult = await http.GetJsonAsync<Pokemon>($"https://pokeapi.co/api/v2/pokemon/{id}/");
            
            SearchInProgress = false;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
