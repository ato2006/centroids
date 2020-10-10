using Centroids.Core.Interfaces;
using System;
using System.Collections.Generic;


namespace Centroids.Core.Mathematics
{
    public class Distributor : IDistributor
    {
        private readonly int ClusterLen;
        private readonly int Dim;
        private readonly int Maximum;

        private List<Cluster> Clusters = new List<Cluster>();
        private List<Vec2> Points = new List<Vec2>();
        private List<Vec2> PrevCentroids = new List<Vec2>();

        private readonly Random RndGenerator = new Random();

        public Distributor(List<Vec2> p, int len, int max)
        {
            Points = p;
            Dim = p.Count;
            ClusterLen = len;
            Maximum = max;

            for (int i = 0; i < ClusterLen; ++i)
            {
                PrevCentroids.Add(new Vec2(Dim, 0));
                Clusters.Add(new Cluster(0));
            }
        }

        public void DistributeRandom()
        {
            int index = 0;

            for (int i = 0; i < Points.Count; ++i)
            {
                index = RndGenerator.Next();
                Clusters[i].AddPoint(Points[i]);
            }

            var c = new Cluster(0);

            for (int i = 0; i < ClusterLen; ++i)
            {
                c = Clusters[i];
                c.SetPoints(c.EmbedData().Count);
                Clusters[i] = c;
            }

            CalculateCentroid();
        }

        public void Match()
        {
            for (int i = 0; i < ClusterLen; ++i)
            {
                int x = RndGenerator.Next(Maximum);
                int y = RndGenerator.Next(Maximum);

                Clusters[i].SetCentroid(new Vec2(x, y));
            }
        }

        public void Initialize()
        {
            for (int i = 0; i < ClusterLen; ++i)
            {
                int r = RndGenerator.Next(Points.Count);
                Clusters[i].SetCentroid(Points[r]);
            }
        }

        public void CalculateCentroid()
        {
            for (int i = 0; i < ClusterLen; ++i)
            {
                var c = Clusters[i];
                var centroid = new Vec2();
                var p = c.EmbedData();

                if (c.GetPoints() == 0)
                    continue;

                for (int j = 0; j < c.GetPoints(); ++j)
                {
                    var vec = p[j];

                    for (int k = 0; k < Dim; ++k)
                        centroid.X += p[k].X;
                }

                for (int k = 0; k < 2; ++k)
                    centroid.Y = centroid.Y / c.GetPoints();

                Clusters[i].SetCentroid(centroid);
            }
        }
    }
}
