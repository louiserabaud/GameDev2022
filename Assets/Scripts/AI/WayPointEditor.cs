using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class WaypointEditor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(Waypoint waypoint, GizmoType gizmoType)
    {
        if((gizmoType & GizmoType.Selected)!=0)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.yellow * 0.5f;
        }

        Gizmos.DrawSphere(waypoint.transform.position,1.0f);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(waypoint.transform.position+(waypoint.transform.right * waypoint.width/2),
        waypoint.transform.position - (waypoint.transform.right* waypoint.width/2));

        /*if(waypoint._previousWaypoint != null)
        {
            Gizmos.color = Color.red;
            Vector3 offset = waypoint.transform.right * waypoint.width/2f;
            Vector3 offsetTo = waypoint._previousWaypoint.transform.right * waypoint._previousWaypoint.width/2f;
            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint._previousWaypoint.transform.position+offsetTo);
        }
      
         if(waypoint._nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Vector3 offset = waypoint.transform.right * -waypoint.width/2f;
            Vector3 offsetTo = waypoint._nextWaypoint.transform.right * -waypoint._nextWaypoint.width/2f;
            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint._nextWaypoint.transform.position+offsetTo);
        }*/
        
         if(waypoint.neighbours.Count>0)
        {
            foreach(var point in waypoint.neighbours)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(waypoint.transform.position, point.transform.position);
            }
        }
    }
}
