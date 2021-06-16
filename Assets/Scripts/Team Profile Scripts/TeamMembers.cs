using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TeamMembers : TeamProfile
{
    public string CEO;
    public string CEOCountry;
    public string headCoach;
    public string headCoachCountry;
    public Player captain;
    public int teamReputation;
    public Player[] players = new Player[5];
    public Player entryFragger, support, inGameLeader, aWPer, lurker;
    public GameObject personsManager;
    public Player starPlayer;
    public Player wonderkid;
    public bool fullTeam;

    private void Start()
    {
        personsManager = GameObject.Find("PersonsManager");
        fullTeam = false;

        GenderData.Gender CEORandomGender = (GenderData.Gender)Random.Range(0, 2);

        if (CEORandomGender == GenderData.Gender.Male)
        {
            MaleFirstNameData.MaleFirstName randomMaleFirstName = (MaleFirstNameData.MaleFirstName)Random.Range(0, 10);
            LastNameData.LastName randomLastName = (LastNameData.LastName)Random.Range(0, 10);
            NicknameData.Nickname randomNickname = (NicknameData.Nickname)Random.Range(0, 20);

            CEO = randomMaleFirstName + " ''" + randomNickname + "'' " + randomLastName;
        }
        else if (CEORandomGender == GenderData.Gender.Female)
        {
            FemaleFirstNameData.FemaleFirstName randomFemaleFirstName = (FemaleFirstNameData.FemaleFirstName)Random.Range(0, 10);
            LastNameData.LastName randomLastName = (LastNameData.LastName)Random.Range(0, 10);
            NicknameData.Nickname randomNickname = (NicknameData.Nickname)Random.Range(0, 20);

            CEO = randomFemaleFirstName + " ''" + randomNickname + "'' " + randomLastName;
        }

        CountryData.Country CEORandomCountry = (CountryData.Country)Random.Range(0, 10);
        CEOCountry = CEORandomCountry.ToString();

        GenderData.Gender CoachRandomGender = (GenderData.Gender)Random.Range(0, 2);

        if (CoachRandomGender == GenderData.Gender.Male)
        {
            MaleFirstNameData.MaleFirstName randomMaleFirstName = (MaleFirstNameData.MaleFirstName)Random.Range(0, 10);
            LastNameData.LastName randomLastName = (LastNameData.LastName)Random.Range(0, 10);
            NicknameData.Nickname randomNickname = (NicknameData.Nickname)Random.Range(0, 20);

            headCoach = randomMaleFirstName + " ''" + randomNickname + "'' " + randomLastName;
        }
        else if (CoachRandomGender == GenderData.Gender.Female)
        {
            FemaleFirstNameData.FemaleFirstName randomFemaleFirstName = (FemaleFirstNameData.FemaleFirstName)Random.Range(0, 10);
            LastNameData.LastName randomLastName = (LastNameData.LastName)Random.Range(0, 10);
            NicknameData.Nickname randomNickname = (NicknameData.Nickname)Random.Range(0, 20);

            headCoach = randomFemaleFirstName + " ''" + randomNickname + "'' " + randomLastName;
        }

        CountryData.Country CoachRandomCountry = (CountryData.Country)Random.Range(0, 10);
        headCoachCountry = CoachRandomCountry.ToString();
    }

    private void Update()
    {
        if (inputManager == null)
        {
            inputManager = GameObject.FindGameObjectWithTag("InputManager").gameObject;
        }

        List<PersonProfile> personsList = personsManager.GetComponent<PersonProfile>().personsList;
        for (int i = 0; i < personsList.Count; i++)
        {
            if (personsList[i].role == RolesData.Roles.Player.ToString() && personsList[i].GetComponent<Player>().inGameMainRole == "Entry Fragger" && personsList[i].GetComponent<Player>().team == "Free Agent" && entryFragger == null)
            {
                entryFragger = personsList[i].GetComponent<Player>();
                players[0] = entryFragger;
                personsList[i].GetComponent<Player>().team = this.teamName;
            }
            else if (personsList[i].role == RolesData.Roles.Player.ToString() && personsList[i].GetComponent<Player>().inGameMainRole == "Support" && personsList[i].GetComponent<Player>().team == "Free Agent" && support == null)
            {
                support = personsList[i].GetComponent<Player>();
                players[1] = support;
                personsList[i].GetComponent<Player>().team = this.teamName;
            }
            else if (personsList[i].role == RolesData.Roles.Player.ToString() && personsList[i].GetComponent<Player>().inGameMainRole == "In-Game Leader" && personsList[i].GetComponent<Player>().team == "Free Agent" && inGameLeader == null)
            {
                inGameLeader = personsList[i].GetComponent<Player>();
                players[2] = inGameLeader;
                personsList[i].GetComponent<Player>().team = this.teamName;
            }
            else if (personsList[i].role == RolesData.Roles.Player.ToString() && personsList[i].GetComponent<Player>().inGameMainRole == "AWPer" && personsList[i].GetComponent<Player>().team == "Free Agent" && aWPer == null)
            {
                aWPer = personsList[i].GetComponent<Player>();
                players[3] = aWPer;
                personsList[i].GetComponent<Player>().team = this.teamName;
            }
            else if (personsList[i].role == RolesData.Roles.Player.ToString() && personsList[i].GetComponent<Player>().inGameMainRole == "Lurker" && personsList[i].GetComponent<Player>().team == "Free Agent" && lurker == null)
            {
                lurker = personsList[i].GetComponent<Player>();
                players[4] = lurker;
                personsList[i].GetComponent<Player>().team = this.teamName;
            }
        }

        this.captain = inGameLeader;
        this.teamReputation = (this.entryFragger.currentAbility + this.support.currentAbility + this.inGameLeader.currentAbility + this.aWPer.currentAbility + this.lurker.currentAbility) / 5;

        for (int i = 0; i < players.Length - 2; i++)
        {
            for (int j = 0; j <= players.Length - 2; j++)
            {
                if (players[i].currentAbility < players[i + 1].currentAbility)
                {
                    starPlayer = players[i + 1];
                    players[i + 1] = players[i];
                    players[i] = starPlayer;
                }
                else
                {
                    starPlayer = players[i];
                }
            }
        }

        for (int i = 0; i < players.Length - 2; i++)
        {
            for (int j = 0; j <= players.Length - 2; j++)
            {
                if (players[i].potentialAbility <= players[i + 1].potentialAbility)
                {
                    if (players[i].age <= 21 || players[i + 1].age <= 21)
                    {
                        wonderkid = players[i + 1];
                        players[i + 1] = players[i];
                        players[i] = wonderkid;
                    }
                }
                else
                {
                    if (players[i].age <= 21 || players[i + 1].age <= 21)
                    {
                        wonderkid = players[i];
                    }
                }
            }
        }

        if (entryFragger != null && support != null && inGameLeader != null && aWPer != null && lurker != null && captain != null && starPlayer != null)
        {
            fullTeam = true;
        }
        else
        {
            fullTeam = false;
        }
    }

    void GenerateCEO(string name, string country)
    {
        GenderData.Gender randomGender = (GenderData.Gender)Random.Range(0, 2);

        if (randomGender == GenderData.Gender.Male)
        {
            MaleFirstNameData.MaleFirstName randomMaleFirstName = (MaleFirstNameData.MaleFirstName)Random.Range(0, 10);
            LastNameData.LastName randomLastName = (LastNameData.LastName)Random.Range(0, 10);
            NicknameData.Nickname randomNickname = (NicknameData.Nickname)Random.Range(0, 20);

            this.name = randomMaleFirstName + " ''" + randomNickname + "'' " + randomLastName;
        }
        else if (randomGender == GenderData.Gender.Female)
        {
            FemaleFirstNameData.FemaleFirstName randomFemaleFirstName = (FemaleFirstNameData.FemaleFirstName)Random.Range(0, 10);
            LastNameData.LastName randomLastName = (LastNameData.LastName)Random.Range(0, 10);
            NicknameData.Nickname randomNickname = (NicknameData.Nickname)Random.Range(0, 20);

            this.name = randomFemaleFirstName + " ''" + randomNickname + "'' " + randomLastName;
        }

        CountryData.Country randomCountry = (CountryData.Country)Random.Range(0, 10);
        country = randomCountry.ToString();

        CEO = name;
        CEOCountry = country;
    }

    void GenerateCoach(string name, string country)
    {

    }
}
