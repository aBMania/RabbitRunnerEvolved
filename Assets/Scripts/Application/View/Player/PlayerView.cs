using Attributes;
using UnityEngine;

namespace Application.View.Player
{
    public class PlayerView : RabbitApplicationElement
    {
        public GameObject Prefab;

        private Model.Player.Player _playerModel;

        [ShowOnly, SerializeField]
        private GameObject _playerInstance;

        public void Awake()
        {
            _playerModel = App.Model.Player;

            App.Controller.GameManager.OnGameStart += SpawnPlayer;

            App.Model.Player.OnPlayerUpdated += OnPlayerUpdated;
        }

        private void OnPlayerUpdated()
        {
            if (_playerInstance == null) return;

            _playerInstance.transform.rotation = _playerModel.Rotation;
            _playerInstance.transform.position = _playerModel.Position;
        }

        public void SpawnPlayer()
        {
            _playerInstance = Instantiate(Prefab);

            _playerInstance.transform.parent = transform;
            _playerInstance.name = "Player Instance";
        }

        public void DestroyPlayer()
        {
            Destroy(_playerInstance);
        }

        public Model.Player.Player PlayerModel
        {
            get { return _playerModel; }
        }
    }
}