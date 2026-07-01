namespace IntelligencePipeline.Validation
{
    class ValidationResult
    {
        private bool _isValid;
        private string _errorMessage;

        public bool IsValid { get; }
        public string ErrorMessage { get; }

        public ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }
        public static ValidationResult Success()
        {

        }
        public static ValidationResult Failure(string errorMessage)
        {

        }
    }
}