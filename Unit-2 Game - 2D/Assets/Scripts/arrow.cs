using Unity.VisualScripting;
using UnityEngine;

public class arrow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;
    float lifeSpan = 5f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
