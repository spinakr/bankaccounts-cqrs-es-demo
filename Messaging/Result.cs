using System;

namespace BankAccounts.Messaging
{
    public class Result
    {
        private Result(bool success, Guid? aggregateId, string errorMessage = null)
        {
            IsSuccess = success;
            ErrorMessage = errorMessage;
            AggregateId = aggregateId;
        }

        public bool IsSuccess { get; }
        public string ErrorMessage { get; }
        public Guid? AggregateId { get; set; }

        public static Result Success(Guid aggregateId) => new Result(true, aggregateId);
        public static Result Error(Guid aggregateId, string errorMessage) => new Result(false, aggregateId, errorMessage);
    }
}