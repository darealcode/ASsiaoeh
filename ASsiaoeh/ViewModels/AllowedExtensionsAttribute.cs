using System.ComponentModel.DataAnnotations;

namespace ASsiaoeh.ViewModels
{
	// Custom validation attribute for checking allowed file extensions
	public class AllowedExtensionsAttribute : ValidationAttribute
	{
		// Array to store the allowed file extensions
		private readonly string[] _extensions;

		// Constructor to initialize the AllowedExtensionsAttribute with a list of extensions
		public AllowedExtensionsAttribute(string[] extensions)
		{
			_extensions = extensions;
		}

		// Override the IsValid method of ValidationAttribute to perform custom validation
		protected override ValidationResult IsValid(
			object value, ValidationContext validationContext)
		{
			// Check if the provided value is of type IFormFile
			var file = value as IFormFile;
			if (file != null)
			{
				// Get the file extension from the file name
				var extension = Path.GetExtension(file.FileName);

				// Check if the file extension is not in the allowed extensions list
				if (!_extensions.Contains(extension.ToLower()))
				{
					// Return a ValidationResult with the error message if the extension is not allowed
					return new ValidationResult(GetErrorMessage());
				}
			}

			// If validation passes, return ValidationResult.Success
			return ValidationResult.Success;
		}

		// Method to get the custom error message
		public string GetErrorMessage()
		{
			return $"This photo extension is not allowed!";
		}
	}
}




