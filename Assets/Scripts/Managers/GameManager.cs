using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public ProtoSpawnerManager spawnerManager;
    
    public static GameManager instance  { get; private set; }
    public GameObject projectile;
    public Player[] players;
    public Sprite[] teamJersys;
    public float timeInGame;
    public enum Team { RED, BLUE, GREEN, YELLOW };
    private bool isGameEnded; // later upgrade to enum to accomidate a pause state;

    private Text TimerOnScoreBoard;
    public Text RedScoreDisplay;
    public Text BlueScoreDisplay; // Throw these in an array, or is that overkill?
    public Text GreenScoreDisplay;
    public Text YellowScoreDisplay;
    public Text WinnerText; 

    private float timeLeftInGame;
    private float gameEndTimer = 5.0f;
    private int redScore;
    private int blueScore;
    private int greenScore;
    private int yellowScore;
    private int playersInGame = 2; //Debug Hack

    private void Awake()
    {
        instance = this;
        ShotManager.Instance.loadAllShots(projectile);
        divyTeams();
        timeLeftInGame = timeInGame;
        WinnerText.enabled = false;
        isGameEnded = false;
        // Initialize scoreboard function?
        TimerOnScoreBoard = GetComponentInChildren<Text>();
        callScore();
    }


    private void Update()
    {
        foreach (Player p in players)
        {
            if (p.playerIsAlive() == Player.lifeState.ELIMINATED)
            {
                p.changeLifeState(Player.lifeState.RESPAWNING);
                //resetFlag(); // 50% hack better than what I would have done, but still;
                spawnerManager.sortDeadPlayer(p);
            }

            updateTimeBoard();
        }
    }

    public void UpdateScore(ProtoSpawnerManager.flagColor flagToScore)
    {
        switch(flagToScore)
        {
            case ProtoSpawnerManager.flagColor.RED:
                {
                    redScore++;
                    callScore();
                    break;
                }
            case ProtoSpawnerManager.flagColor.BLUE:
                {
                    blueScore++;
                    callScore();
                    break;
                }
            case ProtoSpawnerManager.flagColor.YELLOW:
                {
                    yellowScore++;
                    callScore();
                    break;
                }
            case ProtoSpawnerManager.flagColor.GREEN:
                {
                    greenScore++;
                    callScore();
                    break;
                }
          }     
    }

    public void resetFlag()
    {
        spawnerManager.checkFlagSpawners();
    }

    private void divyTeams() // Need to come up with a 4p algorithum, or better yet, let the players decide what team they want to be on. 
    {
        for (int i = 0; i < playersInGame; i++)
        {
            players[i].changeTeamColor((Team)i);
            players[i].GetComponent<SpriteRenderer>().sprite = teamJersys[i];
        }
    }

    private void callScore()
    {
        RedScoreDisplay.text = redScore.ToString();
        BlueScoreDisplay.text = blueScore.ToString();
        YellowScoreDisplay.text = yellowScore.ToString();
        GreenScoreDisplay.text = greenScore.ToString();
    }

    private void updateTimeBoard()
    {
        if (!isGameEnded)
        {
            timeLeftInGame -= Time.deltaTime / 2; // the half may cause some problems, but it slows the timer down to real seconds.
            formatTimer();

            if (timeLeftInGame <= 0)
            {
                endTheGame();
            }
        }

        if (isGameEnded)
        {
            gameEndTimer -= Time.deltaTime;
            if (gameEndTimer <= 0)
            {
                replayChoiceDisplayed();
            }
        }
       
      
    }

    private void formatTimer()
    {
        TimerOnScoreBoard.text = string.Format("{0} : {1:0.00}", (int)timeLeftInGame / 60, timeLeftInGame % 60);  
    }


    private void endTheGame()
    {

        string winner;

        isGameEnded = true;
        WinnerText.enabled = true;

        if (redScore > blueScore)
        {
            winner = Team.RED.ToString() + " TEAM WINS ";
        }

        else if (blueScore > redScore)
        {
            winner = Team.BLUE.ToString() + " TEAM WINS ";
        }

        else
            winner = "TIE GAME";

        WinnerText.text = winner;

        endOfGameFlagRevoke();
        // play fanfare? 
        // wait 
        //exit application

    }

    private void replayChoiceDisplayed()
    {
      Application.LoadLevel("EndGameTestScene");    // Fix this and the rest of the end code next. 
                                                    // Move to an end game manager.
                                                    // refactor
                                                    // Count Down
                                                    // Display choices
                                                    // get input from player 1
                                                    // either restart game or close the app.

    }

    private void endOfGameFlagRevoke()
    {
        spawnerManager.revokeFlags();
    }

}
