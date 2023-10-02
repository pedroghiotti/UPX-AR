using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerAvatar : MonoBehaviour
{
    [SerializeField] private float moveDist = 5;
    [SerializeField] private float moveTime = 2;
    [SerializeField] private float rotDist = 90;
    [SerializeField] private float rotTime = 2;

    [ContextMenu("Forward")]
    public async Task MoveForward()
    {
        float t = 0;
        Vector3 stPos = transform.position;
        Vector3 tgPos = stPos + transform.forward * moveDist;

        while(t < 1)
        {
            t += Time.deltaTime * (1 / moveTime);
            transform.position = Vector3.Lerp(stPos, tgPos, t);
            await Task.Yield();
        }
    }

    [ContextMenu("Turn")]
    public async Task TurnRight()
    {
        float t = 0;
        float rotY;
        float stRotY = transform.rotation.eulerAngles.y;
        float tgRotY = stRotY + rotDist;

        while(t < 1)
        {
            t += Time.deltaTime * (1 / rotTime);
            rotY = Mathf.Lerp(stRotY, tgRotY, t);
            transform.rotation = Quaternion.Euler(0, rotY, 0);
            await Task.Yield();
        }
    }

    void OnDrawGizmos ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 3);
    }
}
