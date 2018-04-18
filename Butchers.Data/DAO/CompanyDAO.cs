using Butchers.Data.BEANS;
using Butchers.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.DAO
{
    public class CompanyDAO : ICompanyDAO
    {

        private ButchersEntities _context;

        public CompanyDAO()
        {
            _context = new ButchersEntities();
        }

        public IList<MessageBEAN> GetMessages()
        {
            IQueryable<MessageBEAN> _messages;

            _messages = (from message in _context.Message
                        orderby message.MessageDate descending
                        select new MessageBEAN
                        {
                            MessageSubject = message.MessageSubject,
                            MessageBody = message.MessageBody,
                            MessageAuthor = message.MessageAuthor,
                            MessageDate = message.MessageDate
                        }).Take(4);

            return _messages.ToList();
        }

        public void AddMessage(Message message)
        {
            _context.Message.Add(message);
            _context.SaveChanges();
        }
    }
}
