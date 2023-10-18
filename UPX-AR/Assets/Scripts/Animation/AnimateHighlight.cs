using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateHighlight : MonoBehaviour
{
    [SerializeField] private float animationTime = .5f;
    [SerializeField] private float startScale = 0;
    [SerializeField] private float targetScale = 1;

    public void OnEnable()
    {
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        float t = 0;

        Vector3 _startScale = new Vector3(startScale, startScale, startScale);
        Vector3 _targetScale = new Vector3(targetScale, targetScale, targetScale);

        while(t <= 1)
        {
            t += Time.deltaTime/animationTime;

            transform.localScale = Vector3.Lerp(_startScale, _targetScale, t);

            yield return null;
        }
    }
}
