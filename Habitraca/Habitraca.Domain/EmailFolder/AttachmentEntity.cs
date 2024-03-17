namespace Habitraca.Domain.EmailFolder
{
    public class AttachmentEntity
    {
        public byte[] Data { get; set; } = new byte[0];
        public string FileName { get; set; }= string.Empty;
    }
}
