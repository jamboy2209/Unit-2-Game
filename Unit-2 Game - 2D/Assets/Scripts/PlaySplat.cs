using UnityEngine;

public class PlaySplat : MonoBehaviour
{
    private AudioSource source;
    public AudioClip splat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(splat, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
