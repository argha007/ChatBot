using IntermediatorBotSample.CommandHandling;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IntermediatorBotSample.Bot
{
    public class IntermediatorBot : IBot
    {
        private const string SampleUrl = "https://github.com/tompaana/intermediator-bot-sample";

        public async Task OnTurnAsync(ITurnContext context, CancellationToken ct)
        {
            HeroCard heroCard = null;
            if (context.Activity.From.Id.ToLower().Equals("agent--agb"))
            {
                Command showOptionsCommand = new Command(Commands.ShowOptions);

                heroCard = new HeroCard()
                {
                    Title = "Hello " + context.Activity.From.Id + " Good Evening!!!!",
                    Subtitle = "!!!! Welcome to Agent Chat Window! !!",
                    Text = $" \"{new Command(Commands.ShowOptions).ToString()}\"",
                    Buttons = new List<CardAction>()
                {
                    new CardAction()
                    {
                        Title = "Show options",
                        Value = showOptionsCommand.ToString(),
                        Type = ActionTypes.ImBack
                    }
                }
                };

            }

            else
            {
                heroCard = new HeroCard()
                {
                    Title = "Hello " + context.Activity.From.Id + " Welcome and Good Evening!!!!",
                    Subtitle = "How may I help You today?",
                    Text = "I am an automated bot to help you with your problems"
                };
            }
            Activity replyActivity = context.Activity.CreateReply();
            replyActivity.Attachments = new List<Attachment>() { heroCard.ToAttachment() };
            await context.SendActivityAsync(replyActivity);
        }
    }
}
