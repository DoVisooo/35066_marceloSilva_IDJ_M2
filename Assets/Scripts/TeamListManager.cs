using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamListManager : MonoBehaviour
{
    public int templateQuantityAllowed;
    public int templateQuantity;

    public GameObject teamInfoTemplate;
    public GameObject teamsListBackManagerContainer;

    public TeamProfile teamsManager;
    //public TeamProfileManager teamProfileManager;

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

    public Sprite EU;
    public Sprite NA;
    public Sprite CIS;
    public Sprite SA;
    public Sprite OCE;
    public Sprite ASIA;

    public string teamFilterString;

    void Start()
    {
        templateQuantity = 0;
    }

    void Update()
    {
        templateQuantityAllowed = TeamProfile.teamsList.Count - 1;

        if (templateQuantity < templateQuantityAllowed /*&& teamsManager.teamsList[0].name != "Free Agent"*/)
        {
            GenerateTeamInfoTemplate();
        }
    }

    void GenerateTeamInfoTemplate()
    {
        float y = 17990.02f;//402.0f;

        for (int i = 0; i < TeamProfile.teamsList.Count; i++)
        {
            if (GameObject.Find(TeamProfile.teamsList[i].teamName).GetComponent<TeamMembers>().teamReputation > 0)
            {
                GameObject template = Instantiate(teamInfoTemplate);
                template.transform.SetParent(teamsListBackManagerContainer.transform);
                //template.transform.parent = teamsListBackManagerContainer.transform;
                template.transform.localScale = new Vector3(1, 1, 1);
                template.transform.localPosition = new Vector3(0.0f, y, 0.0f);

                template.GetComponent<TeamInfoTemplate>().team.text = TeamProfile.teamsList[i].teamName;
                template.GetComponent<TeamInfoTemplate>().hQCountryFlag.GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(TeamProfile.teamsList[i].teamHQCountry.Trim('\"')).GetValue(this);
                template.GetComponent<TeamInfoTemplate>().hQCountry.text = TeamProfile.teamsList[i].teamHQCountry;

                if (TeamProfile.teamsList[i].teamName.Contains(" "))
                {
                    teamFilterString = TeamProfile.teamsList[i].teamName.Replace(' ', '_');
                }
                else if (TeamProfile.teamsList[i].teamName.Contains("."))
                {
                    teamFilterString = TeamProfile.teamsList[i].teamName.Replace('.', 'ç');
                }
                else if (!TeamProfile.teamsList[i].teamName.Contains(" ") && !TeamProfile.teamsList[i].teamName.Contains("."))
                {
                    teamFilterString = TeamProfile.teamsList[i].teamName;
                }

                template.GetComponent<TeamInfoTemplate>().teamLogo.GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(teamFilterString.Trim('\"')).GetValue(this);
                template.GetComponent<TeamInfoTemplate>().teamRegionFlag.GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(TeamProfile.teamsList[i].teamRegion.Trim('\"')).GetValue(this);
                template.GetComponent<TeamInfoTemplate>().teamRegion.text = TeamProfile.teamsList[i].teamRegion;
                template.GetComponent<TeamInfoTemplate>().tier.text = "Tier " + GameObject.Find(TeamProfile.teamsList[i].teamName).GetComponent<TeamMembers>().teamTier.ToString();
                template.GetComponent<TeamInfoTemplate>().ranking.text = "#" + GameObject.Find(TeamProfile.teamsList[i].teamName).GetComponent<TeamMembers>().teamRanking.ToString();
                template.GetComponent<TeamInfoTemplate>().reputationAbility.value = GameObject.Find(TeamProfile.teamsList[i].teamName).GetComponent<TeamMembers>().teamReputation;

                y -= 30.0f;
                templateQuantity += 1;
            }
        }
    }
}
