using System.ComponentModel.DataAnnotations;

namespace api.Tests.Helpers.TestHelpers
{
    internal class TestHelpers
    {
        public void ValidateDto<T>(T dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "DTO cannot be null");

            var validation = new ValidationContext(dto!);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validation, results, validateAllProperties: true);

            Assert.True(isValid, $"Validation failed: {string.Join(", ", results.Select(r => r.ErrorMessage))}");
        }
    }
}
    