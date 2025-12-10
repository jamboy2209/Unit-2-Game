using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    string size;
    public GameObject SmallSlime;
    public GameObject MediumSlime;
    public Transform Spawnpoint_1;
    public Transform Spawnpoint_2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameObject.transform.localScale.x == 1)
        {
            size = "Small";
        }
        else if (gameObject.transform.localScale.x == 2)
        {
            size = "Medium";
        }
        else if (gameObject.transform.localScale.x == 3)
        {
            size = "Large";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            if (size == "Small")
            {
                Destroy(gameObject);
            } 
            else if (size == "Medium")
            {
                Instantiate(SmallSlime, Spawnpoint_1.position, Spawnpoint_1.rotation);
                Instantiate(SmallSlime, Spawnpoint_2.position, Spawnpoint_2.rotation);
                Destroy(gameObject);
            }
            else if (size == "Large")
            {
                Instantiate(MediumSlime, Spawnpoint_1.position, Spawnpoint_1.rotation);
                Instantiate(MediumSlime, Spawnpoint_2.position, Spawnpoint_2.rotation);
                Destroy(gameObject);
            }
        }

    }
}
