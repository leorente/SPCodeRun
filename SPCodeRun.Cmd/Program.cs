using SPCodeRun.Csom;
using System;

namespace SPCodeRun.Cmd {
    class Program {
        static void Main(string[] args) {
            GetListItemsFromSiteListsCSOM("https://leonardorente.sharepoint.com/sites/MySite", "leonardo.rente@company.onmicrosoft.com.br", "*****");

            Console.ReadKey();
        }

        /// <summary>
        /// Get All items from all list on SharePoint Site
        /// </summary>
        /// <param name="sharepointSiteUrl">SharePoint Online Site URL</param>
        /// <param name="email">Office 365 Email</param>
        /// <param name="password">Office 365 Password</param>
        private static void GetListItemsFromSiteListsCSOM(string sharepointSiteUrl, string email, string password) {
            var context = new Context(sharepointSiteUrl, email, password);
            var lists = context.GetLists();

            Console.WriteLine($"## Lists ##");
            foreach (var list in lists) {
                Console.WriteLine($"  - List Title: {list.Title}");


                Console.WriteLine($"## List Items ##");
                var items = context.GetListItems(list.Title);
                foreach (var item in items) {
                    Console.WriteLine($"      - Item Id: {item.Id}");
                }
            }
        }
    }
}
