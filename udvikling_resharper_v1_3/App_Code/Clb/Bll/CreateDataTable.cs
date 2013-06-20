using System.Data;

namespace Clb.Bll
{
    public class CreateDataTable
    {
        public static DataTable CreateDataTableWithColumns(int columns)
        {
            var dt = new DataTable();

            for (var i = 0; i < columns; i++)
            {
                dt.Columns.Add();
            }
            return dt;
        }
    }
}