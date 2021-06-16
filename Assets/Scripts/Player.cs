using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PersonProfile
{
    public int contractEndDay;
    public int contractEndMonth;
    public int contractEndYear;
    public float marketValue;
    public float salary;
    public int currentAbility;
    public int potentialAbility;
    public string inGameMainRole;
    public string inGameSecondaryRole;

    private int[] skillsPerRole;

    public int reflexes;
    public int precision;
    public int accuracy;
    public int oneOnOnes;
    public int communication;

    public int rifles;
    public int snipers;
    public int grenades;

    public int bravery;
    public int composure;
    public int concentration;
    public int decisionMaking;
    public int determination;
    public int leadership;
    public int gameKnowledge;
    public int gameSense;
    public int positioning;
    public int teamwork;
    public int workRate;

    public int skillAsEntryFragger;
    public int skillAsSupport;
    public int skillAsInGameLeader;
    public int skillAsAWPer;
    public int skillAsLurker;

    private void Start()
    {
        contractEndDay = 31;
        contractEndMonth = 12;
        contractEndYear = Random.Range(Mathf.RoundToInt(System.DateTime.Now.Year), Mathf.RoundToInt(System.DateTime.Now.Year) + 6);

        reflexes = Random.Range(40, 100);
        precision = Random.Range(40, 100);
        accuracy = Random.Range(40, 100);
        oneOnOnes = Random.Range(40, 100);
        communication = Random.Range(40, 100);

        rifles = Random.Range(40, 100);
        snipers = Random.Range(40, 100);
        grenades = Random.Range(40, 100);

        bravery = Random.Range(40, 100);
        composure = Random.Range(40, 100);
        concentration = Random.Range(40, 100);
        decisionMaking = Random.Range(40, 100);
        determination = Random.Range(40, 100);
        leadership = Random.Range(40, 100);
        gameKnowledge = Random.Range(40, 100);
        gameSense = Random.Range(40, 100);
        positioning = Random.Range(40, 100);
        teamwork = Random.Range(40, 100);
        workRate = Random.Range(40, 100);

        currentAbility = (reflexes + precision + accuracy + oneOnOnes + communication + rifles + snipers + grenades + bravery + composure + concentration + decisionMaking + determination + leadership + gameKnowledge + gameSense + positioning + teamwork + workRate) / 19;
        potentialAbility = Random.Range(currentAbility, currentAbility + (100 - currentAbility));

        salary = currentAbility * 0.85f;
    }

    private void Update()
    {
        GetPlayerInGameRoles();

        marketValue = currentAbility * 3.5f;

        currentAbility = (reflexes + precision + accuracy + oneOnOnes + communication + rifles + snipers + grenades + bravery + composure + concentration + decisionMaking + determination + leadership + gameKnowledge + gameSense + positioning + teamwork + workRate) / 19;
        if (currentAbility > potentialAbility)
        {
            potentialAbility = currentAbility;
        }
    }

    public void GetPlayerInGameRoles()
    {
        skillAsEntryFragger = (reflexes + precision + accuracy + oneOnOnes + (rifles + (rifles / 2)) + bravery + determination + gameSense + (communication / 2)) / 8;
        skillAsSupport = (communication + (grenades + (grenades / 2)) + composure + concentration + gameKnowledge + teamwork + workRate + (positioning / 2)) / 8;
        skillAsInGameLeader = (communication + composure + concentration + decisionMaking + determination + (leadership + (leadership / 2)) + gameKnowledge + (teamwork / 2)) / 8;
        skillAsAWPer = (reflexes + precision + accuracy + oneOnOnes + (snipers + (snipers / 2)) + concentration + positioning + (composure / 2)) / 8;
        skillAsLurker = (communication + bravery + concentration + decisionMaking + gameKnowledge + gameSense + (positioning + (positioning / 2)) + (composure / 2)) / 8;

        skillsPerRole = new int[] { skillAsEntryFragger, skillAsSupport, skillAsInGameLeader, skillAsAWPer, skillAsLurker };
        int temp;

        for (int i = 0; i <= skillsPerRole.Length - 2; i++)
        {
            for (int j = 0; j <= skillsPerRole.Length - 2; j++)
            {
                if (skillsPerRole[j] < skillsPerRole[j + 1])
                {
                    temp = skillsPerRole[j + 1];
                    skillsPerRole[j + 1] = skillsPerRole[j];
                    skillsPerRole[j] = temp;
                }
            }
        }

        if (skillsPerRole[0] == skillAsEntryFragger)
        {
            inGameMainRole = InGameRolesData.GetDescriptionFromEnum((InGameRolesData.InGameRoles)0);
        }
        else if (skillsPerRole[0] == skillAsSupport)
        {
            inGameMainRole = InGameRolesData.GetDescriptionFromEnum((InGameRolesData.InGameRoles)1);
        }
        else if (skillsPerRole[0] == skillAsInGameLeader)
        {
            inGameMainRole = InGameRolesData.GetDescriptionFromEnum((InGameRolesData.InGameRoles)2);
        }
        else if (skillsPerRole[0] == skillAsAWPer)
        {
            inGameMainRole = InGameRolesData.GetDescriptionFromEnum((InGameRolesData.InGameRoles)3);
        }
        else if (skillsPerRole[0] == skillAsLurker)
        {
            inGameMainRole = InGameRolesData.GetDescriptionFromEnum((InGameRolesData.InGameRoles)4);
        }

        if (skillsPerRole[1] == skillAsEntryFragger && inGameMainRole != "Entry Fragger")
        {
            inGameSecondaryRole = InGameRolesData.GetDescriptionFromEnum((InGameRolesData.InGameRoles)0);
        }
        else if (skillsPerRole[1] == skillAsSupport && inGameMainRole != "Support")
        {
            inGameSecondaryRole = InGameRolesData.GetDescriptionFromEnum((InGameRolesData.InGameRoles)1);
        }
        else if (skillsPerRole[1] == skillAsInGameLeader && inGameMainRole != "In-Game Leader")
        {
            inGameSecondaryRole = InGameRolesData.GetDescriptionFromEnum((InGameRolesData.InGameRoles)2);
        }
        else if (skillsPerRole[1] == skillAsAWPer && inGameMainRole != "AWPer")
        {
            inGameSecondaryRole = InGameRolesData.GetDescriptionFromEnum((InGameRolesData.InGameRoles)3);
        }
        else if (skillsPerRole[1] == skillAsLurker && inGameMainRole != "Lurker")
        {
            inGameSecondaryRole = InGameRolesData.GetDescriptionFromEnum((InGameRolesData.InGameRoles)4);
        }
    }
}
