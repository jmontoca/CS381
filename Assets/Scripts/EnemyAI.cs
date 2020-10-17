using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public GameObject enemy;
    public float dist;

    // Start is called before the first frame update
    void Start()
    {
        dist = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
        //Flee();
    }

    private void MoveTowardsPlayer()
    {
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void Flee()
    {
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, -target.transform.position, speed * Time.deltaTime);
    }
}
