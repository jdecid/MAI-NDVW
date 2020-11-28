using System;
using UnityEngine;

class Utils
{
    public static bool IsTargetVisible(GameObject player, GameObject target, float fieldOfView, float distance)
    {
        Vector3 sourcePosition = player.transform.position;
        Vector3 targetPosition = target.transform.position;
        Vector3 direction = targetPosition - sourcePosition;
        float angle = Vector3.Angle(direction, player.transform.forward);

        if (Math.Abs(angle) <= fieldOfView)
        {
            RaycastHit hit;
            if (Physics.Raycast(sourcePosition, direction, out hit, distance))
            {
                Debug.DrawRay(sourcePosition, direction * hit.distance, Color.yellow);
            
                if (hit.collider.gameObject.name == target.name)
                {
                    Debug.Log($"Did Hit {target.tag}{target.name}");
                    return true;
                }
            }
        }

        return false;
    }
}