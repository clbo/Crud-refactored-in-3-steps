namespace Clb.Dal
{
    public class CommandType
    {
        private readonly InitializeCommand _initializeCommand;

        public CommandType(InitializeCommand initializeCommand)
        {
            _initializeCommand = initializeCommand;
        }

        public void TypeOfCommand()
        {
            if (_initializeCommand.Crud.StoredProcedureProperty.StartsWith("SP_"))
            {
                _initializeCommand.Crud.Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            }
            else
            {
                _initializeCommand.Crud.Cmd.CommandType = System.Data.CommandType.Text;
            }
        }
    }
}