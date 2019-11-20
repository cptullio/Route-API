using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyRouteApp.Domain
{
    public class FullPath 
    {
        public FullPath()
        {
            PathList = new List<Path>();
        }
        public List<Path> PathList { get; set; }

        public int TotalCostofPath { 
            get {
                return (PathList.Sum(x => x.Destination?.Cost)??0);
            }
        }

        public FullPath Clone()
        {
            var clone = new FullPath();
            clone.PathList.AddRange(PathList);
            return clone;
        }

       
    }
}
