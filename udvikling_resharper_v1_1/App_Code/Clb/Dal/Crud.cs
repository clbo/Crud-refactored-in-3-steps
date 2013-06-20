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
            SqlCommand _cmd = new SqlCommand();
            SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);

            _cmd.Connection = _conn;
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = StoredProcedureProperty;

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

            _conn.Open();
            _cmd.ExecuteNonQuery();
            _conn.Close();

        }

        public void Update()
        {
            SqlCommand _cmd = new SqlCommand();
            SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);

            _cmd.Connection = _conn;
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = StoredProcedureProperty;

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

            _conn.Open();
            _cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void Delete()
        {
            SqlCommand _cmd = new SqlCommand();
            SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);

            _cmd.Connection = _conn;
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = StoredProcedureProperty;

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

            _conn.Open();
            _cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public DataTable Select()
        {
            SqlCommand _cmd = new SqlCommand();
            SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);

            _cmd.Connection = _conn;
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = StoredProcedureProperty;

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

            _conn.Open();
            var reader = _cmd.ExecuteReader();

            var columnsinreader = reader.FieldCount;

            var dt = new DataTable();

            for (var i = 0; i < columnsinreader; i++)
            {
                dt.Columns.Add();
            }

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

    }
}