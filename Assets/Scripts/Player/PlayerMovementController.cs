using System.Collections;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        public float speed = 5f;
        public Rigidbody2D rb;
        public Camera cam;
        public Animator animator;
        public AudioClip playerHurtClip;
        public AudioClip playerDeadClip;

        private Vector2 movement;

        public int maxHealth;
        private int currentHealth;

        public float timeInvincible = 2.0F;
        private float invincibleTimer;
        private bool isInvincible;


        private void Start()
        {
            currentHealth = maxHealth;
            invincibleTimer = 0;
            isInvincible = false;
        }

        private void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (movement.x != 0 || movement.y != 0)
            {
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
            }
            
            if (isInvincible)
            {
                invincibleTimer -= Time.deltaTime;

                if (invincibleTimer < 0)
                {
                    isInvincible = false;
                }
            }
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * (speed * Time.fixedDeltaTime));
        }

        public void ChangeHealth(int amount)
        {
            if (amount < 0)
            {
                if (isInvincible)
                    return;

                isInvincible = true;
                invincibleTimer = timeInvincible;
                AudioSource.PlayClipAtPoint(playerHurtClip, gameObject.transform.position);
            }

            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            if (currentHealth == 0)
            {
                AudioSource.PlayClipAtPoint(playerDeadClip, gameObject.transform.position);
            }
            StartCoroutine(VisualIndicator(Color.red));
            Debug.Log("Player heatlh: " + currentHealth + "/" + maxHealth);
            Healthbar.instance.SetValue(currentHealth, maxHealth);
        }

        private IEnumerator VisualIndicator(Color color)
        {
            GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(0.15f);
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}