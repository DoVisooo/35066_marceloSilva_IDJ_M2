using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public TeamProfile teamsManager;
    public TeamProfile[] teams;
    public GameObject[] teamsGO;
    public GameObject teamGameObject;

    public List<TeamProfile> teamsList;

    public PersonProfile personsManager;
    public GameObject playerGameObject;
    public GameObject staffGameObject;
    public int numOfPlayers = 600;

    public void Start()
    {
        teamsList = new List<TeamProfile>();

        TeamProfile astralis = new TeamProfile("Astralis", "AST", "Denmark", "EU", 1, new System.DateTime(2016, 1, 18));
        teams[0] = astralis;
        TeamProfile natusvincere = new TeamProfile("Natus Vincere", "Na´Vi", "Ukraine", "CIS", 1, new System.DateTime(2009, 12, 17));
        teams[1] = natusvincere;
        TeamProfile g2 = new TeamProfile("G2 Esports", "G2", "Germany", "EU", 1, new System.DateTime(2014, 2, 24));
        teams[2] = g2;
        TeamProfile liquid = new TeamProfile("Team Liquid", "TL", "USA", "NA", 1, new System.DateTime(2000, 1, 1));
        teams[3] = liquid;
        TeamProfile faze = new TeamProfile("FaZe Clan", "FaZe", "Germany", "EU", 1, new System.DateTime(2010, 5, 30));
        teams[4] = faze;
        TeamProfile fnatic = new TeamProfile("Fnatic", "FNC", "England", "EU", 1, new System.DateTime(2004, 6, 23));
        teams[5] = fnatic;
        TeamProfile nip = new TeamProfile("Ninjas in Pyjamas", "NiP", "Sweden", "EU", 1, new System.DateTime(2000, 1, 1));
        teams[6] = nip;
        TeamProfile mouz = new TeamProfile("mousesports", "mouz", "Germany", "EU", 1, new System.DateTime(2002, 1, 1));
        teams[7] = mouz;
        TeamProfile vitality = new TeamProfile("Team Vitality", "VIT", "France", "EU", 1, new System.DateTime(2013, 8, 1));
        teams[8] = vitality;
        TeamProfile vp = new TeamProfile("Virtus.pro", "VP", "Russia", "CIS", 1, new System.DateTime(2003, 11, 1));
        teams[9] = vp;
        TeamProfile gambit = new TeamProfile("Gambit Esports", "GMB", "Russia", "CIS", 1, new System.DateTime(2013, 1, 14));
        teams[10] = gambit;

        for (int i = 0; i < numOfPlayers; i++)
        {
            personsManager.GenerateNewPlayer();
            PersonProfile lastPerson = personsManager.personsList[personsManager.personsList.Count - 1];
        }

        for (int i = 0; i < teams.Length; i++)
        {
            teamsManager.GenerateNewTeam(teams[i]);   
            teamsList.Add(teams[i]);
        }

        for (int i = 0; i < teams.Length; i++)
        {
            teams[i] = GameObject.Find(TeamProfile.teamsList[i].teamName).gameObject.GetComponent<TeamMembers>();
            teamsGO[i] = GameObject.Find(TeamProfile.teamsList[i].teamName).gameObject;
            teams[i].GetComponent<TeamMembers>().teamRanking = teamsGO[i].GetComponent<TeamMembers>().teamRanking;
            teamsGO[i].GetComponent<TeamMembers>().teamRanking = i + 1;
            Debug.Log("oi");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < numOfPlayers; i++)
            {
                personsManager.GenerateNewPlayer();
                PersonProfile lastPerson = personsManager.personsList[personsManager.personsList.Count - 1];
                print("New player generated: " + lastPerson.firstName + " " + "''" + lastPerson.nickname + "''" + " " + lastPerson.lastName);
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < teams.Length; i++)
            {
                teamsManager.GenerateNewTeam(teams[i]);
            }
        }
    }
}
