using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public interface IDataSeedService
    {
        void SeedDb(bool motherOfAllSeeds = false);
    }
}
