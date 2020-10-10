using Centroids.Core.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Centroids.Core.Interfaces
{
    public interface ICluster
    {
        void AddPoint(Vec2 p);
        int GetPoints();

        void SetPoints(int n);

        List<Vec2> EmbedData();
        void SetCentroid(Vec2 center);
        Vec2 GetCentroid();
    }
}
