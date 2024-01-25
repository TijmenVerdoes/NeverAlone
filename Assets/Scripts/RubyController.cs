using UnityEngine;

public class RubyController : MonoBehaviour
{
    public int maxHealth = 5;
    
    public int health => currentHealth;

    private int currentHealth;
    
    private Rigidbody2D _rigidbody2D;
    private float _horizontal;
    private float _vertical;
    
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        ChangeHealth(5);
    }

    // Update is called once per frame
    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        var position = _rigidbody2D.position;
        position.x += 3.0f * _horizontal * Time.deltaTime;
        position.y += 3.0f * _vertical * Time.deltaTime;
        
        _rigidbody2D.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth, maxHealth);
    }
}

