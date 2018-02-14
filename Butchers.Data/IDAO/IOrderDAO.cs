﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Butchers.Data;

namespace Butchers.Data.IDAO
{
    public interface IOrderDAO
    {
        IList<PromoCode> GetPromoCodes();
    }
}
