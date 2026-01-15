using FluentValidation;

namespace Product_Catalog_API.Helpers;

public class ValidationFilter<T> : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context, 
        EndpointFilterDelegate next)
    {
        var validator = context.HttpContext.RequestServices
            .GetService<IValidator<T>>();
            
        if (validator is not null)
        {
            var request = context.Arguments
                .OfType<T>()
                .FirstOrDefault();
                
            if (request is not null)
            {
                var validationResult = await validator.ValidateAsync(request);
                
                if (!validationResult.IsValid)
                {
                    return Results.ValidationProblem(validationResult.ToDictionary());
                }
            }
        }
        
        return await next(context);
    }
}