using System;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using ThingFormat.Properties;
using TelegramBot;
using Telegram.Bot.Requests;

namespace TelegramBot // Note: actual namespace depends on the project name.
{
    public class Program
    {

        static List<User> usersList = new();

        // Это клиент для работы с Telegram Bot API, который позволяет отправлять сообщения, управлять ботом, подписываться на обновления и многое другое.
        private static ITelegramBotClient _botClient;

        // Это объект с настройками работы бота. Здесь мы будем указывать, какие типы Update мы будем получать, Timeout бота и так далее.
        private static ReceiverOptions _receiverOptions;

        static async Task Main()
        {

            _botClient = new TelegramBotClient("7647936129:AAHCRZ4uXIE0w716kXPEmsYjfh3HG3aEwrc"); // Присваиваем нашей переменной значение, в параметре передаем Token, полученный от BotFather
            _receiverOptions = new ReceiverOptions // Также присваем значение настройкам бота
            {
                AllowedUpdates = new[] // Тут указываем типы получаемых Update`ов, о них подробнее расказано тут https://core.telegram.org/bots/api#update
                {
                UpdateType.Message, // Сообщения (текст, фото/видео, голосовые/видео сообщения и т.д.)
                UpdateType.CallbackQuery, //inline кнопки
            },
                // Параметр, отвечающий за обработку сообщений, пришедших за то время, когда ваш бот был оффлайн
                // True - не обрабатывать, False (стоит по умолчанию) - обрабаывать
                ThrowPendingUpdates = true,
            };

            using var cts = new CancellationTokenSource();

            // UpdateHander - обработчик приходящих Update`ов
            // ErrorHandler - обработчик ошибок, связанных с Bot API
            _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token); // Запускаем бота

            var me = await _botClient.GetMeAsync(); // Создаем переменную, в которую помещаем информацию о нашем боте.
            Console.WriteLine($"{me.FirstName} запущен!");

            await Task.Delay(-1); // Устанавливаем бесконечную задержку, чтобы наш бот работал постоянно
        }

        // Тут создаем нашу клавиатуру
        static InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(
            new List<InlineKeyboardButton[]>() // здесь создаем лист (массив), который содрежит в себе массив из класса кнопок
            {
                // Каждый новый массив - это дополнительные строки,
                // а каждая дополнительная строка (кнопка) в массиве - это добавление ряда

                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData("Да", "button1"),
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData("Скорее да, чем нет", "button2"),
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData("Я не знаю", "button3"),
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData("Скорее нет, чем да", "button4"),
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData("Нет", "button5"),
                }
            });

        static InlineKeyboardMarkup resultInlineKeyboard = new InlineKeyboardMarkup(
            new List<InlineKeyboardButton[]>() // здесь создаем лист (массив), который содрежит в себе массив из класса кнопок
            {
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData("Начать заново", "button6"),
                }
            });
    


        private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Обязательно ставим блок try-catch, чтобы наш бот не "падал" в случае каких-либо ошибок
            try
            {
                // Сразу же ставим конструкцию switch, чтобы обрабатывать приходящие Update
                switch (update.Type)
                {
                    case UpdateType.Message:
                        {
                            // эта переменная будет содержать в себе все связанное с сообщениями
                            var message = update.Message;
                            // From - это от кого пришло сообщение
                            var tgUser = message.From;

                            // Выводим на экран то, что пишут нашему боту, а также небольшую информацию об отправителе
                            Console.WriteLine($"{tgUser.FirstName} ({tgUser.Id}) написал сообщение: {message.Text}");
                            // Chat - содержит всю информацию о чате
                            var chat = message.Chat;

                            // Добавляем проверку на тип Message
                            switch (message.Type)
                            {
                                // Тут понятно, текстовый тип
                                case MessageType.Text:
                                    {
                                        if (message.Text == "/start")
                                        {
                                            var user = usersList.FirstOrDefault(x => x.Id == tgUser.Id);
                                            if (user is null)
                                            {
                                                usersList.Add(new User(tgUser.FirstName, tgUser.LastName, tgUser.Username, tgUser.Id));
                                                user = usersList.FirstOrDefault(x => x.Id == tgUser.Id);
                                            }
                                            await botClient.SendTextMessageAsync(
                                                chat.Id,
                                                user.getQuestion(),
                                                replyMarkup: inlineKeyboard
                                                ); // Все клавиатуры передаются в параметр replyMarkup
                                            return;
                                        }
                                        return;
                                    }

                                // Добавил default , чтобы показать разницу типов Message
                                default:
                                    {
                                        await botClient.SendTextMessageAsync(
                                            chat.Id,
                                            "Используй только текст!");
                                        return;
                                    }
                            }
                        }

                    case UpdateType.CallbackQuery:
                        {
                            // Переменная, которая будет содержать в себе всю информацию о кнопке, которую нажали
                            var callbackQuery = update.CallbackQuery;

                            // Аналогично и с Message мы можем получить информацию о чате, о пользователе и т.д.
                            var tgUser = callbackQuery.From;
                            // Выводим на экран нажатие кнопки
                            Console.WriteLine($"{tgUser.FirstName} ({tgUser.Id}) нажал на кнопку: {callbackQuery.Data}");

                            // Вот тут нужно уже быть немножко внимательным и не путаться!
                            // Мы пишем не callbackQuery.Chat , а callbackQuery.Message.Chat , так как
                            // кнопка привязана к сообщению, то мы берем информацию от сообщения.
                            var chat = callbackQuery.Message.Chat;
                            // Добавляем блок switch для проверки кнопок

                            var user = usersList.FirstOrDefault(x => x.Id == tgUser.Id);
                            if (user is null)
                            {
                                usersList.Add(new User(tgUser.FirstName, tgUser.LastName, tgUser.Username, tgUser.Id));
                                user = usersList.FirstOrDefault(x => x.Id == tgUser.Id);
                                await botClient.SendTextMessageAsync(
                                                chat.Id,
                                                user.getQuestion(),
                                                replyMarkup: inlineKeyboard
                                                ); // Все клавиатуры передаются в параметр replyMarkup
                                return;
                            }

                            switch (callbackQuery.Data)
                            {
                                // Data - это придуманный нами id кнопки, мы его указывали в параметре
                                // callbackData при создании кнопок. У меня это button1, button2 и button3

                                case "button1":
                                    {
                                        user.setPoints(2);
                                        break;
                                    }

                                case "button2":
                                    {
                                        user.setPoints(1);
                                        break;
                                    }

                                case "button3":
                                    {
                                        user.setPoints(0);
                                        break;
                                    }
                                case "button4":
                                    {
                                        user.setPoints(-1);
                                        break;
                                    }
                                case "button5":
                                    {
                                        user.setPoints(-2);
                                        break;
                                    }
                                case "button6":
                                    {
                                        try
                                        {
                                            if (user is not null)
                                            {
                                                user.restart();
                                            }
                                            else
                                            {
                                                throw new Exception("User is null");
                                            }
                                            await botClient.SendTextMessageAsync(
                                                chat.Id,
                                                user.getQuestion(),
                                                replyMarkup: inlineKeyboard
                                                ); // Все клавиатуры передаются в параметр replyMarkup

                                        }
                                        catch (Exception)
                                        {
                                            if (user is null)
                                            {
                                                usersList.Add(new User(tgUser.FirstName, tgUser.LastName, tgUser.Username, tgUser.Id));
                                                user = usersList.FirstOrDefault(x => x.Id == tgUser.Id);
                                            }
                                            await botClient.SendTextMessageAsync(
                                                chat.Id,
                                                user.getQuestion(),
                                                replyMarkup: inlineKeyboard
                                                ); // Все клавиатуры передаются в параметр replyMarkup
                                        }
                                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                                        return;
                                    }
                            }
                            if (user.nextStep())
                            {
                                await botClient.EditMessageTextAsync(chat, callbackQuery.Message.MessageId, user.getQuestion(), replyMarkup: inlineKeyboard);
                                //await botClient.SendTextMessageAsync(
                                //                chat.Id,
                                //                user.getQuestion(),
                                //                replyMarkup: inlineKeyboard
                                //                ); // Все клавиатуры передаются в параметр replyMarkup
                                await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
                            }
                            else
                            {
                                //await botClient.EditMessageTextAsync(chat, callbackQuery.Message.MessageId, user.getResult());
                                //await botClient.SendTextMessageAsync(
                                //             chat.Id,
                                //             user.getResult()
                                //             );

                                await botClient.SendTextMessageAsync(
                                    chat.Id,
                                    user.getResult(),
                                    replyMarkup: resultInlineKeyboard);
                                await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);

                                return;
                            }
                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        

        private static Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
        {
            // Тут создадим переменную, в которую поместим код ошибки и её сообщение 
            var ErrorMessage = error switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => error.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}