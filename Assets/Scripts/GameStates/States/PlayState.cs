using UnityEngine;

 

    public class PlayState : GameStateEntity
    {
        private PlayerController _player;
        private CameraController _camera;
       
        public PlayState()
        {
            Debug.Log("Entered play state");
            OnEnter();
        }

        public override void OnEnter()
        {
            SetPlayerProperties();
            SetCameraProperties();
            InitTrafficSystem();

            /*Instantiate Game Objects */ 
            InitRandomCars();

        }

        private void SetPlayerProperties()
        {
            var playerPosition = TrafficSystem.Instance.GetPlayerPosition();
            var playerObj = new GameObject("Player").AddComponent<PlayerController>();
            playerObj.transform.position = playerPosition.position;
            playerObj.transform.rotation = playerPosition.rotation;
           _player = playerObj.GetComponent<PlayerController>();
        }

        private void SetCameraProperties()
        {
            Camera.main.gameObject.AddComponent<CameraController>();
            _camera = Camera.main.gameObject.GetComponent<CameraController>();
            _camera.SetCameraTarget(_player.GetCameraTarget());
        }

        private void InitTrafficSystem()
        {
            TrafficSystem.Instance.GatherWaypoints();
        }

        private void InitRandomCars()
        {
            var carObjects= TrafficSystem.Instance.GetCars();
            foreach(var carpos in carObjects)
            {
                string modelPath = AssetDatabase.Cars.GetRandom();
                var carObj = Instantiate(Resources.Load(modelPath) as GameObject,carpos.GetTransform());
                carObj.AddComponent<AIController>();
                carObj.tag="Car";
                carObj.transform.SetParent(GameObject.Find("npcs").transform);
                carObj.transform.parent=null;
            }
        }

    }
