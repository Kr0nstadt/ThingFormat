using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    public class Question
    {
        public string Quest { get; }
        public Type TypeOfProperty { get; }

        public Question(string quest, Type type)
        {
            Quest = quest;
            TypeOfProperty = type;
        }
    }
}
