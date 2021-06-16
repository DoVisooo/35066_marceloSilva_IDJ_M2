using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeamRankingManager : MonoBehaviour
{
    public List<GameObject> teamList;
    public List<GameObject> teamRanking;
    public InputManager inputManager;

    void Start()
    {
        teamList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (teamList.Count < 11)
        {
            for (int i = 0; i < inputManager.teamsGO.Length; i++)
            {
                if (inputManager.teamsGO[i] != null)
                {
                    teamList.Add(inputManager.teamsGO[i]);
                    Debug.Log("hey");
                }
            }
        }

        teamRanking = teamList.OrderByDescending(o => o.GetComponent<TeamMembers>().teamReputation).ToList();

        for (int i = 0; i < teamRanking.Count; i++)
        {
            teamRanking[i].GetComponent<TeamMembers>().teamRanking = i + 1;

            if (teamRanking[i].GetComponent<TeamMembers>().teamRanking > 10)
            {
                teamRanking[i].GetComponent<TeamMembers>().teamTier = 2;
            }
            else
            {
                teamRanking[i].GetComponent<TeamMembers>().teamTier = 1;
            }
        }
    }
}
