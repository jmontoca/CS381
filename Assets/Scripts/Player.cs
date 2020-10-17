using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //------------------------------
    // values that change while running
    //------------------------------
    public Vector3 position = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public Vector3 homePosition;
    public GameObject player;
    public GameObject gate;
    public GameObject enemyGateA;
    public GameObject enemyGateB;
    public GameObject enemyGateC;
    public GameObject enemyGateD;
    public int playerHealth;
    public int playerScore;
    public int playerTokens;
    public Vector3 openPosition = new Vector3(0, 5, 0);
    bool isOpen = false;
    bool isOpenA = false;
    bool isOpenB = false;
    bool isOpenC = false;
    bool isOpenD = false;

    public float speed;
    public float desiredSpeed;
    //------------------------------
    // values that do not change
    //------------------------------
    public float acceleration;
    public float maxSpeed;
    public float minSpeed;

    // Start is called before the first frame update
    void Start()
    {
        homePosition = new Vector3(-28, 3.5f, -28);
        player.transform.position = homePosition;
        position = player.transform.position;
        playerHealth = 3;
        playerScore = 0;
        playerTokens = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GateOpen();

        if (Input.GetKey(KeyCode.W))
            player.transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //Debug.Log("Positive Z Direction pressed");
        if (Input.GetKey(KeyCode.S))
            player.transform.Translate(Vector3.back * Time.deltaTime * speed);
           // Debug.Log("Negative Z Direction pressed");
        if (Input.GetKey(KeyCode.A))
            player.transform.Translate(Vector3.left * Time.deltaTime * speed);
           // Debug.Log("Positive X Direction pressed");
        if (Input.GetKey(KeyCode.D))
            player.transform.Translate(Vector3.right * Time.deltaTime * speed);
            //Debug.Log("Negative X Direction pressed");

        if (Input.GetKeyDown(KeyCode.M))
            SceneManager.LoadScene("Credits_Scene"); //short cut for testing purposes

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("collectable"))
        {
            other.gameObject.SetActive(false);
            playerScore += 100;
            playerTokens += 1;
            FindObjectOfType<SoundMgr>().CoinSound();
        }

        

        if (other.gameObject.CompareTag("Goal"))
        {
                FindObjectOfType<MainMenu>().Completion();
        }

        if (other.gameObject.CompareTag("Bounds"))
        {
            if (playerHealth != 0)
            {
                playerHealth -= 1;
                FindObjectOfType<SoundMgr>().FallingNoise();
            }
            else if (playerHealth == 0)
            {
                FindObjectOfType<MainMenu>().GameOver();
            }

            player.transform.position = homePosition;
        }
    }

    //going to want to take collision with opponents into account here
    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<GameMgr>().EnemyCollision(collision);
    }

    private void GateOpen()
    {

        if(playerTokens == 2 && isOpenA == false)
        {
            isOpenA = true;
            enemyGateA.transform.position = enemyGateA.transform.position + openPosition;
        }

        if (playerTokens == 4 && isOpenB == false)
        {
            isOpenB = true;
            enemyGateB.transform.position = enemyGateB.transform.position + openPosition;
        }

        if (playerTokens == 6 && isOpenC == false)
        {
            isOpenC = true;
            enemyGateC.transform.position = enemyGateC.transform.position + openPosition;
        }

        if (playerTokens == 8 && isOpenD == false)
        {
            isOpenD = true;
            enemyGateD.transform.position = enemyGateD.transform.position + openPosition;
        }

        if (playerTokens == 10 && isOpen == false)
        {
            isOpen = true;
            gate.transform.position = gate.transform.position + openPosition;
        }
    }
}
