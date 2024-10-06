using Cinemachine;
using UnityEngine;

namespace Scenes.Games.Views
{
    public class CameramanView : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cvCamera;

        [Space] [SerializeField]
        private PlayerCtlr playerCtlr;

        public void BindPlayer(PlayerCtlr playerCtlr)
        {
            this.playerCtlr = playerCtlr;

            var mainBasePosition = playerCtlr.MainbaseView.transform.position;
            cvCamera.transform.position = new Vector3(mainBasePosition.x, mainBasePosition.y, cvCamera.transform.position.z);
        }
    }
}