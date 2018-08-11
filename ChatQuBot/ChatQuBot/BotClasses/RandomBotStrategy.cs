using ChatQuBot.BotInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatQuBot.BotClasses
{
    public class RandomBotStrategy : IBotStrategy
    {
       
        Random _r;

        #region IBotStrategy


        public string Name { get; }

        public string GetAnswer(IEnumerable<string> answs)
        {
            int nextAnswIndex = _r.Next(0, answs.Count() - 1);

            return answs.ElementAt(nextAnswIndex);
        }

        
        //}

        #endregion

        #region Ctrors

        public RandomBotStrategy()
        {
            _r = new Random(DateTime.Now.Millisecond);

            Name = "random";
        }

        #endregion

    }
}
