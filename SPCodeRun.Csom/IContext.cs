using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCodeRun.SharePointContext {
    interface IContext {
        ListCollection GetLists();

        List GetList(string listTitle);

        ListItemCollection GetListItems(string listTitle);
    }
}
