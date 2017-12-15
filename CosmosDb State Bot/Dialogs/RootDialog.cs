using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace CosmosDb_State_Bot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            string response = "";

            var activity = await result as Activity;

            // Try getting UserData
            if (context.UserData.TryGetValue<string>("last", out string lastRequest))
                response += $"Your previously sent {lastRequest}. ";

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // Save user message to UserData
            context.UserData.SetValue<string>("last", activity.Text);

            // return our reply to the user
            response += $"You sent {activity.Text} which was {length} characters";

            // Post response
            await context.PostAsync(response);

            context.Wait(MessageReceivedAsync);
        }
    }
}