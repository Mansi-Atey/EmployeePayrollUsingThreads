using System;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.Linq;

namespace EmployeePayrollUsingThreading
{
   public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Employee Payroll Using threads");
            string[] words = CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");

            #region ParallelTasks
            Parallel.Invoke(() =>
            {
                Console.WriteLine("Begin first task.....");
                GetLongestWord(words);
            },
            () =>
            {
                Console.WriteLine("Being second Task....");
                GetMostCommonWords(words);
            },
            () =>
            {
                Console.WriteLine("Begin third task....");
                GetMostCommonWords(words);
            });
            #endregion
        }
        private static void GetMostCommonWords(string[] words)
        {
            var frequencyOrder = from word in words 
                                 where word.Length > 6
                                 group word by word into q
                                 orderby q.Count() descending
                                 select q.Key;
            var commonWord = frequencyOrder.Take(10);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Task 2 --- The most common words are:");
            foreach( var v in commonWord)
            {
                sb.AppendLine(" " + v);
            }
            Console.WriteLine(sb.ToString());
        }
         static string[] CreateWordArray(string uri)
        {
            Console.WriteLine($"Retrieving from {uri}");
            string blog = new WebClient().DownloadString(uri);

            return blog.Split(
                new char[] { ' ', '\u000A', '.', ',', '-', '_', '/' },
                StringSplitOptions.RemoveEmptyEntries);
        }
        private static string GetLongestWord(string[] words)
        {
            string longestWord = (from w in words
                                  orderby w.Length descending
                                  select w).First();
            Console.WriteLine($"Task 1 -- The longest word is {longestWord}.");
            return longestWord;
        }
    }
}

