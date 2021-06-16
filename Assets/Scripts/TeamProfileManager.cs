using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamProfileManager : MonoBehaviour
{
    public Button previousTeamButton;
    public Button nextTeamButton;
    public GameObject headerTeamLogo;
    public Text headerTeamName;
    public Text headerTierRegion;

    public GameObject teamLogo;
    public GameObject countryFlag;
    public Text country;
    public Text foundationDate;
    public GameObject regionFlag;
    public Text region;
    public Text tier;
    public Text ranking;

    public Text entryFragger;
    public Text support;
    public Text inGameLeader;
    public Text aWPer;
    public Text lurker;
    public GameObject cEOProfileImage;
    public Text cEOName;
    public Text cEOCountry;
    public GameObject coachProfileImage;
    public Text coachName;
    public Text coachCountry;
    public GameObject captainProfileImage;
    public Text captainName;
    public Text captainCountry;
    public GameObject starPlayerProfileImage;
    public Text starPlayerName;
    public Text starPlayerCountry;
    public GameObject hideWonderkidImage;
    public GameObject wonderkidProfileImage;
    public Text wonderkidName;
    public Text wonderkidCountry;
    public Slider teamReputationSlider;

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

    public Image entryFraggerIcon;
    public Image supportIcon;
    public Image inGameLeaderIcon;
    public Image aWPerIcon;
    public Image lurkerIcon;

    public List<TeamProfile> teamsList;
    public TeamProfile team;
    public string teamFilterString;

    public int teamID;
    public GameObject teamProfile;

    PersonProfile personProfile;

    void Start()
    {
        personProfile = GameObject.FindGameObjectWithTag("PersonsManager").GetComponent<PersonProfile>();
    }

    void Update()
    {
        teamsList = TeamProfile.teamsList;
        for (int i = 0; i < teamsList.Count - 1; i++)
        {
            if (GameObject.Find(TeamProfile.teamsList[i].teamName).GetComponent<TeamMembers>().fullTeam == true)
            {
                if (teamsList.Count >= 10 && personProfile.personsList.Count > 599)
                {
                    team = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamProfile>();

                    if (team != null)
                    {
                        if (team.teamName.Contains(" "))
                        {
                            teamFilterString = team.teamName.Replace(' ', '_');
                        }
                        else if (team.teamName.Contains("."))
                        {
                            teamFilterString = team.teamName.Replace('.', 'ç');
                        }
                        else if (!team.teamName.Contains(" ") && !team.teamName.Contains("."))
                        {
                            teamFilterString = team.teamName;
                        }

                        headerTeamLogo.GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(teamFilterString.Trim('\"')).GetValue(this);
                        headerTeamName.text = team.teamName;
                        headerTierRegion.text = "Tier " + team.teamTier + " - " + team.teamRegion;
                        teamLogo.GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(teamFilterString.Trim('\"')).GetValue(this);
                        countryFlag.GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(team.teamHQCountry.Trim('\"')).GetValue(this);
                        country.text = team.teamHQCountry;
                        foundationDate.text = team.foundationDate.ToString();
                        regionFlag.GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(team.teamRegion.Trim('\"')).GetValue(this);
                        region.text = team.teamRegion;
                        tier.text = team.teamTier.ToString();
                        ranking.text = "#" + GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().teamRanking;
                        entryFragger.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().entryFragger.name;
                        support.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().support.name;
                        inGameLeader.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().inGameLeader.name;
                        aWPer.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().aWPer.name;
                        lurker.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().lurker.name;
                        cEOName.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().CEO;
                        cEOCountry.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().CEOCountry;
                        coachName.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().headCoach;
                        coachCountry.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().headCoachCountry;
                        captainName.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().captain.name;
                        captainCountry.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().captain.country;
                        starPlayerName.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().starPlayer.name;
                        starPlayerCountry.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().starPlayer.country;

                        if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().entryFragger.skillAsEntryFragger >= 40 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().entryFragger.skillAsEntryFragger < 50)
                        {
                            entryFraggerIcon.color = new Color(0.8f, 0.2f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().entryFragger.skillAsEntryFragger >= 50 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().entryFragger.skillAsEntryFragger < 60)
                        {
                            entryFraggerIcon.color = new Color(0.7f, 0.3f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().entryFragger.skillAsEntryFragger >= 60 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().entryFragger.skillAsEntryFragger < 70)
                        {
                            entryFraggerIcon.color = new Color(0.8f, 0.55f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().entryFragger.skillAsEntryFragger >= 70 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().entryFragger.skillAsEntryFragger < 80)
                        {
                            entryFraggerIcon.color = new Color(0.6f, 0.7f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().entryFragger.skillAsEntryFragger >= 80 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().entryFragger.skillAsEntryFragger < 90)
                        {
                            entryFraggerIcon.color = new Color(0.0f, 0.7f, 0.08f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().entryFragger.skillAsEntryFragger >= 90 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().entryFragger.skillAsEntryFragger < 100)
                        {
                            entryFraggerIcon.color = new Color(0.0f, 1.0f, 0.0f);
                        }

                        if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().support.skillAsSupport >= 40 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().support.skillAsSupport < 50)
                        {
                            supportIcon.color = new Color(0.8f, 0.2f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().support.skillAsSupport >= 50 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().support.skillAsSupport < 60)
                        {
                            supportIcon.color = new Color(0.7f, 0.3f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().support.skillAsSupport >= 60 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().support.skillAsSupport < 70)
                        {
                            supportIcon.color = new Color(0.8f, 0.55f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().support.skillAsSupport >= 70 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().support.skillAsSupport < 80)
                        {
                            supportIcon.color = new Color(0.6f, 0.7f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().support.skillAsSupport >= 80 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().support.skillAsSupport < 90)
                        {
                            supportIcon.color = new Color(0.0f, 0.7f, 0.08f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().support.skillAsSupport >= 90 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().support.skillAsSupport < 100)
                        {
                            supportIcon.color = new Color(0.0f, 1.0f, 0.0f);
                        }

                        if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().inGameLeader.skillAsInGameLeader >= 40 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().inGameLeader.skillAsInGameLeader < 50)
                        {
                            inGameLeaderIcon.color = new Color(0.8f, 0.2f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().inGameLeader.skillAsInGameLeader >= 50 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().inGameLeader.skillAsInGameLeader < 60)
                        {
                            inGameLeaderIcon.color = new Color(0.7f, 0.3f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().inGameLeader.skillAsInGameLeader >= 60 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().inGameLeader.skillAsInGameLeader < 70)
                        {
                            inGameLeaderIcon.color = new Color(0.8f, 0.55f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().inGameLeader.skillAsInGameLeader >= 70 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().inGameLeader.skillAsInGameLeader < 80)
                        {
                            inGameLeaderIcon.color = new Color(0.6f, 0.7f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().inGameLeader.skillAsInGameLeader >= 80 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().inGameLeader.skillAsInGameLeader < 90)
                        {
                            inGameLeaderIcon.color = new Color(0.0f, 0.7f, 0.08f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().inGameLeader.skillAsInGameLeader >= 90 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().inGameLeader.skillAsInGameLeader < 100)
                        {
                            inGameLeaderIcon.color = new Color(0.0f, 1.0f, 0.0f);
                        }

                        if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().aWPer.skillAsAWPer >= 40 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().aWPer.skillAsAWPer < 50)
                        {
                            aWPerIcon.color = new Color(0.8f, 0.2f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().aWPer.skillAsAWPer >= 50 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().aWPer.skillAsAWPer < 60)
                        {
                            aWPerIcon.color = new Color(0.7f, 0.3f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().aWPer.skillAsAWPer >= 60 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().aWPer.skillAsAWPer < 70)
                        {
                            aWPerIcon.color = new Color(0.8f, 0.55f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().aWPer.skillAsAWPer >= 70 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().aWPer.skillAsAWPer < 80)
                        {
                            aWPerIcon.color = new Color(0.6f, 0.7f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().aWPer.skillAsAWPer >= 80 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().aWPer.skillAsAWPer < 90)
                        {
                            aWPerIcon.color = new Color(0.0f, 0.7f, 0.08f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().aWPer.skillAsAWPer >= 90 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().aWPer.skillAsAWPer < 100)
                        {
                            aWPerIcon.color = new Color(0.0f, 1.0f, 0.0f);
                        }

                        if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().lurker.skillAsLurker >= 40 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().lurker.skillAsLurker < 50)
                        {
                            lurkerIcon.color = new Color(0.8f, 0.2f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().lurker.skillAsLurker >= 50 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().lurker.skillAsLurker < 60)
                        {
                            lurkerIcon.color = new Color(0.7f, 0.3f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().lurker.skillAsLurker >= 60 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().lurker.skillAsLurker < 70)
                        {
                            lurkerIcon.color = new Color(0.8f, 0.55f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().lurker.skillAsLurker >= 70 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().lurker.skillAsLurker < 80)
                        {
                            lurkerIcon.color = new Color(0.6f, 0.7f, 0.0f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().lurker.skillAsLurker >= 80 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().lurker.skillAsLurker < 90)
                        {
                            lurkerIcon.color = new Color(0.0f, 0.7f, 0.08f);
                        }
                        else if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().lurker.skillAsLurker >= 90 && GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().lurker.skillAsLurker < 100)
                        {
                            lurkerIcon.color = new Color(0.0f, 1.0f, 0.0f);
                        }


                        if (GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().wonderkid != null)
                        {
                            hideWonderkidImage.SetActive(false);
                            wonderkidProfileImage.SetActive(true);
                            wonderkidName.gameObject.SetActive(true);
                            wonderkidCountry.gameObject.SetActive(true);
                            wonderkidName.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().wonderkid.name;
                            wonderkidCountry.text = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().wonderkid.country;
                        }
                        else
                        {
                            hideWonderkidImage.SetActive(true);
                            wonderkidProfileImage.SetActive(false);
                            wonderkidName.text = "";
                            wonderkidCountry.text = "";
                        }

                        teamReputationSlider.value = GameObject.Find(TeamProfile.teamsList[teamID].teamName).GetComponent<TeamMembers>().teamReputation;
                    }
                }
            }
        }

        TeamIDLimits();
    }

    public void NextTeam()
    {
        teamID++;
    }

    public void PreviousTeam()
    {
        teamID--;
    }

    public void TeamIDLimits()
    {
        if (teamID <= 0)
        {
            teamID = 0;
            previousTeamButton.GetComponent<Button>().interactable = false;
        }
        else if (teamID >= teamsList.Count - 1)
        {
            teamID = teamsList.Count - 1;
            nextTeamButton.GetComponent<Button>().interactable = false;
        }
        else if (teamID > 0 && teamID < teamsList.Count - 1)
        {
            nextTeamButton.GetComponent<Button>().interactable = true;
            previousTeamButton.GetComponent<Button>().interactable = true;
        }
    }
}
