using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormApp.Core.Shapes;

namespace FormApp.Core.DAO
{
    public interface IDAOForm
    {
        void Save(Shape f);
        Shape Load(int id);
    }
}
