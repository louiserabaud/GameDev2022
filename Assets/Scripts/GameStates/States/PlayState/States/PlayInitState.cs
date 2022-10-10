using UnityEngine;


public class PlayInitState : PlayBaseState
{
    public override void OnEnter(PlayStateManager manager)
    {
        SetPlayerProperties();
        SetCameraProperties();
        /*Instantiate Game Objects */ 
        InitRandomCars();
    }
    public override void OnUpdate(PlayStateManager manager)
    {

    }
    public override void OnExit(PlayStateManager manager)
    {

    }

    private void SetPlayerProperties()
    {
        Transform playerPosition = TrafficSystem.Instance.GetPlayerPosition();
        PlayerController playerObj = new GameObject("Player").AddComponent<PlayerController>();
        playerObj.transform.position = playerPosition.position;
        playerObj.transform.rotation = playerPosition.rotation;
    }
    private void  SetCameraProperties()
    {
        Camera.main.gameObject.AddComponent<CameraController>();
        CameraController _camera = Camera.main.gameObject.GetComponent<CameraController>();
        PlayerController _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _camera.SetCameraTarget(_player.GetCameraTarget());
    }
    private void InitRandomCars()
    {
        /*var carObjects= TrafficSystem.Instance.GetCars();
        foreach(var carpos in carObjects)
        {
            string modelPath = AssetDatabase.Cars.GetRandom();
            Car _car = new GameObject("Waypoint" + waypointCount,typeof(Car));
            var carObj = Instantiate(Resources.Load(modelPath) as GameObject,carpos.GetTransform());
            carObj.AddComponent<AIController>();
            carObj.tag="Car";
            carObj.transform.SetParent(GameObject.Find("npcs").transform);
            carObj.transform.parent=null;
        }*/
    }
}