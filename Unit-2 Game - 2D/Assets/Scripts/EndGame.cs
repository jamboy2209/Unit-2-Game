using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    GameObject[] slimes;
    bool endGame = false;
    

    // Update is called once per frame
    void Update()
    {
        slimes = GameObject.FindGameObjectsWithTag("Slime");

        if (slimes.Length == 0)
        {
            GameObject[] Deactivate = GameObject.FindGameObjectsWithTag("deactivate");
            Transform[] allObjects = GameObject.FindObjectsByType<Transform>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            Transform[] inactive = allObjects.Where(sr => !sr.gameObject.activeInHierarchy).ToArray();

            foreach (GameObject deactivate in Deactivate)
            {
                deactivate.SetActive(false);
            }

            foreach (var sr in inactive)
            {
                sr.gameObject.SetActive(true);
            }

            endGame = true;
        }

        if(endGame == true)
        {
            gameObject.SetActive(false);
        }
    }
}
