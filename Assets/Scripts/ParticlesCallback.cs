using System;
using UnityEngine;

public class ParticlesCallback : MonoBehaviour
{
    public void OnParticleSystemStopped()
    {
        string temp = transform.parent.GetComponent<Gema>().message;
        GameObject.Find("LevelManager").GetComponent<LevelManager>().ShowGemMessage(temp);
        Destroy(transform.parent.gameObject);
    }
}
