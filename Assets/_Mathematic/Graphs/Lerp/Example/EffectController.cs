using System;
using UnityEngine;

namespace _Mathematic.Graphs.Lerp.Example
{
    [ExecuteInEditMode]
    public class EffectController : MonoBehaviour
    {
        public Transform CharacterTransform;
        public Renderer GlowSphereRenderer;
        public Transform GlowSphereTransform;
        public float GlowIntesityMin;
        public float GlowIntesityMax;
        public Animation Anim;
    
        [Range(0,1)]
        public float Value;
        public float EffectStartDistance;

        public bool IsCharacterIn;

        private float _addValue;

        void Update()
        {
            float glowSphereIntensity = Mathf.Lerp(GlowIntesityMin + _addValue,GlowIntesityMax, Value) ;
            GlowSphereRenderer.material.SetFloat("_Mult", glowSphereIntensity);

            CharacterTransform.position = new Vector3(7 - Value * 7, 0, 0);
            if (Value > EffectStartDistance && !IsCharacterIn)
            {
                Anim.Play();
                IsCharacterIn = true;
                _addValue = 0.3f;
            }

            if (!IsCharacterIn)
            {
                GlowSphereTransform.position = Vector3.zero;
                _addValue = 0f;
                return;
            }

            GlowSphereTransform.position += Vector3.up * (Mathf.Sin(Time.time) * 0.002f);
            GlowSphereRenderer.material.SetFloat("_Mult", glowSphereIntensity + Mathf.Sin(Time.time)*0.05f);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(CharacterTransform.position + Vector3.up * 0.5f,Vector3.one);
        }
    }
}
