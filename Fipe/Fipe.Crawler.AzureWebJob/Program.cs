using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Jobs;

namespace Fipe.Crawler.AzureWebJob
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new JobHost();
            host.RunAndBlock();
        }
    }
}
