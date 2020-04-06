using System;

using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

using NUnit.Framework;

namespace AventStack.ExtentReports.Tests
{
    public class ExtentService
    {
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return _lazy.Value; } }

        static ExtentService()
        {
            var htmlReporter = new ExtentV3HtmlReporter(TestContext.CurrentContext.TestDirectory + "\\AutomationPractice.html");
            htmlReporter.Config.DocumentTitle = "Extent/Automation Practice";
            htmlReporter.Config.ReportName = "Extent/Automation Practice";
            htmlReporter.Config.Theme = Theme.Standard;
            Instance.AttachReporter(htmlReporter);
        }

        private ExtentService()
        {
        }
    }
}
