using PeliculasCore.Entities;
using PeliculasCore.Interfaces.Repositories;
using PeliculasCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Services
{
    public class GenderService : GenercicService<Gender>, IGenderService
    {
        public GenderService(IGenericRepository<Gender> repository) : base(repository)
        {
        }
    }
}
