using SearchEngines.Config;
using SearchEngines.Config.Wrappers;
using SearchEngines.Core;
using SearchEngines.Models;
using System;

namespace SearchEngines.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text: ");
            var searchText = Console.ReadLine();
            //if (args.Length < 2)
            if (string.IsNullOrEmpty(searchText) || searchText.Split(' ').Length < 2)
            {
                Console.WriteLine("You have to enter 2 words at least");
                return;
            }

            var configuration = new SearchFightSectionWrapper(SearchFightSection.Configuration);
            var searcherLoader = new SearcherLoader(configuration);
            var searchProcess = new SearchProcess(searcherLoader, new WinnerSearchCalculator());
            var processResult = searchProcess.Run(searchText.Split(' ')).Result;

            Print(processResult);

            Console.ReadLine();
        }

        static void Print(TotalSearchResult totalSearchResult)
        {
            foreach (var result in totalSearchResult.SearchResults)
            {
                Console.Write($"{result.SearchTerm}: ");
                foreach (var searcherResult in result.SearcherResults)
                {
                    Console.Write($"{searcherResult.SearcherName}: {searcherResult.SearchTotal} ");
                }
                Console.WriteLine("");
            }

            foreach (var result in totalSearchResult.IndividualWinners)
            {
                Console.WriteLine($"{result.SearcherName} winner: {result.SearchTerm}");
            }
            
            Console.WriteLine($"Total Winner: {totalSearchResult.GlobalWinner}");
        }
    }
}