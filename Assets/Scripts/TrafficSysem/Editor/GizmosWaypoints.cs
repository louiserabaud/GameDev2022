using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class GizmosWaypoints 
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(Waypoint waypoint, GizmoType gizmoType)
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(waypoint.GetPosition(),0.5f);
        if(waypoint.next.Count>1)
        {
            foreach(var nextpoint in waypoint.next)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(waypoint.transform.position, nextpoint.transform.position);
            }
        }
    }

}
