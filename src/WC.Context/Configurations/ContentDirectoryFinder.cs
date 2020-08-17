using System;
using System.IO;

namespace WC.Context
{
    public static class ContentDirectoryFinder
    {
        public static string CalculateContentRootFolder()
        {
            return Path.Combine(AppContext.BaseDirectory, string.Format("..{0}..{0}..{0}..{0}WildCritters", Path.DirectorySeparatorChar));
        }
    }
}