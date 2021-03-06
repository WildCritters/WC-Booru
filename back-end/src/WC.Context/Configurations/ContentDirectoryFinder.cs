using System;
using System.IO;

namespace WC.Context.Configurations
{
    public static class ContentDirectoryFinder
    {
        public static string CalculateContentRootFolder()
        {
            return Path.Combine(AppContext.BaseDirectory, string.Format("..{0}..{0}..{0}..{0}WC.RestApi", Path.DirectorySeparatorChar));
        }
    }
}