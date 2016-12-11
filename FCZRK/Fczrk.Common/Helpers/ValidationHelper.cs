using Fczrk.Common.Exceptions;
using Fczrk.Common.Extensions;

namespace Fczrk.Common.Helpers
{
    public static class ValidationHelper
    {
        public static void ValidateNotNull<T>(T entity) where T : class
        {
            string entityName = typeof(T).Name.ToSentenceCase();

            if (entity == null)
            {
                throw new ValidationException($"{entityName} does not exist!");
            }
        }

        public static void ValidateEntityExist<T>(T entity) where T : class
        {
            string entityName = typeof(T).Name.ToSentenceCase();

            if (entity != null)
            {
                throw new ValidationException($"{entityName} already exists!");
            }
        }
    }
}
