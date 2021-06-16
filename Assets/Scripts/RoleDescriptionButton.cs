using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleDescriptionButton : MonoBehaviour
{
    public Text roleDescriptionName;
    public Text roleDescription;
    public string role;
    public string text;

    public void SetDescription()
    {
        roleDescriptionName.text = role;
        roleDescription.text = text;
    }
}
