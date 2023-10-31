using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LevelGoal : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] public UnityEvent goalReached = new();

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        StartCoroutine(CheckForGoalReached());
        goalReached.AddListener(() => Debug.Log("GoalReached"));
    }

    private IEnumerator CheckForGoalReached()
    {
        yield return new WaitForSeconds(.5f);

        if(Vector3.Distance(this.transform.position, playerTransform.position) < 2.5f)
        {
            goalReached.Invoke();
        }
        else
        {
            StartCoroutine(CheckForGoalReached());
        }
    }

    void OnDestroy()
    {
        goalReached.RemoveAllListeners();
    }
}
