namespace FjtFramework.Cores
{
    public class AppConfig
    {
        public EmailConfig Email { get; set; } = new EmailConfig();
    }

    public class EmailConfig
    {
        public string DefaultFromAddress { get; set; } = "yourmail@gmail.com";

        public string InProcSmptServer { get; set; } = "smtp.gmail.com";

        public int InProcSmtpPort { get; set; } = 587;

        public string InProcUsername { get; set; } = "yourmail@gmail.com";

        public string InProcPassword { get; set; } = "your_password";

        public string AzureSendGridApiKey { get; set; }

        public string HomePageLink { get; set; }

        public string AdminEmail { get; set; }

        public int AttachmentExpiredTime { get; set; } = 48;

        public bool BccQuotationToAdmin { get; set; }

        public string Support { get; set; }

        public string CustomerServiceDepartment { get; set; }

        public string CustomerServiceDepartmentName { get; set; }
    }
}
