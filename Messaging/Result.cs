namespace BankAccounts.Messaging
{
    public class Result
    {
        private Result(bool success, string errorMessage = null)
        {
            IsSuccess = success;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccess { get; }
        public string ErrorMessage { get; }

        public static Result Success => new Result(true);
        public static Result Error(string errorMessage) => new Result(false, errorMessage);
    }
}