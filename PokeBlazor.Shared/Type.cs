namespace PokeBlazor.Shared
{
    public class Type
    {
        public int slot {get; set;}
        public TypeData type {get; set;}

        public string TypeName => type?.name;
    }

    public class TypeData
    {
        public string url {get;set;}
        public string name {get; set;}
    }
}