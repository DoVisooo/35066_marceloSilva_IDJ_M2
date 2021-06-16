using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using System;
using System.Reflection;

public class InGameRolesData : MonoBehaviour
{
    public enum InGameRoles
    {
        [Description("Entry Fragger")]
        Entry_Fragger,
        [Description("Support")]
        Support,
        [Description("In-Game Leader")]
        InGame_Leader,
        [Description("AWPer")]
        AWPer,
        [Description("Lurker")]
        Lurker,
    }

    public static string GetDescriptionFromEnum(Enum value)
    {
        FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes == null && attributes.Length == 0 ? value.ToString() : attributes[0].Description;
    }
}
