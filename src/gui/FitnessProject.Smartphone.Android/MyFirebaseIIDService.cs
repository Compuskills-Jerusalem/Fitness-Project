using System;
using Android.App;
using Firebase.Iid;
using Android.Util;
using System.Collections.Generic;
using System.Net.Http;

namespace PN_XAML.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            SendToServerAsync(refreshedToken);
        }
        public async System.Threading.Tasks.Task SendToServerAsync(string token)
        {

            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                {new KeyValuePair<string, string>(key: "Email", value: LoginManager.CurrentUser.Username) },
                {new KeyValuePair<string, string>(key: "Token", value: token) }
            };
            FormUrlEncodedContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync("http://www.compuskillscapstoneprojekt.com", q))
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();
                        Console.WriteLine(myContent);
                    }
                }
            }

        }
    }
}