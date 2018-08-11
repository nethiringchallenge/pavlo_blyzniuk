using ChatQuBot.BotClasses;
using ChatQuBot.BotInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatQuBot
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!(args?.Length >0))
            {
                Console.WriteLine("Set initial data like: ChatQuBot.exe -r rand -f ../answers.txt ");
            }

            string argsStr = string.Join(" ", args);

            string[] cmds = argsStr.Split(new string[] { "-r" }) 

           // var indexOfStrategy = args.FindIndex(it => it.Equel("-r"));

            string[] initialCommandsStr = args.Skip(1).Take(args.Length)

            IAnswerLoader currAnswersLoader = new FileAnswerLoader();
           // IBotStrategy currStrategy = 
        }
    }
}
