using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy1Prefab;
    [SerializeField]
    private float enemy1Interval = 3.5f;

    [SerializeField]
    private GameObject enemy2Prefab;
    [SerializeField]
    private float enemy2Interval = 3.5f;

    private GameObject target;

    public float minDistanceToTarget;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("EnemyTarget");
        StartCoroutine(spawnEnemy(enemy1Interval, enemy1Prefab));
        StartCoroutine(spawnEnemy(enemy2Interval, enemy2Prefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        Vector2 spawnPosition = new Vector2(Random.Range(-10F, 10), Random.Range(-5f, 4f));
        
        if((target.transform.position.x - spawnPosition.x > minDistanceToTarget || target.transform.position.x - spawnPosition.x < -minDistanceToTarget)
            &&
            (target.transform.position.y - spawnPosition.y > minDistanceToTarget || target.transform.position.y - spawnPosition.y < -minDistanceToTarget) ) {
             yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
        
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
