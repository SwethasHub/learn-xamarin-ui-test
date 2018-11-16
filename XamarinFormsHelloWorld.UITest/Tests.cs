using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinFormsHelloWorld.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        private void SaveScreenshot([CallerMemberName]string title = "")
        {
            FileInfo screenshot = app.Screenshot(title);
            if (TestEnvironment.IsTestCloud == false)
            {
                File.Move(screenshot.FullName, Path.Combine(screenshot.DirectoryName, $"{title}{screenshot.Extension}"));
            }
        }

        [Test]
        public void CCEntry_LessThan5Digit_Wrong()
        {
            app.EnterText("CreditCardEntry", "1234");
            app.Tap("ValidateCC");
            app.WaitForElement("message");
            Assert.IsTrue(app.Query(x => x.Id("message").Text("Wrong")).Any());
            SaveScreenshot();
        }

        [Test]
        public void CCEntry_MoreOrEqual5Digit_Correct()
        {
            app.EnterText("CreditCardEntry", "12345");
            app.Tap("ValidateCC");
            app.WaitForElement("message");
            Assert.IsTrue(app.Query(x => x.Id("message").Text("Correct")).Any());
            SaveScreenshot();
        }
    }
}
