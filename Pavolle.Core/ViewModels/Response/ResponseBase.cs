namespace Pavolle.Core.ViewModels.Response
{
    public class ResponseBase
    {
        public bool Success { get; set; } = true;

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                if (!string.IsNullOrEmpty(_errorMessage))
                {
                    Success = false;
                }
            }
        }

        public string? SuccessMessage { get; set; }
        public string? InfoMessage { get; set; }
        public string? WarningMessage { get; set; }
        public int StatusCode { get; set; } = 200;
    }
}
