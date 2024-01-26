using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class EnemyController : MonoBehaviour
    {
        private GameObject target;
        public float speed;

        public int maxHealth = 5;
        private int currentHealth;
        public int damage;

        private float distance;

        private Rigidbody2D rigidbody2d;

        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("EnemyTarget");
            currentHealth = maxHealth;
            rigidbody2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var currentPosition = transform.position;
            var targetPosition = target.transform.position;

            distance = Vector2.Distance(currentPosition, targetPosition);
            rigidbody2d.MovePosition(
                Vector2.MoveTowards(
                    currentPosition,
                    targetPosition,
                    speed * Time.deltaTime
                )
            );
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("EnemyTarget"))
            {
                collision.gameObject.SendMessage("ChangeHealth", -damage);
            }
        }

        public void ChangeHealth(int amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            Debug.Log("Enemy health:" + currentHealth + "/" + maxHealth);
            StartCoroutine(VisualIndicator(Color.red));

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        private IEnumerator VisualIndicator(Color color)
        {
            GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(0.15f);
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}