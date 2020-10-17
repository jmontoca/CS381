using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public AudioSource coins;
    public AudioSource damage;
    public AudioSource growl;
    public AudioSource fall;


    public void CoinSound()
    {
        coins.Play();
    }

    public void HealthLose()
    {
        damage.Play();
    }

    public void EnemyNoise()
    {
        growl.Play();
    }

    public void FallingNoise()
    {
        fall.Play();
    }
}
