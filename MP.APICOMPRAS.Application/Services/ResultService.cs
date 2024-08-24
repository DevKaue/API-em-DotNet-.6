using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace MP.APICOMPRAS.Application.Services
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public ICollection<ErrorValidation> Errors { get; set; }

        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(e => new ErrorValidation { Field = e.PropertyName, Message = e.ErrorMessage }).ToList()
            };
        }

        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(e => new ErrorValidation { Field = e.PropertyName, Message = e.ErrorMessage }).ToList()
            };
        }

        public static ResultService Fail(string message) => new ResultService { IsSuccess = false, Message = message };
        public static ResultService<T> Fail<T>(string message) => new ResultService<T> { IsSuccess = false, Message = message };

        public static ResultService Ok(string message) => new ResultService { IsSuccess = true, Message = message };
        public static ResultService<T> Ok<T>(T data) => new ResultService<T> { IsSuccess = true, Data = data };

    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}