using Telegram.Bot.Types;
using ThingFormat.Properties;
using ThingFormat.ThingFormats;

namespace TelegramBot
{
    public class User
    {
        public string FirstName{ get; }
        public string LastName { get; }
        public string UserName { get; }
        public long Id { get; }

        public Analyst analyst{ get; private set; }
        public ThingFormat.Properties.System system { get; private set; }
        public ThingFormat.Properties.Presentation presentation{ get; private set; }
        public Confidence confidence{ get; private set; }
        public ThingFormat.ThingFormats.ThingFormat ResultThingFormat { get; private set; }
        private QuestionsList questionsList { get; set; }

        public User(string firstName, string lastName, string userName, long id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserName = userName;
            this.Id = id;

            analyst = new Analyst();
            system = new ThingFormat.Properties.System();
            presentation = new ThingFormat.Properties.Presentation();
            confidence = new Confidence();
            questionsList = new QuestionsList();
        }

        public string getQuestion() => questionsList.CurrentQuestion.Quest;
        public string getQuestionType() => questionsList.CurrentQuestion.TypeOfProperty.Name;
        public bool nextStep() => questionsList.nextQuestion();

        public void setPoints(int points)
        {
            switch (getQuestionType())
            {
                case nameof(Analyst):
                    analyst.AddPoints(points); 
                    break;
                case nameof(ThingFormat.Properties.System):
                    system.AddPoints(points);
                    break;
                case nameof(ThingFormat.Properties.Presentation):
                    presentation.AddPoints(points);
                    break;
                case nameof(Confidence):
                    confidence.AddPoints(points);
                    break;
                default:
                    throw new ArgumentException("Unknow type of poroperties");
                    break;
            }
            
        }

        public string getResult()
        {
            _cmb = new CombinationOfProperties(analyst, confidence, system, presentation);
            ResultThingFormat = _cmb.ThingFormatConvector();
            return ResultThingFormat.ToString();
        }

        public void restart()
        {
            analyst = new Analyst();
            system = new ThingFormat.Properties.System();
            presentation = new ThingFormat.Properties.Presentation();
            confidence = new Confidence();
            questionsList = new QuestionsList();
        }
        private CombinationOfProperties _cmb;
    }
}
