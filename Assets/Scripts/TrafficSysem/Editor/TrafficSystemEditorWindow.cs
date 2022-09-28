using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;


public class TrafficSystemEditorWindow : EditorWindow
{
    [SerializeField] private GameObject trafficSystemObject;
    [SerializeField] private TrafficSystem trafficSystemScript;

    public static int nIntersection =0;
    private bool isInit = false;

    [MenuItem("Window/TafficSystem Editor")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        TrafficSystemEditorWindow window = (TrafficSystemEditorWindow)EditorWindow.GetWindow(typeof(TrafficSystemEditorWindow));
       // open the editor window
        window.Show();
    }


    void OnGUI() 
    {
        if (GameObject.FindGameObjectWithTag("TrafficSystem") == null  )
            CreateTrafficSystem();

        DrawUILine(Color.clear);
        //SerializedObject obj = new SerializedObject(this);
        //(obj.FindProperty("trafficSystemScript"));
        DrawButtons();
        //obj.ApplyModifiedProperties();
        
    }

   

    void CreateTrafficSystem()
    {
        if(isInit)
            return;
        
        trafficSystemObject = new GameObject("TrafficSystem",typeof(TrafficSystem));
        trafficSystemObject.tag = "TrafficSystem";
        //create waypoints holder
        var waypoints = new GameObject("Waypoints");
        //create intersections holder
        var intersections = new GameObject("Intersections");
        // set the holders as children to the traffic system object
        waypoints.transform.SetParent(trafficSystemObject.gameObject.transform,false);
        intersections.transform.SetParent(trafficSystemObject.gameObject.transform,false);
        //assign the traffic system script to its reference
        trafficSystemScript = trafficSystemObject.GetComponent<TrafficSystem>();
        //Instantiate(trafficSystemObject);
        isInit = true;
    }

    void DrawButtons()
    {
        if(Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Waypoint>())
        {
            if(GUILayout.Button("Extrude Waypoint"))
            {
                ExtrudeWaypoint();
            }
            if(GUILayout.Button("Merge waypoints"))
            {
                MergePoints();
            }
            if(GUILayout.Button("Add a new branch"))
            {
                CreateWaypointBranch();
            }
        }
        
        else
        {
            if(GUILayout.Button("Create a Waypoint"))
            {
                CreateWaypoint();
            }
            if(GUILayout.Button("Create an Intersection"))
            {
                CreateIntersection();
            }
        }
    }

    public void CreateWaypoint()
    {
        var waypoint = new GameObject("Waypoint " + GetWaypointsCount(),typeof(Waypoint));
        waypoint.gameObject.tag="Waypoint";
        waypoint.transform.SetParent(trafficSystemObject.transform.GetChild(0),false);
        AddWaypoint(waypoint.GetComponent<Waypoint>());
        Selection.activeGameObject = waypoint;
    }

      void ExtrudeWaypoint()
    {
        var parent = Selection.activeGameObject.GetComponent<Waypoint>();
        CreateWaypoint();
        var waypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        waypoint.parent = parent;
        parent.next.Add(waypoint);
        waypoint.transform.position = parent.transform.position;
        waypoint.transform.forward = parent.transform.forward;
    }

    public void MergePoints()
    {
        if(!(Selection.transforms.Length==2 && Selection.transforms[0].tag=="Waypoint" && Selection.transforms[1].tag=="Waypoint"))
            {
                Debug.Log("not enough or too many obj selected");
                return;
            }
        Waypoint parentPoint = Selection.transforms[0].GetComponent<Waypoint>();
        Waypoint childPoint = Selection.transforms[1].GetComponent<Waypoint>();

        parentPoint.next.Add(childPoint);
        childPoint.parent = parentPoint;
    }

    TrafficLight CreateTrafficLight(GameObject intersection,Vector3 position)
    {
        GameObject obj = (GameObject)Resources.Load("TrafficLight");
        var lights = Instantiate(obj,position,intersection.transform.rotation);
        lights.gameObject.transform.position = new Vector3(0,0,0);
        lights.transform.SetParent(intersection.gameObject.transform,false);
        lights.name="TrafficLight";
        lights.tag="TrafficLight";
        return lights.GetComponent<TrafficLight>();
    }

    void CreateIntersection()
    {
        var trafficLights = new List<TrafficLight>();
        var locations = new Vector3[4]
        {
            new Vector3(3,0,-5),
            new Vector3(-5,0,-3),
            new Vector3(-3,0,5),
            new Vector3(5,0,3)
        };
        var intersection = new GameObject("Intersection " + nIntersection,typeof(Intersection));
        intersection.transform.SetParent(trafficSystemObject.gameObject.transform.GetChild(1),false);
        intersection.gameObject.tag = "Intersection";
        intersection.gameObject.transform.position = new Vector3(0,0,0);
        for(int i=0;i<4;i++)
        {
            var lights = CreateTrafficLight(intersection,locations[i]);
        } 
    }

    void CreateWaypointBranch()
    {
        var waypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        CreateWaypoint();
        var nextPoint = Selection.activeGameObject.GetComponent<Waypoint>();
        waypoint.next.Add(nextPoint);
        nextPoint.parent = waypoint;
        Selection.activeGameObject = waypoint.gameObject;
        nextPoint.transform.position = waypoint.transform.position;
        nextPoint.transform.forward = waypoint.transform.forward*1.5f;
        
    }

  

    public static void DrawUILine(Color color, int thickness = 1, int padding = 20)
    {
        Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding+thickness));
        r.height = thickness;
        r.y+=padding/2;
        r.x-=2;
        r.width +=6;
        EditorGUI.DrawRect(r, color);
    }

    private int GetWaypointsCount()
    {
        return trafficSystemScript.GetWaypointsCount();
    }

    private void AddWaypoint(Waypoint waypoint)
    {
        trafficSystemScript.AddWaypoint(waypoint);
    }

    


    
}
