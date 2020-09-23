using System.Collections.Generic;

// sources:
// https://www.eshlomo.us/skype-for-business-2016-sdk-and-lync-2013-sdk/
// https://stackoverflow.com/questions/16213916/change-status-of-lync-by-script

namespace LyncControl
{
    public static class LyncControl
    {
        private static void setContactAvailability(Microsoft.Lync.Controls.ContactAvailability availability)
        {
            var client = Microsoft.Lync.Model.LyncClient.GetClient();
            if (client == null || client.State != Microsoft.Lync.Model.ClientState.SignedIn)
            {
                System.Console.WriteLine("Lync client not signed in. Cannot set status.");
                return;
            }

            var contactInfo = new Dictionary<Microsoft.Lync.Model.PublishableContactInformationType, object>();// as System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<Microsoft.Lync.Model.PublishableContactInformationType, object>>;
            contactInfo.Add(Microsoft.Lync.Model.PublishableContactInformationType.Availability, availability);

            var ar = client.Self.BeginPublishContactInformation(contactInfo, (System.AsyncCallback)null, (object)null);
            client.Self.EndPublishContactInformation(ar);
        }

        public static void setAway() => setContactAvailability(Microsoft.Lync.Controls.ContactAvailability.Away);
        public static void setBusy() => setContactAvailability(Microsoft.Lync.Controls.ContactAvailability.Busy);
        public static void setDoNotDisturb() => setContactAvailability(Microsoft.Lync.Controls.ContactAvailability.DoNotDisturb);
        public static void setFree() => setContactAvailability(Microsoft.Lync.Controls.ContactAvailability.Free);
        public static void setOffline() => setContactAvailability(Microsoft.Lync.Controls.ContactAvailability.Offline);
    }
}
