using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRouteApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRouteApp.Tests.Domain
{

    [TestClass]
    public class FindPathsTest
    {
        Point A;
        Point B;
        Point C;
        Point D;
        Point E;
        Point F;
        Point G;
        Point H;
        Point I;

        [TestInitialize]
        public void PopulateFakeData()
        {

            A = new Point(1, "A");
            B = new Point(2, "B");
            C = new Point(3, "C");
            D = new Point(4, "D");
            E = new Point(5, "E");
            F = new Point(6, "F");
            G = new Point(7, "G");
            H = new Point(8, "H");
            I = new Point(9, "I");
            A.DestinationList.Add(new Route(C, cost: 20, time: 1));
            A.DestinationList.Add(new Route(H, cost: 10, time: 1));
            A.DestinationList.Add(new Route(E, cost: 5, time: 30));

            //B.DestinationList.Add(new Route(G, cost: 73, time: 64));
            //B.DestinationList.Add(new Route(C, cost: 12, time: 1));
            //B.DestinationList.Add(new Route(I, cost: 5, time: 65));

            C.DestinationList.Add(new Route(B, cost: 12, time: 1));
            //C.DestinationList.Add(new Route(A, cost: 20, time: 1));

            //D.DestinationList.Add(new Route(E, cost: 5, time: 3));
            D.DestinationList.Add(new Route(F, cost: 50, time: 4));

            E.DestinationList.Add(new Route(D, cost: 5, time: 3));
            //E.DestinationList.Add(new Route(A, cost: 30, time: 5));
            //E.DestinationList.Add(new Route(H, cost: 1, time: 30));

            //F.DestinationList.Add(new Route(D, cost: 50, time: 4));
            F.DestinationList.Add(new Route(I, cost: 50, time: 45));
            F.DestinationList.Add(new Route(G, cost: 50, time: 40));

            //G.DestinationList.Add(new Route(F, cost: 50, time: 40));
            G.DestinationList.Add(new Route(B, cost: 73, time: 64));

            H.DestinationList.Add(new Route(E, cost: 1, time: 30));
            //H.DestinationList.Add(new Route(A, cost: 10, time: 1));

            //I.DestinationList.Add(new Route(F, cost: 50, time: 45));
            I.DestinationList.Add(new Route(B, cost: 5, time: 65));
        }

        [TestMethod]
        public void FindPathsFromDistancePointsAtoB()
        {
            var result = A.FindPaths(B);
            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void FindPathsFromDistancePointsEtoG()
        {
            var result = E.FindPaths(G);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void FindPathsFromDistancePointsEtoUnkownPoint()
        {
            var result = E.FindPaths(new Point(2312,""));
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void FindSortestPathFromDistancePointsAtoB()
        {
            var result = A.FindShortestPath(B);
            Assert.AreEqual(32, result.TotalCostofPath);
        }

        [TestMethod]
        public void FindSortestPathFromDistancePointsAtoUnknownPoint()
        {
            var result = E.FindShortestPath(new Point(2312, ""));
            Assert.IsNull(result);
        }
    }
}
