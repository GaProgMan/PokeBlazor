using System.Collections.Generic;
using System.Linq;

namespace PokeBlazor.Shared
{
    public class Pokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool is_default { get; set; }
        public int base_experience {get; set;}
        public int weight {get; set;}
        public int height {get; set;}
        public PokemonSprite sprites { get; set; }
        public List<Ability> abilities {get; set;}
        public List<Stats> stats {get; set;}
        public List<Type> types {get; set;}

        public List<Type> OrderedTypes => types != null ? types.OrderBy(t => t.slot).ToList() : new List<Type>();
    }
}