using Project.Abtractions;

namespace Project.Entities.Model
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }

}