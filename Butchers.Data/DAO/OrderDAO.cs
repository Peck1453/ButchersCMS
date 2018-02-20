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
        public PromoCode GetPromoDetail(string Id)
        {
            IQueryable<PromoCode> _code;

            _code = from pcode
                    in _context.PromoCode
                    where pcode.Code == Id
                    select pcode;

            return _code.ToList().First();
        }

        public void AddPromoCode(PromoCode code)
        {
            _context.PromoCode.Add(code);
            _context.SaveChanges();
        }
        

        public void EditPromoCode(PromoCode pcode)
        {

            
            PromoCode _code = GetPromoDetail(pcode.Code);
            _code.Discount = pcode.Discount;
            _code.ValidUntil = pcode.ValidUntil;
            _context.SaveChanges();
        }
        public void DeletePromoCode(PromoCode code)
        {
            _context.PromoCode.Remove(code);
            _context.SaveChanges();
        }


    }

}
