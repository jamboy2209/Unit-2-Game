using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    public GameObject levelSelect;
    public GameObject startButton;
    Vector3 position = new Vector3(192f, 767f, 0f);

    public void WhenClicked()
    {
        Instantiate(levelSelect, position, transform.rotation);
        Destroy(startButton);
    }
}
