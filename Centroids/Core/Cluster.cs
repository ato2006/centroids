using Centroids.Core.Interfaces;
using Centroids.Core.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Centroids.Core
{
    public class Cluster : ICluster
    {
        private int PointsLen;
        private readonly List<Vec2> Data;
        private Vec2 Centroid;

        public Cluster(int n)
        {
            PointsLen = n;
        }

        public void AddPoint(Vec2 p) => Data.Add(p);
        public int GetPoints() => PointsLen;
        public void SetPoints(int n) => PointsLen = n;
        public List<Vec2> EmbedData() => Data;
        public void SetCentroid(Vec2 center) => Centroid = center;
        public Vec2 GetCentroid() => Centroid;
    }
}
