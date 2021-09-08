using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalAccess;

public class Human : MonoBehaviour
{
    public ColorEnum colorEnum;

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = Instance.GetColor(colorEnum);
    }
}
