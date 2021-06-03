using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Object playerPrefab;
    public Transform spawnPoint;
    bool flashStatus = false;
    public GameObject flash; 
    public Text flashText;
    public Text scoreText;
    public string status = "ON";
    bool isOn = true;
    bool isPaused = false;
    bool isWinner = false;
    int score = 12;
    int GOscore = 0;
    public int GameOverScore
    {
        get { return GOscore; }
        set { GOscore = value; }
    }
    FirstPersonController player;
    public GameObject pauseMenu;
    public GameObject winner;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    public bool Status
    {
        get { return flashStatus; }
        set { flashStatus = value; }

    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*  if (playerPrefab && !player && Input.GetKeyDown(KeyCode.Return))
          {
              player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
          }*/
        if (score == 0 && GOscore == 0)

        {
            Winner();
        }
        scoreText.text = "Remaining to Escape: " + score.ToString();
        if (Input.GetKeyDown(KeyCode.Escape) && GOscore ==0)
        {
            TogglePause();
        }
        if (Input.GetMouseButtonDown(1))
        {
            ToggleFlash();
        }
        if (flashStatus == false)
        {
            status = "ON";
            flashText.text = "Flashlight: " + status;
        }
        if (flashStatus == true)
        {
            status = "OFF";
            flashText.text = "Flashlight: " + status;
        }
    }

    public void TogglePause()
    {

        isPaused = !isPaused;

        pauseMenu.SetActive(isPaused);

        Time.timeScale = isPaused ? 0.0f : 1.0f;
        // GameObject.FindGameObjectsWithTag("Player").Get

        player.enabled = !isPaused;

        if (isPaused)
        {
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


    }

    public void ToggleFlash()
    {
        GameObject.FindObjectOfType<AudioManager>().PlayToggleFlash();

        isOn = !isOn;

        flash.SetActive(isOn);
        flashStatus = !flashStatus;

    }
    public void Winner()
    {
        GOscore++;
        score--;
        isWinner = !isWinner;

        winner.SetActive(isWinner);

        Time.timeScale = isWinner ? 0.0f : 1.0f;
        // GameObject.FindGameObjectsWithTag("Player").Get

        player.enabled = !isWinner;

        if (isWinner)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGames()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
