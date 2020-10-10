using Centroids.Core;
using Centroids.Core.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Centroids.Generator.Models
{
    public interface IDataGenerator
    {
        void Initialize(int n, int p);
        void GenerateClusters();
    }
}
