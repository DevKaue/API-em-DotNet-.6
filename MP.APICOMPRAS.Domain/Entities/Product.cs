using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MP.APICOMPRAS.Domain.Validations;

namespace MP.APICOMPRAS.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodErp { get; set; }
        public decimal Price { get; set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Product(string name, string codErp, decimal price)
        {
            Validation(name, codErp, price);
            Purchases = new List<Purchase>();
        }

        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.When(id < 0, "O Id do produto deve ser informado!");
            Id = id;
            Validation(name, codErp, price);
            Purchases = new List<Purchase>();
        }

        private void Validation(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "O Código erp deve ser informado!");
            DomainValidationException.When(price < 0, "O Price deve ser informado!");

            Name = name;
            CodErp = codErp;
            Price = price;

        }
    }
}