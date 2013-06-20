using System.Data;
using Clb.Bll;

namespace Clb.Dal
{
    public class Query
    {
        private readonly Crud _crud;

        public Query(Crud crud)
        {
            _crud = crud;
        }

        public void ExecuteNonQuery()
        {
            _crud.Conn.Open();
            _crud.Cmd.ExecuteNonQuery();
            _crud.Conn.Close();
        }

        public DataTable ExecuteReaderAndReturnDataTable()
        {
            _crud.Conn.Open();
            var reader = _crud.Cmd.ExecuteReader();

            var columnsinreader = reader.FieldCount;
            var dt = CreateDataTable.CreateDataTableWithColumns(columnsinreader);

            while (reader.Read())
            {
                var objarray = new object[columnsinreader];
                for (var i = 0; i < columnsinreader; i++)
                {
                    objarray[i] = reader[i];
                }

                dt.Rows.Add(objarray);
            }
            _crud.Conn.Close();
            return dt;
        }
    }
}