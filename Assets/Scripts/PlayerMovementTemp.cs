using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTemp : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    public float timeInvincible = 2.0F;
    private float invincibleTimer;
    private bool isInvincible;

    float horizontal; 
    float vertical;

    Rigidbody2D rigidbody2d;
   // Start is called before the first frame update
   void Start()
   {
    currentHealth = maxHealth;
    invincibleTimer = 0;
    isInvincible = false;

    rigidbody2d = GetComponent<Rigidbody2D>();
   }

   // Update is called once per frame
   void Update(){
    horizontal = Input.GetAxis("Horizontal");
    vertical = Input.GetAxis("Vertical");

    if (isInvincible){
        invincibleTimer -= Time.deltaTime;
        if (invincibleTimer < 0)
            isInvincible = false;
    }
   }

   void FixedUpdate(){
       Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
   }

    public void changeHealth(int amount){
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        StartCoroutine(VisualIndicator(Color.red));
        Debug.Log("Player heatlh: " + currentHealth + "/" + maxHealth);
    }

    private IEnumerator VisualIndicator (Color color){
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
