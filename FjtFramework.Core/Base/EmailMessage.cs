using System.Collections.Generic;

namespace FjtFramework.Cores
{
    public class EmailMessage
    {
        public string FromAddress { get; set; }

        public List<string> ToAddress { get; set; }

        public List<string> CcAddress { get; set; }

        public List<string> BccAddress { get; set; }

        public string Subject { get; set; }

        public string MessageBody { get; set; }

        public List<string> AttachmentFileNames { get; set; }
    }
}
