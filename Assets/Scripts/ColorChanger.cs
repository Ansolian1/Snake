using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color color;

    public List<ParticleSystem> particles;

    private void Start()
    {
        foreach (var particle in particles)
        {
            particle.startColor = color;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<MeshRenderer>().material.color = color;
        }
    }
}
