using System.Threading.Tasks;
using Leak.Common;

namespace Leak.Client.Swarm
{
    public static class SwarmHelper
    {
        public static void Download(string destination, string metaDest, FileHash hash, string tracker)
        {
            DownloadAsync(destination, metaDest, hash, tracker, null).Wait();
        }

        public static void Download(string destination, string metaDest, FileHash hash, string tracker, NotificationCallback callback)
        {
            DownloadAsync(destination, metaDest, hash, tracker, callback).Wait();
        }

        public static Task DownloadAsync(string destination, string metaDest, FileHash hash, string tracker)
        {
            return DownloadAsync(destination, metaDest, hash, tracker, null);
        }

        public static async Task DownloadAsync(string destination, string metaDest, FileHash hash, string tracker, NotificationCallback callback)
        {
            using (SwarmClient client = new SwarmClient())
            {
                Notification notification;
                SwarmSession session = await client.ConnectAsync(hash, tracker);

                session.Download(destination, metaDest);

                while (true)
                {
                    notification = await session.NextAsync();
                    callback?.Invoke(notification);

                    if (notification.Type == NotificationType.DataCompleted)
                        break;
                }
            }
        }

        public static void Seed(string destination, string metaDest, FileHash hash, string tracker)
        {
            SeedAsync(destination, metaDest, hash, tracker, null).Wait();
        }

        public static void Seed(string destination, string metaDest, FileHash hash, string tracker, NotificationCallback callback)
        {
            SeedAsync(destination, metaDest, hash, tracker, callback).Wait();
        }

        public static Task SeedAsync(string destination, string metaDest, FileHash hash, string tracker)
        {
            return SeedAsync(destination, metaDest, hash, tracker, null);
        }

        public static async Task SeedAsync(string destination, string metaDest, FileHash hash, string tracker, NotificationCallback callback)
        {
            using (SwarmClient client = new SwarmClient())
            {
                Notification notification;
                SwarmSession session = await client.ConnectAsync(hash, tracker);

                session.Seed(destination, metaDest);

                while (true)
                {
                    notification = await session.NextAsync();
                    callback?.Invoke(notification);
                }
            }
        }
    }
}