using Gp.Test.Api.DTO;
using Gp.Test.Entity;
using Gp.Test.Interface.Mapper;

namespace Gp.Test.Mapper
{
    public class PersonaMapper : IPersonasMapper
    {
        public Personas MapDtoToEntity(PersonasDTO persona)
        {
            if (persona == null) return null;
            return new Personas
            {
                Id = persona.Id,
                Domicilio = persona.Domicilio,
                Edad = persona.Edad,
                NombreCompleto = persona.NombreCompleto,
                Profesion = persona.Profesion,
                Telefono = persona.Telefono
            };
        }

        public List<Personas> MapDtoToEntity(List<PersonasDTO> personas)
        {
            if (personas?.Count == 0) return null;
            var list = new List<Personas>();
            personas.ForEach(persona => list.Add(MapDtoToEntity(persona)));
            return list;
        }

        public PersonasDTO MapEntityToDTO(Personas persona)
        {
            if (persona == null) return null;
            return new PersonasDTO
            {
                Id = persona.Id,
                Domicilio = persona.Domicilio,
                Edad = persona.Edad,
                NombreCompleto = persona.NombreCompleto,
                Profesion = persona.Profesion,
                Telefono = persona.Telefono
            };
        }

        public List<PersonasDTO> MapEntityToDTO(List<Personas> personas)
        {
            if (personas?.Count == 0) return null;
            var list = new List<PersonasDTO>();
            personas.ForEach(persona => list.Add(MapEntityToDTO(persona)));
            return list;
        }
    }
}