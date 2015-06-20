using System;
using Windows.ApplicationModel;

namespace PCHome24OnSales.API.Utility
{
    public class VersionHelper
    {
        public static String GetVersion()
        {
            Package package = Windows.ApplicationModel.Package.Current;
            PackageVersion version = package.Id.Version;
            String appVersion = String.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            return appVersion;
        }
    }
}
