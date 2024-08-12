using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MP.APICOMPRAS.Application.DTOs;
using MP.APICOMPRAS.Application.Services.Interfaces;
using MP.APICOMPRAS.Application.Validations;
using MP.APICOMPRAS.Domain.Entities;
using MP.APICOMPRAS.Domain.Repositories;

namespace MP.APICOMPRAS.Application.Services
{
    public class PersonService : IPersonService
    {

        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail<PersonDTO>("Objeto deve ser informado");

            var result = new PersonDTOValidator().Validate(personDTO);
            if (!result.IsValid)
                return ResultService.RequestError<PersonDTO>("Problemas de validade!", result);

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreateAsync(person);
            return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
        }
    }
}