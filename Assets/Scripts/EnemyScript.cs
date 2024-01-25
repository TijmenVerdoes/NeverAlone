using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    private GameObject target;
    public float speed;

    public int maxHealth = 5;
    private int currentHealth;
    public int damage;

    private float distance;

    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("EnemyTarget");
        currentHealth = maxHealth;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        distance = Vector2.Distance(transform.position, target.transform.position);
        rigidbody2d.MovePosition(Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime));
    }

    void OnCollisionStay2D(Collision2D other){
        PlayerMovementTemp playerScript = other.gameObject.GetComponent<PlayerMovementTemp>();

        if(playerScript != null){
            playerScript.changeHealth(-damage);
        }
    }

    void changeHealth(int amount){
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log("Enemy health:" + currentHealth + "/" + maxHealth);
        StartCoroutine(VisualIndicator(Color.red));
        
        if(currentHealth <= 0){
             Destroy(gameObject);
        }
    }

    private IEnumerator VisualIndicator (Color color){
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
