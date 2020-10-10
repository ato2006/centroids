using Centroids.Core;
using Centroids.Core.Mathematics;
using Centroids.Generator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Centroids.Generator
{
    public class DataGenerator : IDataGenerator
    {
        private int PointsLen;
        private int ClusterLen;
        private List<Cluster> Clusters = new List<Cluster>();
        public void Initialize(int n, int p)
        {
            PointsLen = n;
            ClusterLen = p;
            GenerateClusters();
        }
        public void GenerateClusters()
        {
            int avg = 0;
            int c = 0;

            avg = PointsLen / ClusterLen;

            for (int i = 0; i < ClusterLen / 2; ++i)
            {
                Clusters.Add(new Cluster(1));
                c = c + avg - i;
            }
                

            if (c != PointsLen)
            {
                int t = Clusters[0].GetPoints();
                for (int x = 0; x < PointsLen - c; ++x)
                    Clusters[0].SetPoints(++t);
            }
        }
    }
}
