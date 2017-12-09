using Newtonsoft.Json;
using SkyMonitor.Business.Configs;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SkyMonitor.Business.Helpers
{
    public static class PushNotificationsHelper
    {
        private static string apiKey;
        private static string senderId;

        static PushNotificationsHelper()
        {
            apiKey = ConfigurationManager.AppSettings[Constants.PUSH_NOTIFICATIONS_API_KEY];
            senderId = ConfigurationManager.AppSettings[Constants.PUSH_NOTIFICATIONS_SENDER_ID];
        }

        public static void SendNotification(string title, string message, string deviceId)
        {
            var request = new
            {
                to = deviceId,
                notification = new
                {
                    title = title,
                    body = message
                }
            };

            var json = JsonConvert.SerializeObject(request);

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"key={apiKey}");
                    client.DefaultRequestHeaders.Add("Sender", $"id={senderId}");
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    client.PostAsync(Constants.PUSH_NOTIFICATIONS_API_URL, content);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
