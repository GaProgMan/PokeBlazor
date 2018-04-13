using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using PokeBlazor.Client.Helpers;
using PokeBlazor.Shared;

namespace PokeBlazor.Client.Services
{
    public class PokeState
    {
        public Pokemon PokemonSearchResult { get; private set; }
        public bool SearchInProgress { get; private set; }
        public bool SuppliedIdIsValid { get; private set; } = true;

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

            SuppliedIdIsValid = PokemonIdValidator.ValidateId(id);

            // only search if the ID is valid, otherwise ensure that
            // the value is null (which hides the component)
            PokemonSearchResult = SuppliedIdIsValid
                ? await http.GetJsonAsync<Pokemon>($"https://pokeapi.co/api/v2/pokemon/{id}/")
                : null;
            
            SearchInProgress = false;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
