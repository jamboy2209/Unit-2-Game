using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    float speed;
    Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if (gameObject.transform.localScale.x == 1)
        {
            speed = 2f;
        } else if (gameObject.transform.localScale.x == 2) 
        {
            speed = 1.5f;
        } else
        {
            speed = 1f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rb2d.position;
        position.x += speed * Time.deltaTime * (-1);

        rb2d.MovePosition(position);
    }
}
