using Butchers.Data;
using Butchers.Data.BEANS;
using Butchers.Data.DAO;
using Butchers.Data.IDAO;
using Butchers.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Services.Service
{
    public class CompanyService : ICompanyService
    {
        private ICompanyDAO _companyDAO;

        public CompanyService()
        {
            _companyDAO = new CompanyDAO();
        }
        
        public IList<MessageBEAN> GetMessages()
        {
            return _companyDAO.GetMessages();
        }

        public void AddMessage(Message message)
        {
            _companyDAO.AddMessage(message);
        }
    }
}
