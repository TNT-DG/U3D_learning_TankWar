using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

    private SpriteRenderer sr;

    public Sprite brokenSprite;
    public GameObject explosionPrefab;
    public AudioClip dieAudio;

	// Use this for initialization
	void Start () {
        sr = gameObject.GetComponent<SpriteRenderer>();
	}

    public void Die()
    {
        sr.sprite = brokenSprite;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        PlayerManager.Instance.isDefeat = true;
        AudioSource.PlayClipAtPoint(dieAudio, transform.position);
    }
}
