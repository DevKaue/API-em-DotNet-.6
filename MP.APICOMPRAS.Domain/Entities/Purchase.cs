using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MP.APICOMPRAS.Domain.Validations;

namespace MP.APICOMPRAS.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PersonId { get; set; }
        public DateTime Date { get; set; }
        public Person Person { get; set; }
        public Product Product { get; set; }
        public Purchase(int productId, int personId)
        {
            Validation(productId, personId);
        }

        public Purchase(int id, int productId, int personId)
        {
            DomainValidationException.When(id < 0, "O Id deve ser informado!");
            Id = id;
            Validation(productId, personId);
        }

        private void Validation(int productId, int personId)
        {
            DomainValidationException.When(productId < 0, "O Id do produto deve ser informado!");
            DomainValidationException.When(personId < 0, "O Id da pessoa deve ser informado!");
            // DomainValidationException.When(!date.HasValue, "A data da compra deve ser informada!");

            PersonId = personId;
            ProductId = productId;
            Date = DateTime.Now;

        }
    }


}