using IntermediatorBotSample.CommandHandling;
using IntermediatorBotSample.ConversationHistory;
using IntermediatorBotSample.MessageRouting;
using IntermediatorBotSample.Storage;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Underscore.Bot.MessageRouting;
using Underscore.Bot.MessageRouting.DataStore;
using Underscore.Bot.MessageRouting.DataStore.Azure;
using Underscore.Bot.MessageRouting.DataStore.Local;
using Underscore.Bot.MessageRouting.Results;

namespace IntermediatorBotSample.Middleware
{
    public class HandoffMiddleware : IMiddleware
    {
        private const string KeyAzureTableStorageConnectionString = "AzureTableStorageConnectionString";
        private const string KeyRejectConnectionRequestIfNoAggregationChannel = "RejectConnectionRequestIfNoAggregationChannel";
        private const string KeyPermittedAggregationChannels = "PermittedAggregationChannels";
        private const string KeyNoDirectConversationsWithChannels = "NoDirectConversationsWithChannels";

        public IConfiguration Configuration
        {
            get;
            protected set;
        }

        public MessageRouter MessageRouter
        {
            get;
            protected set;
        }

        public MessageRouterResultHandler MessageRouterResultHandler
        {
            get;
            protected set;
        }

        public CommandHandler CommandHandler
        {
            get;
            protected set;
        }

        public MessageLogs MessageLogs
        {
            get;
            protected set;
        }

        public HandoffMiddleware(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration[KeyAzureTableStorageConnectionString];
            IRoutingDataStore routingDataStore = null;

            if (string.IsNullOrEmpty(connectionString))
            {
                System.Diagnostics.Debug.WriteLine($"WARNING!!! No connection string found - using {nameof(InMemoryRoutingDataStore)}");
                routingDataStore = new InMemoryRoutingDataStore();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Found a connection string - using {nameof(AzureTableRoutingDataStore)}");
                routingDataStore = new AzureTableRoutingDataStore(connectionString);
            }

            MessageRouter = new MessageRouter(
                routingDataStore,
                new MicrosoftAppCredentials(Configuration["MicrosoftAppId"], Configuration["MicrosoftAppPassword"]));

            //MessageRouter.Logger = new Logging.AggregationChannelLogger(MessageRouter);

            MessageRouterResultHandler = new MessageRouterResultHandler(MessageRouter);

            ConnectionRequestHandler connectionRequestHandler =
                new ConnectionRequestHandler(GetChannelList(KeyNoDirectConversationsWithChannels));

            CommandHandler = new CommandHandler(
                MessageRouter,
                MessageRouterResultHandler,
                connectionRequestHandler,
                GetChannelList(KeyPermittedAggregationChannels));

            MessageLogs = new MessageLogs(connectionString);
        }

        public async Task OnTurnAsync(ITurnContext context, NextDelegate next, CancellationToken ct)
        {
            Activity activity = context.Activity;
            #region Argha
            if (context.Activity.From.Id.Equals("Jeet") || context.Activity.Recipient.Id.Equals("Jeet"))
            {
                context.Activity.Recipient.Name = "Jeet";
                context.Activity.From.Name = "Jeet";

            }
            if (context.Activity.Recipient.Id.Equals("Agent--AGB") || context.Activity.From.Id.Equals("Agent--AGB"))
            {
                context.Activity.Recipient.Name = "Agent--AGB";
                context.Activity.From.Name = "Agent--AGB";
                //context.Activity.Text = "@Agent--AGB AcceptRequest Jeet "+ "72330760-34a0-11ea-a1b2-8324d8ba10ef|livechat";
            }
            #endregion

            if (activity.Type is ActivityTypes.Message)
            {
                bool.TryParse(
                    Configuration[KeyRejectConnectionRequestIfNoAggregationChannel],
                    out bool rejectConnectionRequestIfNoAggregationChannel);

                // Store the conversation references (identities of the sender and the recipient [bot])
                // in the activity
                MessageRouter.StoreConversationReferences(activity);

                AbstractMessageRouterResult messageRouterResult = null;

                #region Argha
                if (context.Activity.From.Id.Equals("Jeet") || context.Activity.Recipient.Id.Equals("Jeet"))
                {
                    if (new DatabaseHelper().GetStatus("JeetFirstTime").Equals(true))
                    {
                        messageRouterResult = MessageRouter.CreateConnectionRequest(
                                MessageRouter.CreateSenderConversationReference(activity),
                                rejectConnectionRequestIfNoAggregationChannel);
                        
                        new DatabaseHelper().UpdateUserConversationId(context.Activity.Conversation.Id);
                    }
                    

                }

                if (context.Activity.Recipient.Id.Equals("Agent--AGB") || context.Activity.From.Id.Equals("Agent--AGB"))
                {
                    if(context.Activity.Text.Equals("@Agent--AGB Watch"))
                    {
                        new DatabaseHelper().UpdateStatus("AgentWatchClicked", "True");
                    }
                    else if (context.Activity.Text.Equals("@Agent--AGB AcceptRequest Jeet " + new DatabaseHelper().GetUserConversationId()))
                    {
                        //context.Activity.Text = "@Agent--AGB AcceptRequest Jeet "+ new DatabaseHelper().GetUserConversationId();
                        new DatabaseHelper().UpdateStatus("AgentAccepted", "True");
                    }
                }
                //await CommandHandler.HandleCommandAsync(context);
                #endregion

                // Check the activity for commands
                if (await CommandHandler.HandleCommandAsync(context) == false)
                {
                    // No command detected/handled

                    // Let the message router route the activity, if the sender is connected with
                    // another user/bot
                    if(new DatabaseHelper().GetStatus("UserCried").Equals(false) && (context.Activity.From.Id.Equals("Jeet") || context.Activity.Recipient.Id.Equals("Jeet")))
                    {
                        Activity botActivity = new Activity();
                        if (new DatabaseHelper().GetStatus("JeetFirstTime").Equals(false) && new DatabaseHelper().GetStatus("StopBot").Equals(false))
                        {
                            messageRouterResult = await MessageRouter.RouteMessageIfSenderIsConnectedAsync(activity);
                            //Bot Response
                            
                            botActivity = activity;
                            botActivity.Text = "Bot: Hello am Bot";
                           
                            messageRouterResult = await MessageRouter.RouteMessageIfSenderIsConnectedAsync(botActivity,false);
                            await context.SendActivityAsync("Bot: Hello am Bot");
                        }
                        else if (new DatabaseHelper().GetStatus("JeetFirstTime").Equals(false) && new DatabaseHelper().GetStatus("StopBot").Equals(true))
                        {
                            messageRouterResult = await MessageRouter.RouteMessageIfSenderIsConnectedAsync(activity);
                           
                        }

                    }
                    else if (new DatabaseHelper().GetStatus("UserCried").Equals(false) && new DatabaseHelper().GetStatus("JeetFirstTime").Equals(false) && (context.Activity.From.Id.Equals("Agent--AGB") || context.Activity.Recipient.Id.Equals("Agent--AGB")))
                    {
                        // Activity botActivity = new Activity();
                        new DatabaseHelper().UpdateStatus("StopBot", "True");
                        messageRouterResult = await MessageRouter.RouteMessageIfSenderIsConnectedAsync(activity);
                    }
                    else
                    {
                        messageRouterResult = await MessageRouter.RouteMessageIfSenderIsConnectedAsync(activity);
                    }
                    if (context.Activity.From.Id.Equals("Jeet") || context.Activity.Recipient.Id.Equals("Jeet") && new DatabaseHelper().GetStatus("JeetFirstTime").Equals(true))
                    {
                        new DatabaseHelper().UpdateStatus("JeetFirstTime", "false");
                    }
                    if (messageRouterResult is MessageRoutingResult
                        && (messageRouterResult as MessageRoutingResult).Type == MessageRoutingResultType.NoActionTaken)
                    {
                        // No action was taken by the message router. This means that the user
                        // is not connected (in a 1:1 conversation) with a human
                        // (e.g. customer service agent) yet.

                        // Check for cry for help (agent assistance)
                        //if (!string.IsNullOrWhiteSpace(activity.Text)
                        //    && activity.Text.ToLower().Contains("human"))
                        if(IsTransferrable(activity.Text.ToLower()))
                        {
                            // Create a connection request on behalf of the sender
                            // Note that the returned result must be handled
                            messageRouterResult = MessageRouter.CreateConnectionRequest(
                                MessageRouter.CreateSenderConversationReference(activity),
                                rejectConnectionRequestIfNoAggregationChannel);
                        }
                        else
                        {
                            // No action taken - this middleware did not consume the activity so let it propagate
                            await next(ct).ConfigureAwait(false);
                        }
                    }
                }

                // Uncomment to see the result in a reply (may be useful for debugging)
                //if (messageRouterResult != null)
                //{
                //    await MessageRouter.ReplyToActivityAsync(activity, messageRouterResult.ToString());
                //}

                // Handle the result, if necessary
                await MessageRouterResultHandler.HandleResultAsync(messageRouterResult);
            }
        }

        /// <summary>
        /// Extracts the channel list from the settings matching the given key.
        /// </summary>
        /// <returns>The list of channels or null, if none found.</returns>
        private IList<string> GetChannelList(string key)
        {
            IList<string> channelList = null;

            string channels = Configuration[key];

            if (!string.IsNullOrWhiteSpace(channels))
            {
                System.Diagnostics.Debug.WriteLine($"Channels by key \"{key}\": {channels}");
                string[] channelArray = channels.Split(',');

                if (channelArray.Length > 0)
                {
                    channelList = new List<string>();

                    foreach (string channel in channelArray)
                    {
                        channelList.Add(channel.Trim());
                    }
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"No channels defined by key \"{key}\" in app settings");
            }

            return channelList;
        }

        private bool IsTransferrable(string text)
        {
            var transferrableKeywords = new[] { "human", "agent", "support" };
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
            {
                if (true)
                {
                   return transferrableKeywords.Any(text.Contains);
                }
            }
            return false;
        }
    }
}
