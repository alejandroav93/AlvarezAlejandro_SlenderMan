
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    LevelManager manager;
    FirstPersonController player;
    public GameObject GameOverMenu;
    bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        manager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")){
            GameObject.FindObjectOfType<AudioManager>().PlayDeath();

            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Patrol"))
        {
            GameObject.FindObjectOfType<AudioManager>().PlayDeath();

            Destroy(gameObject);
        }


    }
    private void OnCollisionStay(Collision collision)
    {

    }
    private void OnCollisionExit(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Memento"))
        {
            GameObject.FindObjectOfType<AudioManager>().PlayCoin();

            Destroy(other.gameObject);
            manager.Score--;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject.FindObjectOfType<AudioManager>().PlayDeath();
            GameOver();
        }


    }

    public void GameOver()
    {

        isEnd = !isEnd;

        GameOverMenu.SetActive(isEnd);

        Time.timeScale = isEnd ? 0.0f : 1.0f;
        manager.GameOverScore++;
        player.enabled = !isEnd;

        if (isEnd)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}
