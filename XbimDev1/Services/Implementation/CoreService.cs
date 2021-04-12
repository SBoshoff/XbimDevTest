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

        /// <summary>
        /// Returns a serialized JSON object consisting all of the IFC types in the model, and the number of times they appeared
        /// </summary>
        /// <returns>string</returns>
        public string GetIfcTypes()
        {
            StringBuilder builder = new StringBuilder("{\n");
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
                builder.AppendLine("}");
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a string listing the rooms in the model as well as their net floor areas rounded to 2 decimal places
        /// </summary>
        /// <returns>string</returns>
        public string GetRooms()
        {
            StringBuilder roomList = new StringBuilder("");
            using (var model = IfcStore.Open(FILENAME))
            {
                var items = model.Instances.OfType<IfcSpace>();
                foreach (var item in items)
                {
                    roomList.AppendLine(item.Name + ": " + Math.Round(item.NetFloorArea.Value, 2));
                }
                return roomList.ToString();
            }
        }
    }
}
