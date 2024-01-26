using UnityEngine;

namespace Player
{
    public class BulletController : MonoBehaviour
    {
        public AudioClip clip;
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Enemy"))
            {
                return;
            }
        
            collision.gameObject.SendMessage("ChangeHealth", -1);

            Debug.Log("Hit object " + collision);

            AudioSource.PlayClipAtPoint(clip, this.gameObject.transform.position);
            Destroy(gameObject);

        }
    }
}
