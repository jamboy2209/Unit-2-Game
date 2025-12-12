using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowSpawner : MonoBehaviour
{
    public GameObject arrow;
    public float power;
    public Transform spawnPoint;
    Vector2 direction;

    public GameObject point;
    GameObject[] points;
    public int numOfPoints;
    public float spaceBetweenPoints;

    private AudioSource source;
    public AudioClip arrowSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();

        points = new GameObject[numOfPoints];
        for (int i = 0; i < numOfPoints; i++)
        {
            points[i] = Instantiate(point, spawnPoint.position, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 spawnerPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - spawnerPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            source.PlayOneShot(arrowSound, 1.0f);
            Shoot();
        }

        for (int i = 0; i < numOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, spawnPoint.position, spawnPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().linearVelocity = transform.right * power;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)spawnPoint.position + (power * t * direction.normalized) + (t * t) * 0.5f * Physics2D.gravity;
        return position;
    }

}

