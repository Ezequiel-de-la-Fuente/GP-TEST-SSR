namespace Gp.Test.Repository
{
    using Gp.Test.Entity;
    using Gp.Test.Interface.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class PersonasRepository : IPersonasRepository
    {
        IConfiguration configuration;
        private readonly TestContext _dbContext;
     
        public PersonasRepository(TestContext context, IConfiguration configuration)
        {
            _dbContext = context;
            this.configuration = configuration;
        }

        List<Personas>? IPersonasRepository.GetAll()
        {
            return _dbContext.Personas.ToList();
        }

        public Personas GetBy(Guid id)
        {
            return _dbContext.Personas.FirstOrDefault(GetExpressionById(id));
        }

        public Personas Create(Personas persona)
        {
            _dbContext.Entry(persona).State = EntityState.Added;
            _dbContext.SaveChanges();
            return persona;
        }

        public Personas Update(Personas persona)
        {
            _dbContext.Entry(persona).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return persona;
        }

        private Expression<Func<Personas, bool>> GetExpressionById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}