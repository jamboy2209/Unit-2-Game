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

    int slimesSpawned = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTimer(2f));
    }

    private void Update()
    {
        if (slimesSpawned == 25)
        {
            if(Slime_1.activeInHierarchy == false && Slime_2.activeInHierarchy == false && Slime_3.activeInHierarchy == false)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    IEnumerator SpawnTimer(float seconds)
    {
        int SlimePicker = Random.Range(1, 4);
        Debug.Log(SlimePicker);

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
            StartCoroutine(SpawnTimer(2f));
        }
    }
}
