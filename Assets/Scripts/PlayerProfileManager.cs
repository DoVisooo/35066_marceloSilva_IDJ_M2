using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlayerProfileManager : MonoBehaviour
{
    public Button previousPlayerButton;
    public Button nextPlayerButton;

    public GameObject headerTeamLogo;
    public Text firstNameNicknameLastName;
    public Text roleAndTeam;

    public GameObject profilePicture;
    public GameObject countryFlag;

    public Text nickname;
    public Text country;
    public Text name;
    public Text age;
    public Text gender;
    public GameObject genderImage;

    public Text contractedTo;
    public Text value;
    public Text salary;
    public Text contractEndingDate;
    public GameObject teamLogo;

    public Text reflexes;
    public Text precision;
    public Text accuracy;
    public Text oneOnOnes;
    public Text communication;

    public Text bravery;
    public Text composure;
    public Text decisionMaking;
    public Text determination;
    public Text leadership;
    public Text gameKnowledge;
    public Text gameSense;
    public Text positioning;
    public Text teamwork;
    public Text workRate;

    public Text rifles;
    public Text snipers;
    public Text grenades;

    public int playerID;

    public Text[] stats;

    List<Player> playerList;
    public Player player;

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

    public Sprite maleImg;
    public Sprite femaleImg;

    public GameObject currentAbilitySlider;
    public GameObject potentialAbilitySlider;
    public GameObject entryFraggerAbilitySlider;
    public GameObject supportAbilitySlider;
    public GameObject inGameLeaderAbilitySlider;
    public GameObject aWPerAbilitySlider;
    public GameObject lurkerAbilitySlider;

    public Button[] roleSkillsButtons;

    public string playerTeamFilterString;

    private void Start()
    {
        SetMaxAbility();
    }

    public void Update()
    {
        playerList = GetComponent<PersonProfile>().playerList;

        if (playerList.Count > 0)
        {
            player = GetComponent<PersonProfile>().playerList[playerID].GetComponent<Player>();
            if (player != null)
            {
                if (player.team.Contains(" "))
                {
                    playerTeamFilterString = player.team.Replace(' ', '_');
                }
                else if (player.team.Contains("."))
                {
                    playerTeamFilterString = player.team.Replace('.', 'ç');
                }
                else if (!player.team.Contains(" ") && !player.team.Contains("."))
                {
                    playerTeamFilterString = player.team;
                }

                headerTeamLogo.GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(playerTeamFilterString.Trim('\"')).GetValue(this);
                teamLogo.GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(playerTeamFilterString.Trim('\"')).GetValue(this);
                firstNameNicknameLastName.text = player.firstName + " ''" + player.nickname + "'' " + player.lastName;
                roleAndTeam.text = player.inGameMainRole + " - " + player.team;
                nickname.text = player.nickname;
                country.text = player.country;
                countryFlag.GetComponent<Image>().sprite = (Sprite)this.GetType().GetField(player.country.Trim('\"')).GetValue(this);
                name.text = player.firstName + " " + player.lastName;
                age.text = player.age + " years old " + "(" + player.birthdayDay + "/" + player.birthdayMonth + "/" + player.birthdayYear + ")";
                gender.text = player.gender;

                if (player.team != "Free Agent")
                {
                    contractedTo.text = "Contracted to " + player.team;
                    salary.text = "€" + player.salary + "K p/m until";
                    contractEndingDate.text = "31/12/" + player.contractEndYear;
                }
                else
                {
                    contractedTo.text = player.team;
                    salary.text = "";
                    contractEndingDate.text = "";
                }

                value.text = "Valued at " + "€" + player.marketValue + "K";
                reflexes.text = player.reflexes.ToString();
                precision.text = player.precision.ToString();
                accuracy.text = player.accuracy.ToString();
                oneOnOnes.text = player.oneOnOnes.ToString();
                communication.text = player.communication.ToString();
                bravery.text = player.bravery.ToString();
                composure.text = player.composure.ToString();
                decisionMaking.text = player.decisionMaking.ToString();
                determination.text = player.determination.ToString();
                leadership.text = player.leadership.ToString();
                gameKnowledge.text = player.gameKnowledge.ToString();
                gameSense.text = player.gameSense.ToString();
                positioning.text = player.positioning.ToString();
                teamwork.text = player.teamwork.ToString();
                workRate.text = player.workRate.ToString();
                rifles.text = player.rifles.ToString();
                snipers.text = player.snipers.ToString();
                grenades.text = player.grenades.ToString();

                currentAbilitySlider.GetComponent<AbilitySlider>().SetAbility(player.currentAbility);
                potentialAbilitySlider.GetComponent<AbilitySlider>().SetAbility(player.potentialAbility);
                entryFraggerAbilitySlider.GetComponent<AbilitySlider>().SetAbility(player.skillAsEntryFragger);
                supportAbilitySlider.GetComponent<AbilitySlider>().SetAbility(player.skillAsSupport);
                inGameLeaderAbilitySlider.GetComponent<AbilitySlider>().SetAbility(player.skillAsInGameLeader);
                aWPerAbilitySlider.GetComponent<AbilitySlider>().SetAbility(player.skillAsAWPer);
                lurkerAbilitySlider.GetComponent<AbilitySlider>().SetAbility(player.skillAsLurker);
                }
            }

        int[] roleSkills = { player.skillAsEntryFragger, player.skillAsSupport, player.skillAsInGameLeader, player.skillAsAWPer, player.skillAsLurker };
        for (int j = 0; j < roleSkills.Length; j++)
        {
            if (roleSkills[j] >= 40 && roleSkills[j] < 50)
            {
                roleSkillsButtons[j].GetComponent<Image>().color = new Color(0.8f, 0.2f, 0.0f);
            }
            else if (roleSkills[j] >= 50 && roleSkills[j] < 60)
            {
                roleSkillsButtons[j].GetComponent<Image>().color = new Color(0.7f, 0.3f, 0.0f);
            }
            else if (roleSkills[j] >= 60 && roleSkills[j] < 70)
            {
                roleSkillsButtons[j].GetComponent<Image>().color = new Color(0.8f, 0.55f, 0.0f);
            }
            else if (roleSkills[j] >= 70 && roleSkills[j] < 80)
            {
                roleSkillsButtons[j].GetComponent<Image>().color = new Color(0.6f, 0.7f, 0.0f);
            }
            else if (roleSkills[j] >= 80 && roleSkills[j] < 90)
            {
                roleSkillsButtons[j].GetComponent<Image>().color = new Color(0.0f, 0.7f, 0.08f);
            }
            else if (roleSkills[j] >= 90 && roleSkills[j] < 100)
            {
                roleSkillsButtons[j].GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f);
            }

            for (int i = 0; i < stats.Length; i++)
            {
                if (int.Parse(stats[i].text) >= 40 && int.Parse(stats[i].text) < 50)
                {
                    stats[i].GetComponent<Text>().color = new Color(0.8f, 0.2f, 0.0f);
                }
                else if (int.Parse(stats[i].text) >= 50 && int.Parse(stats[i].text) < 60)
                {
                    stats[i].GetComponent<Text>().color = new Color(0.7f, 0.3f, 0.0f);
                }
                else if (int.Parse(stats[i].text) >= 60 && int.Parse(stats[i].text) < 70)
                {
                    stats[i].GetComponent<Text>().color = new Color(0.8f, 0.55f, 0.0f);
                }
                else if (int.Parse(stats[i].text) >= 70 && int.Parse(stats[i].text) < 80)
                {
                    stats[i].GetComponent<Text>().color = new Color(0.6f, 0.7f, 0.0f);
                }
                else if (int.Parse(stats[i].text) >= 80 && int.Parse(stats[i].text) < 90)
                {
                    stats[i].GetComponent<Text>().color = new Color(0.0f, 0.7f, 0.08f);
                }
                else if (int.Parse(stats[i].text) >= 90 && int.Parse(stats[i].text) < 100)
                {
                    stats[i].GetComponent<Text>().color = new Color(0.0f, 1.0f, 0.0f);
                }
            }

        PlayerIDLimits();
        GenderImage();
    }
}

    public void NextPlayer()
    {
        playerID++;
    }

    public void PreviousPlayer()
    {
        playerID--;
    }

    public void PlayerIDLimits()
    {
        if (playerID <= 0)
        {
            playerID = 0;
            previousPlayerButton.GetComponent<Button>().interactable = false;
        }
        else if (playerID >= playerList.Count-1)
        {
            playerID = playerList.Count-1;
            nextPlayerButton.GetComponent<Button>().interactable = false;
        }
        else if (playerID > 0 && playerID < playerList.Count - 1)
        {
            nextPlayerButton.GetComponent<Button>().interactable = true;
            previousPlayerButton.GetComponent<Button>().interactable = true;
        }
        else if (playerID > 0 && playerID < playerList.Count-1)
        {
            nextPlayerButton.GetComponent<Button>().interactable = true;
            previousPlayerButton.GetComponent<Button>().interactable = true;
        }
    }

    public void GenderImage()
    {
        if (gender.text == "Male")
        {
            genderImage.GetComponent<Image>().sprite = maleImg;
        }
        else if (gender.text == "Female")
        {
            genderImage.GetComponent<Image>().sprite = femaleImg;
        }
    }

    public void SetMaxAbility()
    {
        currentAbilitySlider.GetComponent<AbilitySlider>().SetMaxAbility(99);
        potentialAbilitySlider.GetComponent<AbilitySlider>().SetMaxAbility(99);
        entryFraggerAbilitySlider.GetComponent<AbilitySlider>().SetMaxAbility(99);
        supportAbilitySlider.GetComponent<AbilitySlider>().SetMaxAbility(99);
        inGameLeaderAbilitySlider.GetComponent<AbilitySlider>().SetMaxAbility(99);
        aWPerAbilitySlider.GetComponent<AbilitySlider>().SetMaxAbility(99);
        lurkerAbilitySlider.GetComponent<AbilitySlider>().SetMaxAbility(99);
    }
}
