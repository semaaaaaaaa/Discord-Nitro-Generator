using System;
using System.Text;
using System.Net;
using System.Linq;
using System.Drawing;
namespace Discord_Nitro_Generator
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("How many time would you try?");
            Console.Title = "Discord Nitro Code Generator & Checker";
            string amount = Console.ReadLine();
            int amount2 = Convert.ToInt32(amount);
            var generator = new RandomNitroGenerator();
            
            for (int i = 0; i < amount2; i++)
            {

                string randomString = generator.RandomString();
                try
                {

                    HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create($"https://discordapp.com/api/v9/entitlements/gift-codes/{randomString}?with_application=false&with_subscription_plan=true");
                    HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Valid invite || discord.gift/{randomString}");
                    }
                }
                
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid invite || discord.gift/{randomString}");
                }
            }

        }
    }

    public class RandomNitroGenerator
    {
        private static Random random = new Random();
        public static string RandomGen(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string RandomString() {
            var passwordBuilder = new StringBuilder();  
  
            passwordBuilder.Append(RandomGen(16));
      return passwordBuilder.ToString(); 
        }
        
    }
}
