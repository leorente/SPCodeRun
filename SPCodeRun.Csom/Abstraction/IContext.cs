using Microsoft.SharePoint.Client;
using System;
namespace SPCodeRun.SharePointContext.Abstraction {
    /// <summary>
    /// SharePoint Context
    /// </summary>
    interface IContext {
        /// <remarks>
        /// Details about the interface go here.
        /// </remarks>
        /// <summary>
        /// Get site lists
        /// </summary>
        /// <returns>Site list collection</returns>
        ListCollection GetLists();

        /// <summary>
        /// Get all items from list
        /// </summary>
        /// <param name="listTitle">List title</param>
        /// <returns>List item collection</returns>
        ListItemCollection GetListItems(string listTitle);
    }
}
