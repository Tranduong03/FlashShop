using System.ComponentModel.DataAnnotations;

namespace FlashShop.Repository.Validtation
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                //string[] extensions = { "jpg", "png" };
                string[] extensions = { ".jpg", ".png" };

                bool result = extensions.Any(x=> extension.EndsWith(x));

                if (!result)
                {
                    //return new ValidationResult("Cho phép đuôi jpg hoặc png");
                    return new ValidationResult("Chỉ cho phép tệp có đuôi .jpg hoặc .png");
                }

            }
            return ValidationResult.Success;
        }
    }
}
