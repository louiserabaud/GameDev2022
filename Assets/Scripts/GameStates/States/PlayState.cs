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
        }

        private void SetPlayerProperties()
        {
            var playerObj = new GameObject("Player").AddComponent<PlayerController>();
           _player = playerObj.GetComponent<PlayerController>();
        }

        private void SetCameraProperties()
        {
            Camera.main.gameObject.AddComponent<CameraController>();
            _camera = Camera.main.gameObject.GetComponent<CameraController>();
            _camera.SetCameraTarget(_player.GetCameraTarget());
            Debug.Log("cam props");
        }
    }
