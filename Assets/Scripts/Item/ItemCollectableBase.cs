using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    
    public string compareTag = "Player";
    public float timeToHide = 1.8f;
    public ParticleSystem coinCollect;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        if (graphicItem != null)
        { graphicItem.SetActive(false); }
        Invoke(nameof(HideObject), timeToHide);
        if (coinCollect != null) coinCollect.Play();

        //AUDIO
        if (coinCollect != null) coinCollect.Play();
        if (audioSource != null) audioSource.Play();

    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

 



}
