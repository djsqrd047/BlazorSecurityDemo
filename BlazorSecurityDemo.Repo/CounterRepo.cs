using BlazorSecurityDemo.Data;
using BlazorSecurityDemo.Repo.Interfaces;
using BlazorSecurityDemo.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSecurityDemo.Repo
{
    public class CounterRepo : ICounterRepo
    {
        private CounterContext _context;
        public CounterRepo(CounterContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<CurrentCount> GetCurrentCount() 
        {
            if (_context.CurrentCount.ToList().Any())
            {
                return _context.CurrentCount.ToList();
            }
            else
            {
                if (InsertNewCountRecord())
                {
                    return _context.CurrentCount.ToList();
                }
                else
                {
                    return new List<CurrentCount>() { new CurrentCount() { Id = 0, CurrentValue = 0 } };
                }
            }
        } 

        public IEnumerable<CurrentCount> IncrementCount(int id)
        {
            var currentCount = _context.CurrentCount.FirstOrDefault(c => c.Id == id);
            if (currentCount != null)
            {
                currentCount.CurrentValue++;
                Save();
            }
            else
            {
                InsertNewCountRecord();//
            }
            return GetCurrentCount();
        }


        public bool InsertNewCountRecord()
        {
            var newCurrentCountRecord = new CurrentCount();
            newCurrentCountRecord.CurrentValue = 0;
            _context.CurrentCount.Add(newCurrentCountRecord);
            return Save();
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
