namespace Habitraca.Domain.EmailFolder
{
    public class EmailEntity
    {
        public string ReceiverEmail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
