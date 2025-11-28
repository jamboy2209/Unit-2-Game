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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        Debug.Log(direction);

        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }

        for (int i = 0; i < numOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }

    void shoot()
    {
        GameObject newArrow = Instantiate(arrow, spawnPoint.position, spawnPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().linearVelocity = transform.right * power;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)spawnPoint.position + (direction.normalized * power * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }

}

