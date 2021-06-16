using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeamInfoTemplate : MonoBehaviour
{
    public static int templateID;
    public int id;

    public GameObject UITeamsListBackManager;
    public GameObject teamProfile;
    public GameObject teamProfileManager;

    public Text team;
    public Text hQCountry;
    public Text teamRegion;
    public Text tier;
    public Text ranking;

    public Slider reputationAbility;

    public GameObject hQCountryFlag;
    public GameObject teamLogo;
    public GameObject teamRegionFlag;

    public Sprite Astralis;
    public Sprite Natus_Vincere;
    public Sprite G2_Esports;
    public Sprite Team_Liquid;
    public Sprite FaZe_Clan;
    public Sprite Fnatic;
    public Sprite Ninjas_in_Pyjamas;
    public Sprite mousesports;
    public Sprite Team_Vitality;
    public Sprite Virtusçpro;
    public Sprite Gambit_Esports;
    public Sprite Free_Agent;

    public Sprite Portugal;
    public Sprite Spain;
    public Sprite England;
    public Sprite France;
    public Sprite Italy;
    public Sprite Germany;
    public Sprite Netherlands;
    public Sprite Denmark;
    public Sprite Sweden;
    public Sprite Norway;
    public Sprite Ukraine;
    public Sprite USA;
    public Sprite Russia;

    public Sprite EU;
    public Sprite NA;
    public Sprite CIS;
    public Sprite SA;
    public Sprite OCE;
    public Sprite ASIA;

    void Start()
    {
        templateID += 1;
        id = templateID - 1;
        UITeamsListBackManager = GameObject.FindGameObjectWithTag("UITeamsListBackManager");
        teamProfileManager = GameObject.Find("TeamsManager");
    }

    // Update is called once per frame
    void Update()
    {
        teamProfile = teamProfileManager.GetComponent<TeamProfileManager>().teamProfile;
    }

    public void LoadTeamProfile()
    {
        UITeamsListBackManager.SetActive(false);
        teamProfileManager.GetComponent<TeamProfileManager>().teamID = id - 1;
        teamProfile.SetActive(true);
    }
}
