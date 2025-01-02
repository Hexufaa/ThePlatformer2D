using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    
    public string compareTag = "Player";
    public float timeToHide = 3f;
    public ParticleSystem coinCollect;
    public GameObject graphicItem;

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
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }
    

}
