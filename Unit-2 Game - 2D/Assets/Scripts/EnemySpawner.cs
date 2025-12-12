using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Slime_1;
    public GameObject Slime_2;
    public GameObject Slime_3;
    public Transform spawnPoint;

    public GameObject endGame;

    int slimesSpawned = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTimer(1f));
    }

    IEnumerator SpawnTimer(float seconds)
    {
        int SlimePicker = Random.Range(1, 4);

        if (SlimePicker == 1)
        {
            Instantiate(Slime_1, spawnPoint.position, spawnPoint.rotation);
        }
        else if (SlimePicker == 2)
        {
            Instantiate(Slime_2, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Instantiate(Slime_3, spawnPoint.position, spawnPoint.rotation);
        }

        yield return new WaitForSeconds(seconds);

        slimesSpawned += 1;

        if (slimesSpawned < 25)
        {
            StartCoroutine(SpawnTimer(1f));
        }

        if (slimesSpawned == 25)
        {
            Instantiate(endGame, transform.position, Quaternion.identity);
        }
    }
}
