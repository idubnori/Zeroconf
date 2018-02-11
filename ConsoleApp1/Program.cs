using System;
using System.Linq;
using System.Threading.Tasks;
using Zeroconf;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var domains = await ZeroconfResolver.BrowseDomainsAsync();
                foreach (var domain in domains)
                {
                    Console.WriteLine($"key -> {domain.Key}");
                }

                var responses = await ZeroconfResolver.ResolveAsync(domains.Select(g => g.Key));
                foreach (var resp in responses)
                    Console.WriteLine(resp);
            }).Wait();
        }
    }
}
