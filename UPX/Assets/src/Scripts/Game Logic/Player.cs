using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] public UnityEvent goalReached = new();

    void OnEnable()
    {
        StartCoroutine(CheckForGoalReached());
    }
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    private IEnumerator CheckForGoalReached()
    {
        yield return new WaitForSeconds(.5f);
        
        GameObject goal = GameObject.FindWithTag("Goal");

        if(goal == null) yield break;

        if(Vector3.Distance(this.transform.position, goal.transform.position) < 2.5f)
        {
            goalReached.Invoke();
            this.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(CheckForGoalReached());
        }
    }
}
