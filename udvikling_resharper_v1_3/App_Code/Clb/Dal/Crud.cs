using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Clb.Bll;

namespace Clb.Dal
{
    /// <summary>
    ///     Crud methods that takes a storedprocedure name and optionally a DataTable with parameters
    /// </summary>
    public class Crud
    {
        private readonly SqlCommand _cmd = new SqlCommand();
        private readonly SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);
        private readonly InitializeCommand _initializeCommand;
        private readonly Parameters _parameters;
        private readonly Query _query;

        public Crud(string storedProcedure)
        {
            _parameters = new Parameters(this);
            _query = new Query(this);
            _initializeCommand = new InitializeCommand(this);
            StoredProcedureProperty = storedProcedure;
        }

        public Crud(string storedProcedure, DataTable dataTableProperty)
        {
            _parameters = new Parameters(this);
            _query = new Query(this);
            _initializeCommand = new InitializeCommand(this);
            DataTableProperty = dataTableProperty;
            StoredProcedureProperty = storedProcedure;
        }

        public DataTable DataTableProperty { get; private set; }
        public string StoredProcedureProperty { get; private set; }
        public SqlConnection Conn { get { return _conn; } }
        public SqlCommand Cmd { get { return _cmd; } }

        public void Insert()
        {
            _initializeCommand.Command();
            _parameters.AddParameters();
            _query.ExecuteNonQuery();
        }

        public void Update()
        {
            _initializeCommand.Command();
            _parameters.AddParameters();
            _query.ExecuteNonQuery();
        }

        public void Delete()
        {
            _initializeCommand.Command();
            _parameters.AddParameters();
            _query.ExecuteNonQuery();
        }

        public DataTable Select()
        {
            _initializeCommand.Command();
            _parameters.AddParameters();
            var dt = _query.ExecuteReaderAndReturnDataTable();
            return dt;
        }
    }
}