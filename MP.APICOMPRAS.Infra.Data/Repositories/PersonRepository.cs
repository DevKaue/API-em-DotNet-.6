using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MP.APICOMPRAS.Domain.Entities;
using MP.APICOMPRAS.Domain.Repositories;
using MP.APICOMPRAS.Infra.Data.Context;

namespace MP.APICOMPRAS.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        private readonly APICOMPRASDbContext _db;
        public PersonRepository(APICOMPRASDbContext db)
        {
            _db = db;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _db.People.ToListAsync();
        }
    }
}