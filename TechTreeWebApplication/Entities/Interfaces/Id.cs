namespace TechTreeWebApplication.Entities
{
    public interface Id<T> where T : struct
    {
        public T Id { get; init; }
    }
}
