
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var controller = other.GetComponent<RubyController>();

        if (controller == null || controller.health >= controller.maxHealth)
        {
            return;
        }
        
        controller.ChangeHealth(-1);
        Destroy(gameObject);
    }
}
