using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using System;
using System.Reflection;

public class TeamsData : MonoBehaviour
{
    public enum Teams
    {
        [Description("Astralis")]
        Astralis,
        [Description("Natus Vincere")]
        Natus_Vincere,
        [Description("G2 Esports")]
        G2_Esports,
        [Description("Team Liquid")]
        Team_Liquid,
        [Description("FaZe Clan")]
        FaZe_Clan,
        [Description("Fnatic")]
        Fnatic,
        [Description("Ninjas in Pyjamas")]
        Ninjas_in_Pyjamas,
        [Description("mousesports")]
        mousesports,
        [Description("Team Vitality")]
        Team_Vitality,
        [Description("Virtus.pro")]
        Virtus_pro,
        [Description("Gambit Esports")]
        Gambit_Esports,
        [Description("Free Agent")]
        Free_Agent
    }
    public static string GetDescriptionFromEnum(Enum value)
    {
        FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes == null && attributes.Length == 0 ? value.ToString() : attributes[0].Description;
    }
}
