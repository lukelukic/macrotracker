namespace MacroTracker.Emails.Interfaces
{
    public interface IEmailSender
    {
        string Body { get; set; }
        string Subject { get; set; }
        string ToEmail { get; set; }

        void Send();
    }
}