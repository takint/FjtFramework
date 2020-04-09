using FluentValidation;

namespace FjtFramework.Cores
{
    public class BaseValidation<T> : AbstractValidator<T> where T : class
    {
    }
}
