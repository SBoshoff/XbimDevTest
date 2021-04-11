using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbim.Ifc;
using Xbim.Ifc4.ProductExtension;

namespace XbimDev1.Services.Implementation
{
    public class CoreService : IService
    {
        const string FILENAME = "Models/SampleHouse4.ifc";
        public CoreService()
        {

        }

        public string GetIfcTypes()
        {
            StringBuilder builder = new StringBuilder("[\n");
            var obj = new Dictionary<string, int>();
            using (var model = IfcStore.Open(FILENAME))
            {
                var items = model.Instances;
                foreach (var item in items)
                {
                    var component = item.GetType().Name;
                    if (!obj.ContainsKey(component))
                    {
                        obj.Add(component, 1);
                    }
                    else
                    {
                        obj[component]++;
                    }
                }
                foreach (var pair in obj)
                {
                    builder.AppendLine("\t" + pair.Key + ": " + pair.Value);
                }
                builder.AppendLine("]");
                return builder.ToString();
            }
        }

        public string GetRooms()
        {
            StringBuilder roomList = new StringBuilder("{\n");
            const string filename = "Models/SampleHouse4.ifc";
            using (var model = IfcStore.Open(filename))
            {
                var items = model.Instances.OfType<IfcSpace>();
                foreach (var item in items)
                {
                    roomList.AppendLine("\t" + item.Name + ": " + item.NetFloorArea);
                }
                roomList.AppendLine("}");
                return roomList.ToString();
            }
        }
    }
}
