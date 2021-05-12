using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCheckerBFS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inRangeCubes();
    }

    private void inRangeCubes()
    {
        Vector3 currentPos = gameObject.transform.position;
        int currentStamina = gameObject.GetComponent<StaminaTracker>().GetStamina();

        int largestPossArray = findArraySize(currentStamina);
        GameObject[] legalSpaces = new GameObject[largestPossArray];

    }

    public int findArraySize(int stamina)
    {
        if (stamina == 0)
        {
            return 0;
        }
        if (stamina == 1)
        {
            return 1;
        }

        int[] dp = new int[stamina + 1];
        dp[0] = 0;
        dp[1] = 5;

        int sequenceIncrement = 8;

        for(int i = 2; i <= stamina; i++)
        {
            dp[i] = dp[i - 1] + sequenceIncrement;
            sequenceIncrement += 4;
        }

        return dp[stamina];
    }
}
