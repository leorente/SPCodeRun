namespace SPCodeRun.Cmd {

    using SPCodeRun.Csom;
    using System;
    using System.Threading.Tasks;

    public class Program {
        public static void Main(string[] args) {
            var jsonItems = GetAvisosItemsRestApi("https://globosatdesenv.sharepoint.com/sites/portalcomercial-dev/pt-br", "leonardo.rente@globosatdesenv.com.br", "***");
        }


        /// <summary>
        /// Carrega Json de todos os items da lista de Avisos
        /// </summary>
        /// <param name="sharepointSiteUrl"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetAvisosItemsRestApi(string sharepointSiteUrl, string email, string password) {
            var restContext = new RestContext(sharepointSiteUrl, email, password);

            return restContext.GetAsync("/_api/web/lists/GetByTitle('Avisos')/Items").Result;
        }

        /// <summary>
        /// Get All items from all list on SharePoint Site
        /// </summary>
        /// <param name="sharepointSiteUrl">SharePoint Online Site URL</param>
        /// <param name="email">Office 365 Email</param>
        /// <param name="password">Office 365 Password</param>
        //private static void GetListItemsFromSiteListsCSOM(string sharepointSiteUrl, string email, string password) {
        //    var context = new CsomContext(sharepointSiteUrl, email, password);
        //    var lists = context.GetLists();

        //    Console.WriteLine($"## Lists ##");
        //    foreach (var list in lists) {
        //        Console.WriteLine($"  - List Title: {list.Title}");


        //        Console.WriteLine($"## List Items ##");
        //        var items = context.GetListItems(list.Title);
        //        foreach (var item in items) {
        //            Console.WriteLine($"      - Item Id: {item.Id}");
        //        }
        //    }
        //}
    }
}
