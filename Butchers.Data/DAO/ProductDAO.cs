using Butchers.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.DAO
{
    public class ProductDAO : IProductDAO
    {
        private ButchersEntities _context;

        public ProductDAO()
        {
            _context = new ButchersEntities();
        }
        
        public IList<Meat> GetMeats()
        {
            IQueryable<Meat> _meats;

            _meats = from meat
                     in _context.Meat
                     select meat;

            return _meats.ToList();
        }

        public Meat GetMeat(int id)
        {
            IQueryable<Meat> _meat;

            _meat = from meat
                    in _context.Meat
                    where meat.Id == id
                    select meat;

            return _meat.ToList().First();
        }

        public void AddMeat(Meat meat)
        {
            _context.Meat.Add(meat);
            _context.SaveChanges();
        }

        public void EditMeat(Meat meat)
        {
            Meat myMeat = GetMeat(meat.Id);

            myMeat.Name = meat.Name;
            _context.SaveChanges();
        }
    }
}
