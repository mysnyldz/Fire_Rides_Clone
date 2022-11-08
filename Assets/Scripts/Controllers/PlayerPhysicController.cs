using System;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class PlayerPhysicController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("CenterPoint"))
            {
                LevelSignals.Instance.onNextlevel.Invoke();
            }
        }
    }
}