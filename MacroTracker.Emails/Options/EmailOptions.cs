namespace MacroTracker.Emails.Options
{
    public class EmailOptions
    {
        public string FromEmail { get; set; }
        public string FromPassword { get; set; }
        public string FromName { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
    }
}