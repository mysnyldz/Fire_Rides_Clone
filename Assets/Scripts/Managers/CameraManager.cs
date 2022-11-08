using Cinemachine;
using UnityEngine;
using UnityTemplateProjects.Signals;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serializefield Variables

        [SerializeField] private PlayerManager playerManager;
        [SerializeField] private CinemachineStateDrivenCamera stateDrivenCamera;

        #endregion

        #region Private Variables

        #endregion

        #endregion

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
        }



        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        private void OnPlay()
        {
            CoreGameSignals.Instance.onSetCameraTarget?.Invoke();
        }

        private void OnSetCameraTarget()
        {
            playerManager = FindObjectOfType<PlayerManager>();
            stateDrivenCamera.Follow = playerManager.transform;
        }
    }
}
