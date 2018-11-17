using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinFormsHelloWorld.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .InstalledApp("com.companyname.XamarinFormsHelloWorld")
                    //.ApkFile(@"C:\Repos\XamarinFormsHelloWorld\XamarinFormsHelloWorld\XamarinFormsHelloWorld.Android\bin\Debug\com.companyname.XamarinFormsHelloWorld.apk")
                    .EnableLocalScreenshots()
                    //.DeviceSerial("emulator-5554") // If we want it to run in specific device
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}