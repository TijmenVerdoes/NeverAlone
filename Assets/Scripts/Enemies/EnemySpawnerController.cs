using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class EnemySpawnerController : MonoBehaviour
    {
        [SerializeField] private GameObject enemy1Prefab;

        [SerializeField] private float enemyInterval = 3.5f;

        private GameObject target;

        public float minDistanceToTarget;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("EnemyTarget");
            StartCoroutine(SpawnEnemy(enemyInterval, enemy1Prefab));
        }

        private IEnumerator SpawnEnemy(float interval, GameObject enemy)
        {
            var spawnPosition = new Vector2(Random.Range(-11F, 11), Random.Range(-4.75f, 4.5f));

            if ((target.transform.position.x - spawnPosition.x > minDistanceToTarget
                 || target.transform.position.x - spawnPosition.x < -minDistanceToTarget)
                &&
                (target.transform.position.y - spawnPosition.y > minDistanceToTarget
                 || target.transform.position.y - spawnPosition.y < -minDistanceToTarget))
            {
                yield return new WaitForSeconds(interval);
                Instantiate(enemy, spawnPosition, Quaternion.identity);
            }

            StartCoroutine(SpawnEnemy(interval, enemy));
        }
    }
}