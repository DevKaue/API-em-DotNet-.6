using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.APICOMPRAS.Application.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Cellphone { get; set; } = string.Empty;
    }
}