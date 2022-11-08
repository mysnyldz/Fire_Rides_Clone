using System;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class PlayerGrapplingController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables



        #endregion

        #region Serializefield Variables

        [SerializeField] private PlayerManager manager;

        #endregion

        #region Private Variables

        private Vector3 _grapplePoint;
        private LineRenderer _lineRenderer;
        private Transform _grappleShootPoint;
        private LayerMask _layerMask;
        private float _maxDistance = 100f;
        private SpringJoint _joint;

        private void Start()
        {
            _grappleShootPoint = manager.grappleShootPoint;
            _lineRenderer = manager.lineRenderer;
            _layerMask = manager.layerMask;
        }

        #endregion

        #endregion


        public void GrappleNode()
        {
            RaycastHit hit;
            if (Physics.Raycast(_grappleShootPoint.position,_grappleShootPoint.forward,out hit,_maxDistance,_layerMask.value,QueryTriggerInteraction.Ignore))
            {
                _grapplePoint = hit.point;
                _joint = manager.gameObject.AddComponent<SpringJoint>();

                _joint.autoConfigureConnectedAnchor = false;
                _joint.connectedAnchor = _grapplePoint + (new Vector3(0, _grapplePoint.y, 0));

                float distanceFromPoint = Vector3.Distance(manager.transform.position, _grapplePoint);

                _joint.maxDistance = distanceFromPoint * 0.8f;
                _joint.minDistance = distanceFromPoint * 0.25f;


                _joint.spring = 5f;
                _joint.damper = 10f;
                _joint.massScale = 5f;

                _lineRenderer.positionCount = 2;
            }
        }

        public void ReleaseNode()
        {
            _lineRenderer.positionCount = 0;
            Destroy(_joint);
        }

        public void DrawLine()
        {
            if (!_joint) return;
            _lineRenderer.SetPosition(0,_grappleShootPoint.position);
            _lineRenderer.SetPosition(1,_grapplePoint);
        }
    }
}