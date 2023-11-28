using System;
using UnityEditor;
using UnityEngine;

namespace _Mathematic.AddSubtract.AddSubtractExample.CurvedMove
{
    public class CurvedMove : MonoBehaviour
    {
        public Transform Body;
        public float UpSpeed;
        public float UpAddSpeed;

        [Space] public float ForwardSpeed;

        private bool _touched;

        private Vector3 _initPosition;
        private float _initUpSpeed;
        private float _initUpAddSpeed;
        private float _initForwardSpeed;

        private void Start()
        {
            _initPosition = Body.position;
            _initUpSpeed = UpSpeed;
            _initUpAddSpeed = UpAddSpeed;
            _initForwardSpeed = ForwardSpeed;
        }

        [ContextMenu("ResetValues")]
        public void ResetValues()
        {
            Body.position = _initPosition;
            UpSpeed = _initUpSpeed;
            UpAddSpeed = _initUpAddSpeed;
            ForwardSpeed = _initForwardSpeed;
            _touched = false;
            this.enabled = false;
        }

        void Update()
        {
            if(_touched) return;
            UpSpeed += UpAddSpeed;
            Body.position += new Vector3(0,UpSpeed,0);

            Body.position += new Vector3(0, 0, ForwardSpeed);

            CheckTouch();
        }

        private void CheckTouch()
        {
            if (Body.position.y < 0.3) _touched = true;
        }
    }
}
