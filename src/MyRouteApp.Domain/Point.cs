using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyRouteApp.Domain
{
    public class Point
    {
        public int Id { get; private set; }
        public String Name { get; private set; }
        public List<Route> DestinationList { get; set; }
        public Point(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            DestinationList = new List<Route>();
        }

        public FullPath FindShortestPath(Point destinationPoint)
        {
            var allPaths = this.FindPaths(destinationPoint);
            return allPaths.OrderBy(x => x.TotalCostofPath).FirstOrDefault();
        }


        public List<FullPath> FindPaths(Point destinationPoint)
        {
            List<FullPath> fullPathList = new List<FullPath>();
            var directPath = DestinationList.Where(x => x.DestinationPoint.Id == destinationPoint.Id).FirstOrDefault();
            if (directPath != null)
            {
                FullPath fullPath = new FullPath();
                Path path = new Path();
                path.OriginalPoint = this;
                path.Destination = directPath;
                fullPath.PathList.Add(path);
                fullPathList.Add(fullPath);
                return fullPathList;
            }
            else
            {
                FindInside(fullPathList, new FullPath(), this, destinationPoint);
                return fullPathList;
            }
        }


        private void FindInside(List<FullPath> fullPathList, FullPath currentFullPath, Point originalPoint, Point destinationPoint)
        {
            var s = originalPoint.Name;

            var childsNotVisitedYet = originalPoint.DestinationList.Where(x =>
                !currentFullPath.PathList.Exists(y =>
                (y.Destination.DestinationPoint.Id == x.DestinationPoint.Id
                ||
                y.OriginalPoint.Id == x.DestinationPoint.Id)

                )).ToList();


            foreach (var item in childsNotVisitedYet)
            {
                FullPath possiblePath = currentFullPath.Clone();
                possiblePath.PathList.Add(
                    new Path
                    {
                        OriginalPoint = originalPoint,
                        Destination = item
                    });

                if (item.DestinationPoint.Id == destinationPoint.Id)
                {
                    fullPathList.Add(possiblePath);
                    continue;
                }

                if (item.DestinationPoint.DestinationList == null ||
                    item.DestinationPoint.DestinationList.Count == 0)
                    continue;
                
                FindInside(fullPathList, possiblePath, item.DestinationPoint, destinationPoint);

            }
        }

    }
}
