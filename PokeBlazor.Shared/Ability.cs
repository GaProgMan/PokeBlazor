namespace PokeBlazor.Shared
{
    public class Ability
    {
        public int slot {get; set;}
        public bool is_hidden {get; set;}
        public int weight {get; set;}
        public AbilityDetail ability{get; set;}

        public string IsHiddenString()
        {
            return is_hidden ? "true" : "false";
        }
    }
}