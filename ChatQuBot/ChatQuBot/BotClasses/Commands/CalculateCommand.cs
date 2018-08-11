using ChatQuBot.BotInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatQuBot.BotClasses.Commands
{
    public class CalculateCommand : IBotCommand
    {
        string _name;
        public string Name =>_name;

        public string ProcessQuery(string q)
        {
            string[] strValues = q.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (strValues.Length != 2)
            {
                throw new ArgumentException($"Wrong expression: {q}. this expresion type need to has two values!");
            }

            List<int> intValues = new List<int>();

            try
            {
                intValues.AddRange(strValues.Select(strV => int.Parse(strV)));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error convertion expresion to int values: {q}", ex);
            }

            return (intValues[0] + intValues[1]).ToString();
        }

        #region Ctors

        public CalculateCommand()
        {
            _name = "calculate";
        }

        #endregion
    }
}
