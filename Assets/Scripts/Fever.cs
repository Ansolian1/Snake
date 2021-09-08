using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fever : MonoBehaviour
{
    private int cristallsCount;
    public Text cristallsUI;

    private PickUpManager PickUpManager;
    private CharacterController CharacterController;

    private void Start()
    {
        PickUpManager = GetComponent<PickUpManager>();
        CharacterController = GetComponent<CharacterController>();
    }

    public void AddCristalls(int count)
    {
        cristallsCount += count;
        cristallsUI.text = cristallsCount.ToString();
        if (CheckFever())
        {
            StartCoroutine(StartFever());
        }
    }

    public void NolifyCristalls()
    {
        cristallsCount = 0;
        cristallsUI.text = cristallsCount.ToString();
    }

    private bool CheckFever()
    {
        if (cristallsCount == 30)
        {
            return true;
        }
        return false;
    }

    IEnumerator StartFever()
    {
        PickUpManager.isFever = true;
        CharacterController.StartFever();
        yield return new WaitForSeconds(5f);
        PickUpManager.isFever = false;
        CharacterController.StopFever();
        NolifyCristalls();
    }
}
