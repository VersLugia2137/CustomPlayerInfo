using System.Collections.Generic;
using System.ComponentModel;
using PlayerRoles;

namespace CustomPlayerInfo
{
    public sealed class Config
    {
        public bool EnablePlugin { get; set; } = true;
        
        public bool DisablePowerStatusInfo { get; set; } = true;
        
        public bool DisableUnitsInfo { get; set; } = false;
        
        [Description("{nick} {unit}")]
        public Dictionary<RoleTypeId, string> CustomInfo { get; set; }= new Dictionary<RoleTypeId, string>
        {
            { RoleTypeId.ClassD, "<color=#FF9966>{nick}\nPrisoner</color>" },
            { RoleTypeId.Scp049, "<color=#C50000>{nick}</color>\n<color=#228B22>Doctor</color>" },
            { RoleTypeId.Scp173, "<color=#960018>{nick}\nMatthew</color>" }
        };
    }
}