﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Butchers.Data;
using Butchers.Data.BEANS;

namespace Butchers.Data.IDAO
{
    public interface IOrderDAO
    {
        // Product Code
        IList<PromoCodeBEAN> GetPromoCodes();
        PromoCode GetPromoDetail(string id);
        void AddPromoCode(PromoCode code);
        void EditPromoCode(PromoCode code);
        void DeletePromoCode(PromoCode code);
    }
}
