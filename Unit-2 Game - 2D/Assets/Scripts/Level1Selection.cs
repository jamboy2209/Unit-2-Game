using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Selection : MonoBehaviour
{
    public void SetLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
}
