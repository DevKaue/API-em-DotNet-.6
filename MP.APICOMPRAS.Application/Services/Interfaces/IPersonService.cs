using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MP.APICOMPRAS.Application.DTOs;

namespace MP.APICOMPRAS.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
        Task<ResultService<ICollection<PersonDTO>>> GetAsync();
        Task<ResultService<PersonDTO>> GetByIdAsync(int id);
    }
}