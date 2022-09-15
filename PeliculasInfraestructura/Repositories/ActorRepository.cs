using PeliculasCore.Entities;
using PeliculasCore.Interfaces.Repositories;
using PeliculasInfraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasInfraestructura.Repositories
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
        }
    }
}
