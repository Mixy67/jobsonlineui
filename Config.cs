using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsOnlineUI
{
    public class Config : IRocketPluginConfiguration
    {
        public string PoliceID, DoctorID, TaxiID, PoliceCountColor, DoctorCountColor, TaxiCountColor;
        public ushort EffectID;
        public void LoadDefaults()
        {
            PoliceID = "polis";
            DoctorID = "doktor";
            TaxiID = "taksici";
            PoliceCountColor = "#1e90ff";
            DoctorCountColor = "#cd5555";
            TaxiCountColor = "#ffde66";
            EffectID = 12320;
        }
    }
}
