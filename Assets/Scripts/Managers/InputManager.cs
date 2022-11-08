using System;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityTemplateProjects.Signals;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion
        #region Serialized Variables

        [SerializeField] private bool isReadyForTouch, isFirstTimeTouchTaken;

        #endregion
        #region Private Variables

        #endregion
        #endregion

        #region Event Subscriptions
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void Update()
        {
            if (!isReadyForTouch) return;

            if (Input.GetMouseButtonDown(0))
            {
                InputSignals.Instance.onInputTaken?.Invoke();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                InputSignals.Instance.onInputReleased?.Invoke();
            }
        }

        private void LateUpdate()
        {
            InputSignals.Instance.onDrawLine?.Invoke();
        }

        private void OnPlay()
        {
            isReadyForTouch = true;
        }

        private void OnReset()
        {
            isReadyForTouch = false;
            isFirstTimeTouchTaken = false;
        }
    }
}