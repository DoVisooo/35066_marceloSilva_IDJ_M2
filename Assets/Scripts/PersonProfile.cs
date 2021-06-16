using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonProfile : MonoBehaviour
{
    public GameObject inputManager;

    public string firstName;
    public string lastName;
    public string nickname;
    public int age;
    public string gender;
    public string country;
    public string team;
    public int birthdayMonth;
    public int birthdayDay;
    public int birthdayYear;
    public string role;
    public List<PersonProfile> personsList = new List<PersonProfile>();
    public List<Player> playerList = new List<Player>();

    public void GenerateNewPlayer()
    {
        GameObject playerObj = Instantiate(inputManager.GetComponent<InputManager>().playerGameObject, Vector3.zero, Quaternion.identity);
        Player player = playerObj.GetComponent<Player>();

        GenderData.Gender randomGender = (GenderData.Gender)Random.Range(0, 2);
        player.gender = randomGender.ToString();

        if (randomGender == GenderData.Gender.Male)
        {
            MaleFirstNameData.MaleFirstName randomMaleFirstName = (MaleFirstNameData.MaleFirstName)Random.Range(0, 10);
            player.firstName = randomMaleFirstName.ToString();
        } 
        else if (randomGender == GenderData.Gender.Female)
        {
            FemaleFirstNameData.FemaleFirstName randomFemaleFirstName = (FemaleFirstNameData.FemaleFirstName)Random.Range(0, 10);
            player.firstName = randomFemaleFirstName.ToString();
        }

        LastNameData.LastName randomLastName = (LastNameData.LastName)Random.Range(0, 10);
        player.lastName = randomLastName.ToString();

        NicknameData.Nickname randomNickname = (NicknameData.Nickname)Random.Range(0, 20);
        player.nickname = randomNickname.ToString();

        player.birthdayMonth = Random.Range(1, 13);

        player.birthdayDay = Random.Range(1, 32);

        if (player.birthdayMonth == 4 || player.birthdayMonth == 6 || player.birthdayMonth == 9 || player.birthdayMonth == 11 && player.birthdayDay == 31)
        {
            player.birthdayDay = 30;
        }
        else if (player.birthdayMonth == 2 && player.birthdayDay > 28)
        {
            player.birthdayDay = 28;
        }

        player.birthdayYear = Random.Range(1981, 2007);

        System.DateTime birthday = new System.DateTime(player.birthdayYear, player.birthdayMonth, player.birthdayDay);
        player.age = Mathf.RoundToInt((float)System.DateTime.Now.Subtract(birthday).TotalDays) / 365;

        CountryData.Country randomCountry = (CountryData.Country)Random.Range(0, 10);
        player.country = randomCountry.ToString();

        /*TeamsData.Teams randomTeam = (TeamsData.Teams)Random.Range(0, 12);
        player.team = TeamsData.GetDescriptionFromEnum(randomTeam);*/

        player.team = "Free Agent";

        player.role = RolesData.Roles.Player.ToString();

        playerObj.transform.name = player.firstName.ToString() + " " + "''" + player.nickname.ToString() + "''" + " " + player.lastName.ToString();
        personsList.Add(player);
        playerList.Add(player);
    }
}
