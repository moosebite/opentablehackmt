using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ReactOpenTable.Extensions
{
    public static class ReaderExtensions
    {

        public static DateTime? GetNullableDateTime(this SqlDataReader reader, string name)
        {
            var col = reader.GetOrdinal(name);
            return reader.IsDBNull(col) ?
                        (DateTime?)null :
                        (DateTime?)reader.GetDateTime(col);
        }

        public static int? ToInt(this string str)
        {
            int temp;
            if (int.TryParse(str, out temp))
            {
                return temp;
            }
            return null;
        }
    }
}
