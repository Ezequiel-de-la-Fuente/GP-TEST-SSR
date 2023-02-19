using Gp.Test.Api.DTO;
using Gp.Test.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gp.Test.Interface.Mapper
{
    public  interface IPersonasMapper
    {
        Personas MapDtoToEntity(PersonasDTO persona);
        PersonasDTO MapEntityToDTO(Personas persona);
        List<Personas> MapDtoToEntity(List<PersonasDTO> personas);
        List<PersonasDTO> MapEntityToDTO(List<Personas> personas);
    }
}
