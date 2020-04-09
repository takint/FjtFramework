using FjtFramework.Cores;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FjtFramework.CoreServices
{
    public abstract class BaseEmailSender
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        protected readonly AppConfig AppConfig;

        protected BaseEmailSender(IOptions<AppConfig> appConfig, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            AppConfig = appConfig.Value;
        }

        /// <summary>
        /// Parses email template to email body
        /// </summary>
        /// <param name="templatePath">Relative path to email template file</param>
        /// <param name="parameters">The parameters to be replaced in the template</param>
        public string CreateEmailBody(string templatePath, Dictionary<string, string> parameters)
        {
            var body = File.ReadAllText(Path.Combine(_hostingEnvironment.WebRootPath, "assets\\email-templates", templatePath));

            foreach (var parameter in parameters)
            {
                body = body.Replace($"{{{{{parameter.Key}}}}}", parameter.Value);
            }

            return body;
        }

        protected void ValidateEmailMessage(EmailMessage email)
        {
            if (email.ToAddress == null || !email.ToAddress.Any())
            {
                throw new ArgumentNullException("ToAddress");
            }

            if (string.IsNullOrEmpty(email.Subject))
            {
                throw new ArgumentNullException("Subject");
            }

            if (string.IsNullOrWhiteSpace(email.MessageBody))
            {
                throw new ArgumentNullException("Body");
            }
        }
    }
}
