using AutomationPractice.TestStep;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Tests;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace AutomationPractice.Runner
{
    public abstract class BaseFixture
    {
        [OneTimeSetUp]
        public void Setup()
        {

        }

      
        [SetUp]
        public void BeforeTest()
        {
            ExtentTestManager.CreateMethod(GetType().Name, TestContext.CurrentContext.Test.Name);
            //ExtentTestManager.GetTest();
        }

        [TearDown]
        public void AfterTest()
        {
            string screenShotPath = BaseTest.Capture(TestContext.CurrentContext.Test.Name);
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            ExtentTestManager.GetTest().Log(logstatus, "Test ended with " + logstatus + stacktrace);
            ExtentTestManager.GetTest().Log(logstatus, "Snapshot below: " + ExtentTestManager.GetTest().AddScreenCaptureFromPath(screenShotPath));
        }
    }
}

