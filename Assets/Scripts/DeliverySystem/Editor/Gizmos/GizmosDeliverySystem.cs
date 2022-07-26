using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class GizmosDeliverySystem 
{

    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(DeliveryLocation _location, GizmoType gizmoType)
    {
        Gizmos.DrawIcon(_location.GetPosition()+new Vector3(0.0f,1f,0.0f), "DeliveryIcon.png", true);
        DrawArrow.ForGizmo(_location.GetPosition(),_location.GetTransform().forward*6.0f,Color.red,2f);

    }

     [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(PickupLocation _location, GizmoType gizmoType)
    {
                DrawArrow.ForGizmo(_location.GetPosition(),_location.GetTransform().forward*6.0f,Color.red,2f);
        Gizmos.DrawIcon(_location.GetPosition()+new Vector3(0.0f,1f,0.0f), "PickupIcon.png", true);
    }   

}
