
namespace SPCodeRun.Csom {

    using Microsoft.SharePoint.Client;
    using OfficeDevPnP.Core;
    using SPCodeRun.SharePointContext;

    /// <inheritdoc/>
    public class Context : IContext {
        private readonly string _siteUrl;
        private readonly string _userEmail;
        private readonly string _userPassword;

        /// <inheritdoc/>
        public Context(string siteUrl, string userEmail, string userPassword) {
            _siteUrl = siteUrl;
            _userEmail = userEmail;
            _userPassword = userPassword;
        }

        /// <inheritdoc/>
        public ListCollection GetLists() {
            using (var clientContext = new AuthenticationManager().GetSharePointOnlineAuthenticatedContextTenant(_siteUrl, _userEmail, _userPassword)) {
                var spLists = clientContext.Web.Lists;

                clientContext.Load(spLists);
                clientContext.ExecuteQuery();

                return spLists;
            }
        }


        /// <inheritdoc/>
        public List GetList(string listTitle) {
            using (var clientContext = new AuthenticationManager().GetSharePointOnlineAuthenticatedContextTenant(_siteUrl, _userEmail, _userPassword)) {
                var spList = clientContext.Web.GetListByTitle(listTitle);

                clientContext.Load(spList);
                clientContext.ExecuteQuery();

                return spList;
            }
        }

        /// <inheritdoc/>
        public ListItemCollection GetListItems(string listTitle) {
            using (var clientContext = new AuthenticationManager().GetSharePointOnlineAuthenticatedContextTenant(_siteUrl, _userEmail, _userPassword)) {
                var spList = clientContext.Web.GetListByTitle(listTitle);
                var spListItems = spList.GetItems(CamlQuery.CreateAllItemsQuery());

                clientContext.Load(spListItems);
                clientContext.ExecuteQuery();

                return spListItems;
            }
        }
    }
}