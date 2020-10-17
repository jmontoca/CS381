using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public Player player;

    public void EnemyCollision(Collision givenCollision)
    {

        if (givenCollision.gameObject.CompareTag("Enemy"))
        {
            //move this code to a gameMgr script
            if (player.playerHealth != 0)
            {
                FindObjectOfType<SoundMgr>().HealthLose();
                FindObjectOfType<SoundMgr>().EnemyNoise();
                player.playerHealth -= 1;
            }
            else if (player.playerHealth == 0)
            {
                FindObjectOfType<MainMenu>().GameOver();
            }
        }
    }

    public void PlayerFallingOutOfBounds(Collider bounds)
    {
        if(bounds.gameObject.CompareTag("Bounds"))
        {
            if (player.playerHealth != 0)
            {
                player.playerHealth -= 1;
            }
            else if (player.playerHealth == 0)
            {
                FindObjectOfType<MainMenu>().GameOver();
            }
        }
    }
}
