using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnHandler : MonoBehaviour
{
    public bool FinishedTurn;
    public int AttackAmounts;

    // Start is called before the first frame update
    void Start()
    {
        FinishedTurn = false;

        int attackNum = Random.Range(0, AttackAmounts);
        //Debug.Log("AttackDex is " + attackNum);
        GetComponent<Animator>().SetInteger("AttackDex", attackNum);
    }

    public void AttackDone()
    {
        FinishedTurn = true;
    }
}
