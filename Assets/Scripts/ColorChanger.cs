using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalAccess;

public class ColorChanger : MonoBehaviour
{
    public ColorEnum colorEnum;
    private Color color;

    public List<ParticleSystem> particles;

    private void Start()
    {
        color = Instance.GetColor(colorEnum);
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
            Instance.playerColorEnum = colorEnum;
        }
    }
}
