using System;

namespace PokeBlazor.Client.Helpers
{
    public static class PokemonIdValidator
    {
        /// <summary>
        /// Used to validate that a supplied Pokemon ID is both an integer
        /// and falls within the valid range
        /// </summary>
        /// <param name="pokemonId">The supplied Pokemon ID to validate</param>
        /// <param name="maxIdValue">The maximum Pokemon ID in the database</param>
        /// <remarks>
        /// The value currently used by <see cref="maxIdValue"/> is the highest value
        /// in the current version of the API.
        /// This value will need to be updated as new games are released, and new Pokemon
        /// are added to the API
        /// </remarks>
        /// <returns></returns>
        public static bool ValidateId(string pokemonId, int maxIdValue = 802)
        {
            if (string.IsNullOrWhiteSpace(pokemonId))
            {
                // ID must have a value
                return false;
            }

            if (!int.TryParse(pokemonId, out var pokeId))
            {
                // not an int
                return false;
            }
            
            return pokeId > 0 && pokeId <= maxIdValue;
        }
    }
}