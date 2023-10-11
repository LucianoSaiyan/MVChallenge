using Project.Abtractions;

namespace Project.Entities.Model
{    
    public class OpenWeatherEntity : Entity
    {
        public OpenWeatherEntity()
        {

        }
        public DateTime datehour { get; set; }
        //agregar otra entidad de country para que sea clave primaria
        public string country { get; set; }
        public string city { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string temp { get; set; }
        public string feels_like { get; set; }
    }
}