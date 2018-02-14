using Butchers.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.DAO
{
    public class OrderDAO : IOrderDAO
    {

        private ButchersEntities _context;
        public OrderDAO()
        {
            _context = new ButchersEntities();
        }


        public IList<PromoCode> GetPromoCodes()
        {
            IQueryable<PromoCode> _promoCodes;
            _promoCodes = from code
                          in _context.PromoCode
                     select code;
            return _promoCodes.ToList();
        }


    }
        
    }
