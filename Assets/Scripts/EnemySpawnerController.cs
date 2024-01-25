using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy1Prefab;
    [SerializeField]
    private float enemyInterval = 3.5f;

    private GameObject target;

    public float minDistanceToTarget;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("EnemyTarget");
        StartCoroutine(spawnEnemy(enemyInterval, enemy1Prefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        Vector2 spawnPosition = new Vector2(Random.Range(-10F, 10), Random.Range(-5f, 5f));
        
        if((target.transform.position.x - spawnPosition.x > minDistanceToTarget || target.transform.position.x - spawnPosition.x < -minDistanceToTarget)
            &&
            (target.transform.position.y - spawnPosition.y > minDistanceToTarget || target.transform.position.y - spawnPosition.y < -minDistanceToTarget) ) {
             yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
        
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
