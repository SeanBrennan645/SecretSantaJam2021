using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public BattleState state;

    public EnemyProfile[] EnemiesInBattle;
    private bool enemyActed;
    private int enemyMaxHealth;
    private float enemyHealthPercent;
    private GameObject[] EnemyAttacks;

    public GameObject[] PlayerUI;
    public GiftControl PlayerGift;
    public Text enemyHealthPercentText;

    [SerializeField] SceneChanger sceneChanger;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        enemyActed = false;
        foreach(EnemyProfile enemy in EnemiesInBattle)
        {
            enemy.currentHealth = enemy.maxHealth;
            enemy.isDead = false;
        }
        enemyMaxHealth = EnemiesInBattle[0].maxHealth; //not best practice but this will only ever have one enemy per battle for this jam
        GetEnemyHealthPercent();
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
    }

    void CheckState()
    {
        if(state ==BattleState.Start)
        {
            //setup the level
            foreach (GameObject UIElement in PlayerUI)
            {
                UIElement.SetActive(true);
            }
            state = BattleState.PlayerTurn;
        }
        else if(state == BattleState.PlayerTurn)
        {
            //player either attacks or heals
            //TODO change check for enemy dead here!!!
        }
        else if(state == BattleState.EnemyTurn)
        {
            if (EnemiesInBattle.Length <= 0)
            {
                EnemyFinishedTurn();
            }
            if (EnemiesInBattle[0].isDead) //direct index reference not best practice but ok for this atm
            {
                state = BattleState.Won;
            }
            else if (!enemyActed)
            {
                PlayerGift.gameObject.SetActive(true);
                PlayerGift.SetGift();

                foreach(EnemyProfile enemy in EnemiesInBattle)
                {
                    int AttackNum = Random.Range(0, enemy.EnemiesAttacks.Length);

                    Instantiate(enemy.EnemiesAttacks[AttackNum]);
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
                    Debug.Log("Enemy finished attack");
                    EnemyFinishedTurn();
                }
            }
        }
        else if (state == BattleState.FinishedTurn)
        {
            PlayerGift.gameObject.SetActive(false);

            if(PlayerGift.GetComponent<PlayerHealth>().isDead)
            {
                state = BattleState.Lost;
            }
            else
            {
                state = BattleState.Start;
            }
        }
        else if (state == BattleState.Won)
        {
            Debug.Log("Player Won!!");
            sceneChanger.LoadNextScene();
        }
        else if (state == BattleState.Lost)
        {
            Debug.Log("Player Lost!!!");
            sceneChanger.LoadPreviousScene();
        }
    }

    public void PlayerAct()
    {

        PlayerFinishTurn();
    }

    public void PlayerAttack()
    {
        PlayerGift.GetComponent<PlayerHealth>().ResetMultiplier(); // not very efficient
        foreach(EnemyProfile enemy in EnemiesInBattle)
        {
            enemy.TakeDamage(PlayerGift.attackDamage);
        }

        GetEnemyHealthPercent();

        PlayerFinishTurn();
    }

    public void PlayerHeal()
    {
        PlayerGift.GetComponent<PlayerHealth>().Heal();

        PlayerFinishTurn();
    }

    public void PlayerQuitGame()
    {
        //TODO create class that can be reused in menus and here
    }

    private void PlayerFinishTurn()
    {
        foreach (GameObject UIElement in PlayerUI)
        {
            UIElement.SetActive(false);
        }
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
    
    private void GetEnemyHealthPercent()
    {
        //Debug.Log(EnemiesInBattle[0].currentHealth);
        enemyHealthPercent = (float)EnemiesInBattle[0].currentHealth / (float)enemyMaxHealth;
        //Debug.Log(enemyHealthPercent);
        enemyHealthPercent = enemyHealthPercent * 100.0f;
        //Debug.Log(enemyHealthPercent);
        //Debug.Log(enemyMaxHealth);
        enemyHealthPercentText.text = enemyHealthPercent.ToString();
    }
}
