using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject playButton;

    private void Update()
    {
       // PlaySong();
    }
/*
    public void PlaySong()
    {
        void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.tag == "finger")
            {
                FindObjectOfType<AudioManager>().Play("Ukulele");
            }
        }
    } */
}