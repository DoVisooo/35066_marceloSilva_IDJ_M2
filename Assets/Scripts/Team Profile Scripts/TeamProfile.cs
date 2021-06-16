using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamProfile : MonoBehaviour
{
    public GameObject inputManager;

    public string teamName;
    public string teamTAG;
    public string teamHQCountry;
    public string teamRegion;
    public int teamTier;
    public System.DateTime foundationDate;
    public static List<TeamProfile> teamsList = new List<TeamProfile>();
    public float teamReputation;
    public int teamRanking;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (inputManager == null)
        {
            inputManager = GameObject.FindGameObjectWithTag("InputManager").gameObject;
        }
    }

    public TeamProfile()
    {

    }

    public TeamProfile(string name, string tag, string hqcountry, string region, int tier, System.DateTime foundation)
    {
        this.teamName = name;
        this.teamTAG = tag;
        this.teamHQCountry = hqcountry;
        this.teamRegion = region;
        this.teamTier = tier;
        this.foundationDate = foundation;
    }

    public void GenerateNewTeam(TeamProfile team)
    {
        GameObject teamObj = Instantiate(inputManager.GetComponent<InputManager>().teamGameObject, Vector3.zero, Quaternion.identity);
        teamObj.transform.name = team.teamName;
        TeamProfile teamInfo = teamObj.GetComponent<TeamProfile>();
        teamInfo.teamName = team.teamName;
        teamInfo.teamTAG = team.teamTAG;
        teamInfo.teamHQCountry = team.teamHQCountry;
        teamInfo.teamRegion = team.teamRegion;
        teamInfo.teamTier = team.teamTier;
        teamInfo.foundationDate = team.foundationDate;
        //teamInfo.teamReputation = teamObj.GetComponent<TeamMembers>().teamReputation;
        teamsList.Add(team);
    }
}