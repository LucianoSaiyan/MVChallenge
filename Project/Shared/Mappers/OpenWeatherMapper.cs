using Project.Shared.DTOs;
using System.Collections.Generic;
using OpenWeatherEntity = Project.Entities.Model.OpenWeatherEntity;

namespace Project.Shared.Mappers
{
    public static class OpenWeatherMapper
    {
        public static OpenWeatherEntity MapDTOToEntity(OpenWeatherModelDTO dto)
        {
            OpenWeatherEntity entity = new OpenWeatherEntity()
            {
                city = dto.city,
                country = dto.country,
                datehour = dto.datehour,
                feels_like = dto.feels_like,
                Id = dto.Id,
                lat = dto.lat,
                lon = dto.lon,
                temp = dto.temp
            };
            return entity;
        }

        public static OpenWeatherModelDTO MapEntityToDTO(OpenWeatherEntity entity)
        {
            OpenWeatherModelDTO dto = new OpenWeatherModelDTO()
            {
                city = entity.city,
                country = entity.country,
                datehour = entity.datehour,
                feels_like = entity.feels_like,
                Id = entity.Id,
                lat = entity.lat,
                lon = entity.lon,
                temp = entity.temp
            };
            return dto;
        }

        public static List<OpenWeatherModelDTO> MapListEntityToDTO(List<OpenWeatherEntity> entity)
            => entity.Select(item => MapEntityToDTO(item)).ToList();

        public static List<OpenWeatherEntity> MapListDTOToEntity(List<OpenWeatherModelDTO> entity)
            => entity.Select(item => MapDTOToEntity(item)).ToList();

    }
}
