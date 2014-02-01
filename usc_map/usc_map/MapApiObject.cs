using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace usc_map
{
    [DataContract]
    public class MapApiObject
    {
       public int location_id;
       public string map_name;
       public string building_code;
       public double lat;
       public double lng;


    }

}
