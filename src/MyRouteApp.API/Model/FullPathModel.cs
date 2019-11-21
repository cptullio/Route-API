using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRouteApp.API.Model
{
    public class FullPathModel
    {
        public FullPathModel()
        {
            PathList = new List<PathFoundModel>();
        }
        public List<PathFoundModel> PathList { get; set; }
        public int TotalCost { get; set; }
    }
}
