using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.Implementations
{
    public class DataSeedService : IDataSeedService
    {
        private readonly UnitOfWork _unitOfWork;

        public DataSeedService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SeedDb(bool motherOfAllSeeds)
        {
            _unitOfWork.SeedDb(motherOfAllSeeds);            
        }
    }
}
