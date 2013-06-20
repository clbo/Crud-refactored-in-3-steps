using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Clb.Dal
{
    /// <summary>
    ///     Crud methods that takes a storedprocedure name and alternately a DataTable with parameters
    /// </summary>
    public class Crud
    {
        private readonly SqlCommand _cmd = new SqlCommand();
        private readonly SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);
        

        public Crud(string storedProcedure)
        {      
            StoredProcedureProperty = storedProcedure;
        }

        public Crud(string storedProcedure, DataTable dataTableProperty)
        {
            DataTableProperty = dataTableProperty;
            StoredProcedureProperty = storedProcedure;
        }

        public DataTable DataTableProperty { get; private set; }
        public string StoredProcedureProperty { get; private set; }
       

        public void Insert()
        {
            Command();
            AddParameters();
            ExecuteNonQuery();
        }

        public void Update()
        {
            Command();
            AddParameters();
            ExecuteNonQuery();
        }

        public void Delete()
        {
            Command();
            AddParameters();
            ExecuteNonQuery();
        }

        public DataTable Select()
        {
            Command();
            AddParameters();
            var dt = ExecuteReaderAndReturnDataTable();
            return dt;
        }

        private void Command()
        {
            _cmd.Connection = _conn;
            TypeOfCommand();
            _cmd.CommandText = StoredProcedureProperty;
        }

        private void TypeOfCommand()
        {
            if (StoredProcedureProperty.StartsWith("SP_"))
            {
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
            }
            else
            {
                _cmd.CommandType = System.Data.CommandType.Text;
            }
        }

        private void ExecuteNonQuery()
        {
            _conn.Open();
            _cmd.ExecuteNonQuery();
            _conn.Close();
        }

        private DataTable ExecuteReaderAndReturnDataTable()
        {
            _conn.Open();
            var reader = _cmd.ExecuteReader();

            var columnsinreader = reader.FieldCount;
            var dt = CreateDataTableWithColumns(columnsinreader);

            while (reader.Read())
            {
                var objarray = new object[columnsinreader];
                for (var i = 0; i < columnsinreader; i++)
                {
                    objarray[i] = reader[i];
                }

                dt.Rows.Add(objarray);
            }
            _conn.Close();
            return dt;
        }

        private void AddParameters()
        {
            if (DataTableProperty != null)
            {
                var result = DataTableProperty.Select();
                foreach (var row in result)
                {
                    for (var i = 1; i <= row.ItemArray.Length; i++)
                    {
                        _cmd.Parameters.AddWithValue(string.Format("@{0}", i), row[i - 1]);
                    }
                }
            }
        }

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