using System;
using UnityEditor;
using UnityEngine;

namespace _Mathematic.MultDiv.MultExample
{
    public class MultRangeExample : MonoBehaviour
    {
        public float Multiplier;

        [Space]
        [Header("Speed")]
        public Transform SpeedTransform;
        [Header("Range")]
        public Transform RangeTransform;
        [Header("Time")]
        public Transform TimeTransform;

        private float _rangeSpeed = 1f;

        public void OnValidate()
        {
            ResetTransform();
            _rangeSpeed = Multiplier;
        }

        private void Start()
        {
            _rangeSpeed *= Multiplier;
        }

        private void ResetTransform()
        {
            SpeedTransform.localPosition = Vector3.zero;
            RangeTransform.localPosition = Vector3.zero;
            TimeTransform.localPosition = Vector3.zero;
        }
        
        void Update()
        {
            SpeedUpdate();
            RangeUpdate();
            TimeUpdate();
        }

        private void SpeedUpdate()
        {
            SpeedTransform.localPosition += Vector3.right * (Multiplier * Time.deltaTime);
            if(Math.Abs(SpeedTransform.localPosition.x) > 5)
                SpeedTransform.localPosition = Vector3.zero;
        }

        private void RangeUpdate()
        {
            RangeTransform.localPosition += Vector3.right * (_rangeSpeed * Time.deltaTime);
            _rangeSpeed -= RangeTransform.localPosition.x * Time.deltaTime;
        }

        private void TimeUpdate()
        {
            TimeTransform.localPosition += Vector3.right * (Time.deltaTime * Multiplier);
            if(Math.Abs(TimeTransform.localPosition.x) > 5)
                TimeTransform.localPosition = Vector3.zero;
        }
    }
}
