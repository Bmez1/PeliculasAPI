using PeliculasCore.Entities;
using PeliculasCore.Interfaces.Repositories;
using PeliculasCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Services
{
    public class GenderService : GenercicService<Gender>, IGenderService
    {
        private readonly IGenericRepository<Gender> _repository;

        public GenderService(IGenericRepository<Gender> repository) : base(repository)
        {
            _repository = repository;
        }

        public async override Task<Gender> UpdateAsync(long id, Gender entity)
        {
            Gender genderUpdate = await _repository.GetAsync(id);
            if (genderUpdate != null)
            {
                genderUpdate.Name = entity.Name;
                genderUpdate.Id = id;
                await _repository.UpdateAsync(genderUpdate);
            }

            return genderUpdate;
        }
    }
}
