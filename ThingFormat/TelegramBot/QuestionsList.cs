using ThingFormat.Properties;

namespace TelegramBot
{
    public class QuestionsList
    {
        private static List<Question> Questions = new List<Question>()
        {
            new Question("Вы уверены, что все начатые свои дела надо заканчивать", typeof(ThingFormat.Properties.System)),
            new Question("Не стоит и начинать дело, если его не заканчивать", typeof(ThingFormat.Properties.System)),
            new Question("Вы всегда внимательно читаете инструкции к пользованью новых приборов", typeof(ThingFormat.Properties.System)),
            new Question("Мысль выражаете четко и понятно", typeof(ThingFormat.Properties.System)),
            new Question("Во всем должны соблюдаться четкие и понятные правила", typeof(ThingFormat.Properties.System)),
            new Question("Вы реалист", typeof(ThingFormat.Properties.System)),
            new Question("Мне нравится составлять планы и решать, что и кому делать", typeof(ThingFormat.Properties.System)),
            new Question("Важно иметь управляемые, четко контролируемые бизнес проекты", typeof(ThingFormat.Properties.System)),
            new Question("Решающие значение имеет точное распределение, и выполнение договоров между людьми", typeof(ThingFormat.Properties.System)),
            new Question("Если правила для Вас четко определены, то Вы можете легко управлять несколькими проектами", typeof(ThingFormat.Properties.System)),
            new Question("Вы не громкоголосы", typeof(ThingFormat.Properties.Analyst)),
            new Question("Вам часто кажется, что все пойдет не так, как «надо»", typeof(ThingFormat.Properties.Analyst)),
            new Question("Что бы перейти на новое дело Вам надо тщательно его изучить, «свыкнуться» с ним, желательно, просмотреть все возможные варианты", typeof(ThingFormat.Properties.Analyst)),
            new Question("Вам присуща чувство гармонии", typeof(ThingFormat.Properties.Analyst)),
            new Question("Вы не любите напряженных отношений и стараетесь сразу сгладить острые углы", typeof(ThingFormat.Properties.Analyst)),
            new Question("Движения ваши плавные не резкие", typeof(ThingFormat.Properties.Analyst)),
            new Question("Главное во всем соблюдать меру и не переступать за грань", typeof(ThingFormat.Properties.Analyst)),
            new Question("Я достаточно сентиментален", typeof(ThingFormat.Properties.Analyst)),
            new Question("Я чувствую, когда люди не искренни", typeof(ThingFormat.Properties.Analyst)),
            new Question("Мне больше нравятся гуманитарные науки, чем точные", typeof(ThingFormat.Properties.Analyst)),
            new Question("Вы любите быть в центре внимания", typeof(ThingFormat.Properties.Presentation)),
            new Question("Вы любите одеваться эффектно", typeof(ThingFormat.Properties.Presentation)),
            new Question("Вы не любите задачи, которые требуют долго удерживать большое напряжение", typeof(ThingFormat.Properties.Presentation)),
            new Question("Вы обязательно должны добиться в обществе определенное положение", typeof(ThingFormat.Properties.Presentation)),
            new Question("Из двух путей: долгого, кропотливого и быстрого, и эффектного вы, конечно, выберите второе, даже если второй путь будет не совсем «честный» и «правильный»", typeof(ThingFormat.Properties.Presentation)),
            new Question("Вы любите экспериментировать с разными социальными ролями, надевая то одну, то другую маску", typeof(ThingFormat.Properties.Presentation)),
            new Question("Жизнь вокруг вас должна бурлить праздничным фейерверком", typeof(ThingFormat.Properties.Presentation)),
            new Question("Вы никогда не были особо застенчивым", typeof(ThingFormat.Properties.Presentation)),
            new Question("Вы инициативны и полны энергии", typeof(ThingFormat.Properties.Presentation)),
            new Question("Мы пришли в этот мир, чтобы удивить его собой", typeof(ThingFormat.Properties.Presentation)),
            new Question("Я уверенный в себе человек", typeof(ThingFormat.Properties.Confidence)),
            new Question("Я всегда чувствую себя свободно", typeof(ThingFormat.Properties.Confidence)),
            new Question("Я не вижу ясных и четких перспектив в своей жизни", typeof(ThingFormat.Properties.Confidence)),
            new Question("На данный момент я чувствую себя сильным и уверенным", typeof(ThingFormat.Properties.Confidence)),
            new Question("Я часто ощущаю себя растерянным", typeof(ThingFormat.Properties.Confidence)),
        };

        private int _currentQuestId = 0; 

        public  Question CurrentQuestion { get; private set; } = Questions.FirstOrDefault();

        public bool nextQuestion()
        {
            _currentQuestId++;
            if (_currentQuestId < Questions.Count)
            {
                CurrentQuestion = Questions[_currentQuestId];
                return true;
            }
            return false;
        }
    }
}
