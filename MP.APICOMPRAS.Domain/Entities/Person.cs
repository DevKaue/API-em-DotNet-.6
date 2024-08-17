using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MP.APICOMPRAS.Domain.Validations;

namespace MP.APICOMPRAS.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Cellphone { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Person(string document, string name, string cellphone)
        {
            Validation(document, name, cellphone);
            Purchases = new List<Purchase>();
        }

        public Person(int id, string document, string name, string cellphone)
        {
            DomainValidationException.When(id < 0, "O Id deve ser maior que zero!");
            Id = id;
            Validation(document, name, cellphone);
            Purchases = new List<Purchase>();
        }

        private void Validation(string document, string name, string cellphone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(document), "O documento deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(cellphone), "O celular deve ser informado!");

            Name = name;
            Document = document;
            Cellphone = cellphone;

        }
    }
}