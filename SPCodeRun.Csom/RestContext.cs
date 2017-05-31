
namespace SPCodeRun.Csom {
    using Microsoft.SharePoint.Client;
    using SPCodeRun.Csom.Extensions;
    using System.Net.Http;
    using System;
    using System.Net;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class RestContext {
        private readonly string _siteUrl;
        private readonly string _userEmail;
        private readonly string _userPassword;
        private readonly ICredentials _sharePointOnlineCredentials;

        public RestContext(string siteUrl, string userEmail, string userPassword) {
            _siteUrl = siteUrl;
            _userEmail = userEmail;
            _userPassword = userPassword;

            _sharePointOnlineCredentials = new SharePointOnlineCredentials(_userEmail, _userPassword.ToSecureString());
        }

        public async Task<string> GetListsAsync() {
            return await GetAsync("_api/web/Lists/?$filter=Hidden eq false");
        }

        public async Task<string> GetAsync(string restApiUrl) {
            using (var handler = new HttpClientHandler() { Credentials = _sharePointOnlineCredentials }) {
                Uri uri = new Uri(_siteUrl);
                handler.CookieContainer.SetCookies(uri, (_sharePointOnlineCredentials as SharePointOnlineCredentials).GetAuthenticationCookie(uri));

                using (var client = new HttpClient(handler)) {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.GetAsync($"{uri.AbsoluteUri}/{restApiUrl}");
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        public List GetList(string listTitle) {
            throw new NotImplementedException();
        }

        public ListItemCollection GetListItems(string listTitle) {
            throw new NotImplementedException();
        }
    }
}