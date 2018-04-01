namespace PokeBlazor.Shared
{
    public class PokemonSprite
    {
        public string back_default { get; set; }
        public string back_shiny {get; set;}
        
        public string back_female {get; set;}
        public string back_shiny_female {get; set;}

        public string front_default { get; set; }
        public string front_shiny { get; set; }
        
        public string front_female {get; set;}
        public string front_shiny_female {get; set;}

        public bool HasFrontFemale => !string.IsNullOrWhiteSpace(front_female);
        public bool HasBackFemale => !string.IsNullOrWhiteSpace(back_female);

        public bool HasFrontShiny => !string.IsNullOrWhiteSpace(front_shiny);
        public bool HasFrontShinyFemale => !string.IsNullOrWhiteSpace(front_shiny_female);

        public bool HasBackShiny => !string.IsNullOrWhiteSpace(back_shiny);
        public bool HasBackShinyFemale => !string.IsNullOrWhiteSpace(back_shiny_female);

        public bool HasFemaleImages => HasFrontFemale || HasFrontShinyFemale || HasBackShinyFemale || HasBackFemale;
    }
}