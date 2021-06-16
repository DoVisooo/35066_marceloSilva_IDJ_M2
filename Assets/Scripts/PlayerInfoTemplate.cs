using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoTemplate : MonoBehaviour
{
    public GameObject playerListTemplate;

    public static int templateID;
    public int id;

    public GameObject UIPlayerListBackManager;
    public GameObject playerProfileManager;
    public GameObject UIProfileBackManager;
    public GameObject UIProfileFrontManager;

    public Button playerProfileButton;
    public Button playerProfileTextButton;
    public Button countryProfileButton;
    public Button countryProfileTextButton;
    public Button teamProfileButton;
    public Button teamProfileTextButton;

    public Text playerName;
    public Text country;
    public Text team;
    public Text tierAndRegion;
    public Text mainRole;
    public Text secondaryRole;
    public Text value;
    public Text salary;
    public Text age;

    public Slider currentAbility;
    public Slider potentialAbility;

    public GameObject countryFlag;
    public GameObject teamLogo;

    public Image entryFraggerSkill;
    public Image supportSkill;
    public Image inGameLeaderSkill;
    public Image aWPerSkill;
    public Image lurkerSkill;

    public Image[] roleSkillsIcons;

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

    void Start()
    {
        templateID += 1;
        id = templateID - 1;
        UIPlayerListBackManager = GameObject.FindGameObjectWithTag("UIPlayerListBackManager");
        playerProfileManager = GameObject.FindGameObjectWithTag("PersonsManager");
        UIProfileBackManager = GameObject.FindGameObjectWithTag("UIProfileBackManager");
        UIProfileFrontManager = GameObject.FindGameObjectWithTag("UIProfileFrontManager");
    }

    void Update()
    {
        
    }

    public void LoadPlayerProfile()
    {
        UIPlayerListBackManager.SetActive(false);
        playerProfileManager.GetComponent<PlayerProfileManager>().playerID = id;
        UIProfileBackManager.SetActive(true);
        UIProfileFrontManager.SetActive(true);
    }
}
