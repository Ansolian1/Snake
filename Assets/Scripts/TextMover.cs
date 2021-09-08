using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMover : MonoBehaviour
{
    public float destroyTime = 3f;
    public float textSpeed = 2f;
    void Start()
    {
        StartCoroutine(DestroyText());
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * textSpeed);
    }

    IEnumerator DestroyText()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
