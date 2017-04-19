using SPCodeRun.Csom;
using System;

namespace SPCodeRun.Cmd {
    class Program {
        static void Main(string[] args) {
            var context = new Context("https://globosatdesenv.sharepoint.com/sites/portalcomercial-dev/pt-br", "leonardo.rente@globosatdesenv.com.br", "Le0n@rDo");
            var lists = context.GetLists();

            Console.WriteLine($"## Lists ##");
            foreach (var list in lists) {
                Console.WriteLine($"  - List Title: {list.Title}");


                Console.WriteLine($"## List Items ##");
                var items = context.GetListItems(list.Title);
                foreach (var item in items) {
                    Console.WriteLine($"      - Item Id: {item.Id}");
                    Console.WriteLine($"      - -------------------------------------");
                }
            }

            Console.ReadKey();
        }
    }
}
