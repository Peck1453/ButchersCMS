using Butchers.Data;
using Butchers.Data.BEANS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Services.IService
{
    public interface ICompanyService
    {
        IList<MessageBEAN> GetMessages();
        void AddMessage(Message message);
    }
}
