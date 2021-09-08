using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpManager : MonoBehaviour
{
    public bool isFever = false;
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Bomb":
                if (!isFever)
                {
                    RestartLevel();
                }
                Destroy(other.gameObject);
                break;
            case "Cristall":
                GlobalAccess.Instance.fever.AddCristalls(10);
                Destroy(other.gameObject);
                break;
            case "Human":
                if (GlobalAccess.Instance.playerColorEnum == other.GetComponent<Human>().colorEnum || isFever)
                {
                    GlobalAccess.Instance.score.AddScore(1);
                    Destroy(other.gameObject);
                }
                else
                {
                    RestartLevel();
                }
                break;
            default:
                break;
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
