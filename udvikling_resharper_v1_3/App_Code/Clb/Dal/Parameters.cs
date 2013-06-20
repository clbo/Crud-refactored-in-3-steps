namespace Clb.Dal
{
    public class Parameters
    {
        private readonly Crud _crud;

        public Parameters(Crud crud)
        {
            _crud = crud;
        }

        public void AddParameters()
        {
            if (_crud.DataTableProperty != null)
            {
                var result = _crud.DataTableProperty.Select();
                foreach (var row in result)
                {
                    for (var i = 1; i <= row.ItemArray.Length; i++)
                    {
                        _crud.Cmd.Parameters.AddWithValue(string.Format("@{0}", i), row[i - 1]);
                    }
                }
            }
        }
    }
}