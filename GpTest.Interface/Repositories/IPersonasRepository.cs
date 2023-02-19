using Gp.Test.Entity;

namespace Gp.Test.Interface.Repositories
{
    public interface IPersonasRepository
    {
        List<Personas>? GetAll();
        Personas GetBy(Guid id);
        Personas Create(Personas persona);
        Personas Update(Personas persona);
    }   
}
