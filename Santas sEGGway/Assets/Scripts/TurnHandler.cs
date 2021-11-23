using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    FinishedTurn,
    Won,
    Lost
}

public class TurnHandler : MonoBehaviour
{
    [SerializeField] BattleState state;

    [SerializeField] EnemyProfile[] EnemiesInBattle;
    private bool enemyActed;
    private GameObject[] EnemyAttacks;

    [SerializeField] GameObject PlayerUI;
    [SerializeField] GiftControl PlayerGift;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        enemyActed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckState()
    {
        if(state ==BattleState.Start)
        {
            //setup the level
            PlayerUI.SetActive(true);
            state = BattleState.PlayerTurn;
        }
        else if(state == BattleState.PlayerTurn)
        {
            //player either attacks or heals
        }
        else if(state == BattleState.EnemyTurn)
        {
            if (EnemiesInBattle.Length <= 0)
            {
                EnemyFinishedTurn();
            }
            else if (!enemyActed)
            {
                PlayerGift.gameObject.SetActive(true);
                PlayerGift.SetGift();

                foreach(EnemyProfile enemy in EnemiesInBattle)
                {
                    int AttackNum = Random.Range(0, enemy.EnemiesAttacks.Length);

                    Instantiate(enemy.EnemiesAttacks[AttackNum], Vector2.zero, Quaternion.identity);
                }

                EnemyAttacks = GameObject.FindGameObjectsWithTag("Enemy");

                enemyActed = true;
            }
            else
            {
                bool enemyFinished = true;
                foreach(GameObject enemy in EnemyAttacks)
                {
                    if(!enemy.GetComponent<EnemyTurnHandler>().FinishedTurn)
                    {
                        enemyFinished = false;
                    }
                }

                if(enemyFinished)
                {
                    EnemyFinishedTurn();
                }
            }
        }
        else if (state == BattleState.FinishedTurn)
        {
            PlayerGift.gameObject.SetActive(false);

            if(PlayerGift.GetComponent<PlayerHealth>().currentHealth <= 0)
            {
                state = BattleState.Lost;
            }
            else
            {
                //if enemy is dead

                state = BattleState.Start;
            }
        }
        else if (state ==BattleState.Won)
        {

        }
    }

    public void PlayerAct()
    {
        //bring up menu for player

        PlayerFinishTurn();
    }

    private void PlayerFinishTurn()
    {
        PlayerUI.SetActive(false);
        state = BattleState.EnemyTurn;
    }

    void EnemyFinishedTurn()
    {
        //destroy all attacks
        foreach(GameObject obj in EnemyAttacks)
        {
            Destroy(obj);
        }

        enemyActed = false;
        state = BattleState.FinishedTurn;
    }
}
