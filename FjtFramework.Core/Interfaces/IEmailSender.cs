using FjtFramework.Cores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FjtFramework.Interfaces
{
    public interface IEmailSender
    {
        string CreateEmailBody(string templatePath, Dictionary<string, string> parameters);

        Task SendAsync(EmailMessage email);
    }
}
