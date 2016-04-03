using System.Collections.Generic;
using System.Data;
using DataLayerSaveCommon;
using Microsoft.SqlServer.Server;
using SaveDataCommon;

namespace DataLayerReorder
{
    public abstract class DbReorder : DbSaveBase
    {
        protected internal static DataTable ConvertToDatatable(List<DisplayReorder> list)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof (int));
            dt.Columns.Add("DisplayOrder", typeof (short));
            foreach (DisplayReorder item in list)
            {
                DataRow row = dt.NewRow();

                row["ID"] = item.Id;
                row["DisplayOrder"] = item.DisplayOrder;

                dt.Rows.Add(row);
            }

            return dt;
        }

        protected internal class DataOrder : List<DisplayReorder>, IEnumerable<SqlDataRecord>
        {
            IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
            {
                SqlDataRecord sdr = new SqlDataRecord(
                    new SqlMetaData("ID", SqlDbType.Int),
                    new SqlMetaData("DisplayOrder", SqlDbType.Int)
                    );

                foreach (DisplayReorder data in this)
                {
                    sdr.SetInt32(0, data.Id);
                    sdr.SetInt16(1, data.DisplayOrder);
                    yield return sdr;
                }
            }
        }
    }
}