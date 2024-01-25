using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;
    
    private Vector2 movement;

    public int maxHealth = 50;
    private int currentHealth;

    public float timeInvincible = 2.0F;
    private float invincibleTimer;
    private bool isInvincible;

    
   void Start()
   {
    currentHealth = maxHealth;
    invincibleTimer = 0;
    isInvincible = false;
   }
    
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (isInvincible){
        invincibleTimer -= Time.deltaTime;
        if (invincibleTimer < 0)
            isInvincible = false;
    }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (speed * Time.fixedDeltaTime));
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
