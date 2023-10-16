using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//Duong da o day
namespace LAB__1
{
    internal class Program
    {
       
       
        static void Main(string[] args)
        {
            Console.WriteLine("*===Chuong trinh doan so===*");
            Random random = new Random();
            int targetNumber = random.Next(100,999);
            Console.WriteLine(targetNumber);
            string targetString = targetNumber.ToString();

            int attempt = 1, MAX_GUESS = 7;
            string guess, feedback = "";
            while (feedback != "+++"&& attempt <= MAX_GUESS)
            {
                Console.WriteLine("Lan doan thu {0}: ", attempt);
                guess = Console.ReadLine();
                feedback = GetFeedback(targetString, guess);
                Console.WriteLine("Phan hoi tu may tinh: {0}",feedback);
                attempt++;
            }
            Console.WriteLine("Nguoi choi da doan {0} Lan. Tro choi ket thuc!", attempt -1);
            if (attempt > MAX_GUESS) 
                Console.WriteLine("Nguoi choi da thua cuoc. So lan don la: {0}", targetNumber);
            else
                Console.WriteLine("Nguoi choi thang cuoc!");
            Console.ReadLine();

        }
        static string GetFeedback(string target, string guess)
        {
            string feedback = "";
            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] == guess[i])
                    feedback += "+";
                else if (target.Contains(guess[i].ToString()))
                    feedback += "?";
                else
                    feedback += "_";

            }
            return feedback;
        }
    }
}
