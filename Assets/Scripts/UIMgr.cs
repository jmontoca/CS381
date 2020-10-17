using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    public GameObject playerTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Text playerHealth;
    public Text playerScore;
    public Text playerTokens;

    // Update is called once per frame
    void Update()
    {
        playerHealth.text = playerTarget.GetComponent<Player>().playerHealth.ToString();
        playerScore.text = playerTarget.GetComponent<Player>().playerScore.ToString();
        playerTokens.text = playerTarget.GetComponent<Player>().playerTokens.ToString();
    }
}
