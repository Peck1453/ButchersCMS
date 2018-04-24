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

        // Gets a list of messages which is displayed to the customer in their dashboard
        public IList<MessageBEAN> GetMessages()
        {
            IQueryable<MessageBEAN> _messages;

            _messages = (from message in _context.Message
                        orderby message.MessageDate descending // We want the newest message to be displayed at the top of the list
                        select new MessageBEAN
                        {
                            MessageSubject = message.MessageSubject,
                            MessageBody = message.MessageBody,
                            MessageAuthor = message.MessageAuthor,
                            MessageDate = message.MessageDate
                        }).Take(4); // We only want the latest 4 messages

            return _messages.ToList();
        }

        // Allows staff and managers to add messages for the customers.
        public void AddMessage(Message message)
        {
            _context.Message.Add(message);
            _context.SaveChanges();
        }
    }
}
