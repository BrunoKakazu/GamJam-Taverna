using UnityEngine;

public class TurnMenagerScript : MonoBehaviour
{
    private bool isPlayerTurn = true;
    private bool isEnemyTurn = false;

    private bool hasPlayerStayed = false;
    private bool hasEnemyStayed = false;
    
    private bool isDamageDealt = false;

    [SerializeField] private GameObject gameMenager;
    private GameMenagerScript gameMenagerScript;

    [SerializeField] private GameObject hitBtn;
    private HitButtonScript hitBtnScript;

    [SerializeField] private GameObject stayBtn;
    private StayButtonScript stayBtnScript;

    [SerializeField] private PlayerScript playerScript;
    [SerializeField] private EnemyScript enemyScript;

    private void Awake()
    {
        hitBtnScript = hitBtn.GetComponent<HitButtonScript>();
        stayBtnScript = stayBtn.GetComponent<StayButtonScript>();
        gameMenagerScript = gameMenager.GetComponent<GameMenagerScript>();
        hitBtn.SetActive(false);
        stayBtn.SetActive(false);
    }
    void Update()
    {
        if (gameMenagerScript.isGameStarted)
        {
            if (hasPlayerStayed && hasEnemyStayed)
            {
                TurnResolve();
            } else
            {
                if (isPlayerTurn && !hasPlayerStayed)
                {
                    PlayerTurn();
                }

                if (isEnemyTurn && !hasEnemyStayed)
                {
                    EnemyTurn();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameMenagerScript.GiveHands();
        }

    }

    private void PlayerTurn()
    {
        hitBtn.SetActive(true);
        stayBtn.SetActive(true);

        if (hitBtnScript.hasGivenCards) // Quando o player aperta o botao de HIT
        {
            
            if (!hasEnemyStayed) // Se o inimigo tiver parado, o turno do player continua
            {
                isPlayerTurn = false;
                isEnemyTurn = true;
            }
            
        }

        if (stayBtnScript.hasStayed) // Quando o player aperta o botao de STAY
        {
            hasPlayerStayed = true;

            isPlayerTurn = false;
            isEnemyTurn = true;

            stayBtnScript.hasStayed = false;
         
        }
    }

    private void EnemyTurn()
    {
        hitBtn.SetActive(false);
        stayBtn.SetActive(false);

        if (Input.GetKeyDown(KeyCode.H))
        {
            gameMenagerScript.GiveEnemyCard();

            if (!hasPlayerStayed)
            {
                isPlayerTurn = true;
                isEnemyTurn = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            stayBtnScript.Stay();

            isPlayerTurn = true;
            isEnemyTurn = false;
        }

        if (stayBtnScript.hasStayed)
        {
            hasEnemyStayed = true;

            isPlayerTurn = true;
            isEnemyTurn = false;

            stayBtnScript.hasStayed = false;

        }

        hitBtnScript.hasGivenCards = false;
    }

    public void TurnResolve()
    {
        gameMenagerScript.RevealCards();

        DealDamage();

        if (Input.GetKeyDown(KeyCode.R))
            EndRound();
    }

    private void DealDamage()
    {
        if (!isDamageDealt)
        {
            if (gameMenagerScript.GetEnemyDamage() <= 21)
                playerScript.TakeDamage(gameMenagerScript.GetEnemyDamage());
            if (gameMenagerScript.GetPlayerDamage() <= 21)
                enemyScript.TakeDamage(gameMenagerScript.GetPlayerDamage());

            Debug.Log($"Você recebeu: {gameMenagerScript.GetEnemyDamage()} de dano...");
            Debug.Log($"Você deu: {gameMenagerScript.GetPlayerDamage()} de dano...");
            isDamageDealt = true;
        }
    }

    private void EndRound()
    {
        gameMenagerScript.Restart();

        stayBtnScript.hasStayed = false;

        hasPlayerStayed = false;
        hasEnemyStayed = false;

        isDamageDealt = false;
    }
}
