using ChatQuBot.BotClasses.Commands;
using ChatQuBot.BotInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatQuBot.BotClasses
{
    public class Bot
    {

        string _rightAnswer;
        string _wrongAnswer;
        string _strategyChangingMsg;

        IEnumerable<string> _answers;
        IBotStrategy _strategy;

        List<IBotCommand> _commandsAndActions;

        #region Public methods

        public void SetAnswers(IEnumerable<string> answers)
        {
            if (!(answers?.Count() > 0))
            {
                throw new ArgumentException("Answers list is null or empty");
            }

            _answers = answers;
        }

        public string SetStrategy(IBotStrategy strategy)
        {
            if (strategy == null)
            {
                throw new ArgumentNullException("Stratege can't be null");
            }

            _strategy = strategy;

            return $"{_strategyChangingMsg} {_strategy.Name}"; 
        }

        public string ProcessQuestion(string questionText)
        {
            if (string.IsNullOrEmpty(questionText))
            {
                return _wrongAnswer;
            }

            try
            {
                string[] splitedQ = questionText.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                //it can be a command
                if (splitedQ.Length == 2)
                {
                    string possibleCmdName = splitedQ[0];

                    IBotCommand cmd = _commandsAndActions.FirstOrDefault(c => c.Name.Equals(possibleCmdName, StringComparison.InvariantCultureIgnoreCase));

                    //it isn not command
                    if (cmd == null)
                    {
                        return _strategy.GetAnswer(_answers);
                    }
                    //process command
                    else
                    {
                        return cmd.ProcessQuery(splitedQ[1]);
                    }

                }
                //regular answer
                else
                {
                    return _strategy.GetAnswer(_answers);
                }

            }
            catch (Exception ex)
            {
                return $"{_wrongAnswer}\n\t!!! {ex.Message}";
            }
        }

        #endregion

        #region Ctors

        public Bot()
        {
             _rightAnswer= "Я тебя полюбил — я тебя научу:";
            _wrongAnswer = "У тебя в голове мозги или кю?!";
            _strategyChangingMsg = "Как советовать, так все чатлане. Использую:";

            _commandsAndActions = new List<IBotCommand>();

            #region Command initialisation
            
            _commandsAndActions.Add(new CalculateCommand());

            #endregion
        }

        #endregion

       
    }
}
