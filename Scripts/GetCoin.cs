using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour {

    public AudioClip Sound;

    public AudioSource Source;

    void Start()
    {
        Source.clip = Sound;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
		{
            ScoreScript.ScoreValue++;
            Destroy(gameObject);
            Source.Play();
        }
    }
}
