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
        public PromoCode GetPromoDetail(string id)
        {
            IQueryable<PromoCode> _code;

            _code = from code
                    in _context.PromoCode
                    where code.Code == "id"
                    select code;

            return _code.ToList().First();
        }

        public void AddPromoCode(PromoCode code)
        {
            _context.PromoCode.Add(code);
            _context.SaveChanges();
        }
        

        public void EditPromoCode(PromoCode code)
        {
            PromoCode pcode = GetPromoDetail(code.Code);
            pcode.Discount = code.Discount;
            pcode.ValidUntil = code.ValidUntil;
            _context.SaveChanges();
        }
        public void DeletePromoCode(PromoCode code)
        {
            _context.PromoCode.Remove(code);
            _context.SaveChanges();
        }


    }

}
