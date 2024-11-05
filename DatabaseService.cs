using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_restaurant
{
    public class DatabaseService
    {
        private readonly LabourContext _dbContext;

        DatabaseService(LabourContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Method to load all LabourRecords
        public List<LabourRecord> GetAllLabourRecords()
        {
            return _dbContext.LabourRecords.ToList();
        }

        // Method to save changes, add more methods as needed
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
