using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SPCodeRun.Csom.Extensions {
    public static class StringExtensions {
        /// <summary>
        /// Get src value
        /// </summary>
        public static SecureString ToSecureString(this string plainString) {
            if (plainString == null)
                return null;

            var secureString = new SecureString();
            foreach (char c in plainString.ToCharArray()) {
                secureString.AppendChar(c);
            }

            return secureString;
        }
    }
}
