using System.Data;

namespace Clb.Dal
{
    public class InitializeCommand
    {
        private readonly Crud _crud;
        private readonly CommandType _commandType;

        public InitializeCommand(Crud crud)
        {
            _crud = crud;
            _commandType = new CommandType(this);
        }

        public Crud Crud
        {
            get { return _crud; }
        }

        public void Command()
        {
            _crud.Cmd.Connection = _crud.Conn;
            _commandType.TypeOfCommand();
            _crud.Cmd.CommandText = _crud.StoredProcedureProperty;
        }
    }
}