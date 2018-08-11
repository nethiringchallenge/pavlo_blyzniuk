using ChatQuBot.BotInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatQuBot.BotClasses
{
    public class FileAnswerLoader : IAnswerLoader
    {
        List<string> _answers;

        #region IAnswerLoader

        public IEnumerable<string> Answers => _answers;


        #endregion

        #region Public methods

        public void LoadFromFile(string filePath)
        {
            _answers.Clear();

            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentNullException("File path cant be null or empty"); ;
                }

                //dirrt and fast code - need to be tested with big data
                string answFromFile = File.ReadAllText(filePath);

                if (!(answFromFile?.Length > 0))
                {
                    throw new Exception($"There are not answers in the file {filePath}");
                }


                foreach (var answ in answFromFile.Split(new string[] { ">" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    _answers.Add(answ);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't load answers from file: {filePath}\nEx: {ex.Message}");
            }
        }

        #endregion

        #region Ctors

        public FileAnswerLoader()
        {
            _answers = new List<string>();
        }

        #endregion

    }
}
