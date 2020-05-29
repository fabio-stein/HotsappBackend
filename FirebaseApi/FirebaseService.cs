using Flurl.Http;

namespace FirebaseApi
{
    public class FirebaseService
    {
        private string FIREBASE_KEY;
        public FirebaseService(string firebaseKey)
        {
            FIREBASE_KEY = firebaseKey;
        }

        private T FirebasePostRequest<T, K>(string ApiMethod, K Data)
        {
            var response = $"https://www.googleapis.com/identitytoolkit/v3/relyingparty/{ApiMethod}?key={FIREBASE_KEY}"
                .PostUrlEncodedAsync(Data)
                .ReceiveJson<T>().Result;
            return response;
        }
        public AccountInfo getAccountInfo(string idToken)
        {
            return FirebasePostRequest<AccountInfo, dynamic>("getAccountInfo", new { idToken });
        }
    }
}
