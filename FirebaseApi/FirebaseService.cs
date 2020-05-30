using Flurl.Http;
using System.Threading.Tasks;

namespace FirebaseApi
{
    public class FirebaseService
    {
        private string FIREBASE_KEY;
        public FirebaseService(string firebaseKey)
        {
            FIREBASE_KEY = firebaseKey;
        }

        private async Task<T> FirebasePostRequest<T, K>(string ApiMethod, K Data)
        {
            var response = await $"https://www.googleapis.com/identitytoolkit/v3/relyingparty/{ApiMethod}?key={FIREBASE_KEY}"
                .PostUrlEncodedAsync(Data)
                .ReceiveJson<T>();
            return response;
        }
        public async Task<AccountInfo> getAccountInfo(string idToken)
        {
            return await FirebasePostRequest<AccountInfo, dynamic>("getAccountInfo", new { idToken });
        }
    }
}
