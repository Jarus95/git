using Telegram.Bot;
using Telegram.Bot.Types;

string botToken = "5370553846:AAGbVUntBAbp-xuMhmF3QIzcbRn2oQRV9Gg";

var bot = new TelegramBotClient(botToken);
bot.SendTextMessageAsync(679614472, "Salom");

bot.StartReceiving(errorHandler: ErrorHandler, updateHandler: MessageHandler);

async Task MessageHandler(ITelegramBotClient client, Update update, CancellationToken token)
{
    Console.WriteLine(update.Message.Text);
    bot.SendTextMessageAsync(update.Message.Chat.Id, $"Salom {update.Message.From.FirstName}");
}

async Task ErrorHandler(ITelegramBotClient client, Exception exc, CancellationToken token)
{

}

Console.ReadKey();