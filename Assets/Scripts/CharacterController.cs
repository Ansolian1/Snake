using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public bool isFever = false;
    public float feverXPosition = 0.3f;

    public float sideSpeed = 3f;
    public float forwardSpeed = 3f;

    public float leftBorder = -3.5f;
    public float rightBorder = 4f;

    public Transform SnakeHead;
    public float elementDistance;

    public List<Transform> snakeElements = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        positions.Add(SnakeHead.position);

        foreach (var snakeElement in snakeElements)
        {
            positions.Add(snakeElement.position);
        }
    }

    private void Update()
    {
        float distance = (SnakeHead.position - positions[0]).magnitude;

        if (distance > elementDistance)
        {
            Vector3 direction = (SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * elementDistance);
            positions.RemoveAt(positions.Count - 1);

            distance -= elementDistance * (int)(distance / elementDistance);
        }

        for (int i = 0; i < snakeElements.Count; i++)
        {
            snakeElements[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / elementDistance);
            snakeElements[i].LookAt(positions[i + 1], Vector3.up);
        }
    }

    void FixedUpdate()
    {
        if (isFever)
        {
            rb.rotation = Quaternion.identity;
            transform.rotation = Quaternion.identity;

            return;
        }


        rb.velocity = Vector3.zero;
        rb.velocity = Vector3.forward * forwardSpeed;


        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float targetPos = 0f;
            if (Physics.Raycast(ray, out hit))
            {
                targetPos = hit.point.x;
                if (Mathf.Abs(transform.position.x - targetPos) < 0.3f)
                {
                    return;
                }

                if (targetPos < transform.position.x && transform.position.x > leftBorder)
                {
                    rb.velocity = new Vector3(-sideSpeed, 0f, forwardSpeed);
                    return;
                }
                else if (transform.position.x < rightBorder)
                {
                    rb.velocity = new Vector3(sideSpeed, 0f, forwardSpeed);
                    return;
                }
            }
            else
            {
                if (Input.mousePosition.x < Screen.width / 2 && transform.position.x > leftBorder)
                {
                    rb.velocity = new Vector3(-sideSpeed, 0f, forwardSpeed);
                    return;
                }
                else if (transform.position.x < rightBorder)
                {
                    rb.velocity = new Vector3(sideSpeed, 0f, forwardSpeed);
                    return;
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > leftBorder)
        {
            rb.velocity = new Vector3(-sideSpeed, 0f, forwardSpeed);
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < rightBorder)
        {
            rb.velocity = new Vector3(sideSpeed, 0f, forwardSpeed);
            return;
        }

        rb.rotation = Quaternion.identity;
        transform.rotation = Quaternion.identity;
    }

    public void StartFever()
    {
        isFever = true;
        forwardSpeed *= 3;
        sideSpeed *= 3;
        StartCoroutine(MoveToFeverPosition());
    }

    public void StopFever()
    {
        isFever = false;
        forwardSpeed /= 3;
        sideSpeed /= 3;
    }

    IEnumerator MoveToFeverPosition()
    {
        if(transform.position.x < feverXPosition)
        {
            rb.velocity = new Vector3(sideSpeed, 0f, forwardSpeed);
            while (transform.position.x < feverXPosition)
            {
                yield return null;
            }
            rb.velocity = Vector3.forward * forwardSpeed;
        }
        else
        {
            rb.velocity = new Vector3(-sideSpeed, 0f, forwardSpeed);
            while (transform.position.x > feverXPosition)
            {
                yield return null;
            }
            rb.velocity = Vector3.forward * forwardSpeed;
        }
    }
}
