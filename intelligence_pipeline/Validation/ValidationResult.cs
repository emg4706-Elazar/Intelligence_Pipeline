namespace IntelligencePipeline.Validation
{
    class ValidationResult
    {
        public bool IsValid { get; }
        public string ErrorMessage { get; }

        private ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }
        public static ValidationResult Success()
        {
            return new ValidationResult(true, "");
        }
        public static ValidationResult Failure(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                errorMessage = "Validation failed";
            }

            return new ValidationResult(false, errorMessage);
        }
    }
}