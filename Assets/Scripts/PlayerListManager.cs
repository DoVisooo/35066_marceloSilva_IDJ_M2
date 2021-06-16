using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListManager : MonoBehaviour
{
    public int templateQuantityAllowed;
    public int templateQuantity;

    public GameObject playerInfoTemplate;
    public GameObject playerListBackManagerContainer;

    public PersonProfile personsManager;
    public PlayerProfileManager playerProfileManager;

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

    public string playerTeamFilterString;

    void Start()
    {
        templateQuantity = 0;
        //StartCoroutine(CoUpdate());
    }

    void Update()
    {
        templateQuantityAllowed = personsManager.playerList.Count - 1;

        if (templateQuantity < templateQuantityAllowed && personsManager.playerList[0].team != "Free Agent" && TeamProfile.teamsList.Count >= 10)
        {
            GeneratePlayerInfoTemplate();
        }
    }

    void GeneratePlayerInfoTemplate()
    {
        float y = 18006.03f;//402.0f;

        for (int i = 0; i < personsManager.playerList.Count; i++)
        {
            GameObject template = Instantiate(playerInfoTemplate);
            template.transform.SetParent(playerListBackManagerContainer.transform);
            //template.transform.parent = playerListBackManagerContainer.transform;
            template.transform.localScale = new Vector3(1, 1, 1);
            template.transform.localPosition = new Vector3(-959.9999f, y, 0.0f);

            template.GetComponent<PlayerInfoTemplate>().playerName.text = personsManager.playerList[i].name;
            template.GetComponent<PlayerInfoTemplate>().countryFlag.GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(personsManager.playerList[i].country.Trim('\"')).GetValue(this);
            template.GetComponent<PlayerInfoTemplate>().country.text = personsManager.playerList[i].country;
            template.GetComponent<PlayerInfoTemplate>().team.text = personsManager.playerList[i].team;

            if (personsManager.playerList[i].team.Contains(" "))
            {
                playerTeamFilterString = personsManager.playerList[i].team.Replace(' ', '_');
            }
            else if (personsManager.playerList[i].team.Contains("."))
            {
                playerTeamFilterString = personsManager.playerList[i].team.Replace('.', 'ç');
            }
            else if (!personsManager.playerList[i].team.Contains(" ") && !personsManager.playerList[i].team.Contains("."))
            {
                playerTeamFilterString = personsManager.playerList[i].team;
            }

            template.GetComponent<PlayerInfoTemplate>().teamLogo.GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(playerTeamFilterString.Trim('\"')).GetValue(this);

            if (template.GetComponent<PlayerInfoTemplate>().team.text != "Free Agent")
            {
                template.GetComponent<PlayerInfoTemplate>().tierAndRegion.text = "Tier " + GameObject.Find(personsManager.playerList[i].team).GetComponent<TeamMembers>().teamTier.ToString() + " - " + GameObject.Find(personsManager.playerList[i].team).GetComponent<TeamMembers>().teamRegion;
            } 
            else
            {
                template.GetComponent<PlayerInfoTemplate>().tierAndRegion.text = "N/A";
            }

            template.GetComponent<PlayerInfoTemplate>().mainRole.text = personsManager.playerList[i].inGameMainRole;
            template.GetComponent<PlayerInfoTemplate>().secondaryRole.text = personsManager.playerList[i].inGameSecondaryRole;
            template.GetComponent<PlayerInfoTemplate>().value.text = "€" + personsManager.playerList[i].marketValue + "K";
            template.GetComponent<PlayerInfoTemplate>().salary.text = "€" + personsManager.playerList[i].salary + "K p/m";
            template.GetComponent<PlayerInfoTemplate>().age.text = personsManager.playerList[i].age + " years old";
            template.GetComponent<PlayerInfoTemplate>().currentAbility.value = personsManager.playerList[i].currentAbility;
            template.GetComponent<PlayerInfoTemplate>().potentialAbility.value = personsManager.playerList[i].potentialAbility;

            int[] roleSkills = { personsManager.playerList[i].skillAsEntryFragger, personsManager.playerList[i].skillAsSupport, personsManager.playerList[i].skillAsInGameLeader, personsManager.playerList[i].skillAsAWPer, personsManager.playerList[i].skillAsLurker };
            for (int j = 0; j < roleSkills.Length; j++)
            {
                if (roleSkills[j] >= 40 && roleSkills[j] < 50)
                {
                    template.GetComponent<PlayerInfoTemplate>().roleSkillsIcons[j].color = new Color(0.8f, 0.2f, 0.0f);
                }
                else if (roleSkills[j] >= 50 && roleSkills[j] < 60)
                {
                    template.GetComponent<PlayerInfoTemplate>().roleSkillsIcons[j].color = new Color(0.7f, 0.3f, 0.0f);
                }
                else if (roleSkills[j] >= 60 && roleSkills[j] < 70)
                {
                    template.GetComponent<PlayerInfoTemplate>().roleSkillsIcons[j].color = new Color(0.8f, 0.55f, 0.0f);
                }
                else if (roleSkills[j] >= 70 && roleSkills[j] < 80)
                {
                    template.GetComponent<PlayerInfoTemplate>().roleSkillsIcons[j].color = new Color(0.6f, 0.7f, 0.0f);
                }
                else if (roleSkills[j] >= 80 && roleSkills[j] < 90)
                {
                    template.GetComponent<PlayerInfoTemplate>().roleSkillsIcons[j].color = new Color(0.0f, 0.7f, 0.08f);
                }
                else if (roleSkills[j] >= 90 && roleSkills[j] < 100)
                {
                    template.GetComponent<PlayerInfoTemplate>().roleSkillsIcons[j].color = new Color(0.0f, 1.0f, 0.0f);
                }
            }

            y -= 60.0f;
            templateQuantity += 1;
        }
    }
}
