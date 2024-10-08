﻿using FluentValidation;

namespace Planta_BackEnd.Filters
{
    public class ValidatorFilter<T> : IEndpointFilter where T : class
    {
        private readonly IValidator<T> _validator;

        public ValidatorFilter(IValidator<T> validator)
        {
            _validator = validator;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            if (context.Arguments.SingleOrDefault(x => x?.GetType() == typeof(T)) is not T validatable)
            {
                return Results.BadRequest();
            }
            var validationResult =await  _validator.ValidateAsync(validatable);
            if(!validationResult.IsValid)
            {
                var errorResponse = validationResult.Errors
                .Select(error => new
                {
                    propertyName = error.PropertyName,
                    errorMessage = error.ErrorMessage,
                });

                return Results.BadRequest(errorResponse);
            }
            return await next(context);
        }
    }
}
