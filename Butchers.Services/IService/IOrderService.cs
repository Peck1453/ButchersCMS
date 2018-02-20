using Butchers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Services.IService
{
    public interface IOrderService
    {
        IList<PromoCode> GetPromoCodes();
        PromoCode GetPromoDetail(string id);
        void AddPromoCode(PromoCode code);
        void EditPromoCode(PromoCode code);
        void DeletePromoCode(PromoCode code);

    }
}
