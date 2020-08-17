using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WC.Context
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = AppConfiguration.Get(ContentDirectoryFinder.CalculateContentRootFolder());

            var connectionString = configuration.GetConnectionString("Default");
        }
    }
}
