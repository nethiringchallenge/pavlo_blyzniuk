using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatQuBot.BotInterfaces
{
    public interface IBotStrategy
    {
        #region Props

        string Name { get; }

        #endregion

        #region  methods

        //void LoadInitialAnswers();
        string GetAnswer(IEnumerable<string> answs);

        #endregion
    }
}
