using System;
using System.Threading.Tasks;

namespace SlackIntegration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.WaitAll(IntegrateWithSlackAsync());
        }

        private static async Task IntegrateWithSlackAsync()
        {
            //Set the valid URL of the Slack's Webhook.
            var webhookUrl = new Uri("https://hooks.slack.com/services/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");
            var slackClient = new SlackClient(webhookUrl);
            while (true)
            {
                Console.Write("Type a message: ");
                var message = Console.ReadLine();
                var response = await slackClient.SendMessageAsync(message);
                var isValid = response.IsSuccessStatusCode ? "valid" : "invalid";
                Console.WriteLine($"Received {isValid} response.");
            }
        }
    }
}
