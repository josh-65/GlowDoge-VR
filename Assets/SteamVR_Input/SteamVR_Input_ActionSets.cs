//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Valve.VR
{
    using System;
    using UnityEngine;
    
    
    public partial class SteamVR_Actions
    {
        
        private static SteamVR_Input_ActionSet_Default p_Default;
        
        public static SteamVR_Input_ActionSet_Default Default
        {
            get
            {
                return SteamVR_Actions.p_Default.GetCopy<SteamVR_Input_ActionSet_Default>();
            }
        }
        
        private static void StartPreInitActionSets()
        {
            SteamVR_Actions.p_Default = ((SteamVR_Input_ActionSet_Default)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_Default>("/actions/Default")));
            Valve.VR.SteamVR_Input.actionSets = new Valve.VR.SteamVR_ActionSet[] {
                    SteamVR_Actions.Default};
        }
    }
}
