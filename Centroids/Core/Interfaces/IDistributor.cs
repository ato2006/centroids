using System;
using System.Collections.Generic;
using System.Text;

namespace Centroids.Core.Interfaces
{
    public interface IDistributor
    {
        void Initialize();
        void DistributeRandom();
        void Match();
        void CalculateCentroid();
    }
}
