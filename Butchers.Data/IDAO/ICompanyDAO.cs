using Butchers.Data.BEANS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.IDAO
{
    public interface ICompanyDAO
    {
        IList<MessageBEAN> GetMessages();
        void AddMessage(Message message);
    }
}
