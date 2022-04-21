namespace ITry.Commands
{
    public class CommandResult<T>
    {
        private CommandResult(string reason) => FailureReason = reason;

        private CommandResult(T payload) => Payload = payload;

        public T Payload { get; set; }
        public string FailureReason { get; set; }
        public bool IsSuccess => FailureReason != null;

        public static CommandResult<T> Fail(string reason) => new CommandResult<T>(reason);
        public static CommandResult<T> Success(T payload) => new CommandResult<T>(payload);
        public static implicit operator bool(CommandResult<T> result) => result.IsSuccess;
    }
}
