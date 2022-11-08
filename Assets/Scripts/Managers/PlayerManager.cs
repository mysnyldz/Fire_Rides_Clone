using System;
using Controllers;
using Signals;
using UnityEngine;
using UnityTemplateProjects.Signals;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public LineRenderer lineRenderer;
        public Transform grappleShootPoint;
        public LayerMask layerMask;

        #endregion

        #region Serializefield Variables

        [SerializeField] private PlayerGrapplingController playerGrapplingController;

        #endregion

        #region Private Variables

        #endregion

        #endregion

        #region Event Subscription

        private void Awake()
        {
        }


        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputTaken += OnInputTaken;
            InputSignals.Instance.onInputReleased += OnInputRelease;
            InputSignals.Instance.onDrawLine += OnDrawLine;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
            // LevelSignals.Instance.onLevelFailed += OnLevelFailed;
            //  ScoreSignals.Instance.onSetTotalScore += OnSetScoreText;
        }


        private void UnsubscribeEvents()
        {
            InputSignals.Instance.onInputTaken -= OnInputTaken;
            InputSignals.Instance.onInputReleased -= OnInputRelease;
            InputSignals.Instance.onDrawLine -= OnDrawLine;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            // LevelSignals.Instance.onLevelFailed -= OnLevelFailed;
            // ScoreSignals.Instance.onSetTotalScore -= OnSetScoreText;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnInputTaken()
        {
            playerGrapplingController.GrappleNode();
        }

        private void OnInputRelease()
        {
            playerGrapplingController.ReleaseNode();
        }

        private void OnDrawLine()
        {
            playerGrapplingController.DrawLine();
        }

        private void OnReset()
        {
        }

        private void OnPlay()
        {
            // playerGrapplingController.IsReadyToPlay(true);
        }
    }
}