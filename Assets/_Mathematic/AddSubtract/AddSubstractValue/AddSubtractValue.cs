using TMPro;
using UnityEngine;

namespace _Mathematic.AddSubstract.AddSubstractValue
{
    [ExecuteInEditMode]
    public class AddSubtractValue : MonoBehaviour
    {
        public TextMeshPro TMP;
        public float MainValue;
        public float AddValue;
        [Space]
        [Header("Size")]
        public Transform MainValueTransform;
        public Transform AddValueTransform;
        public Transform ResultValueTransform;
        [Space]
        [Header("Lenght")]
        public Transform MainValueTransformLenght;
        public Transform AddValueTransformLenght;
        public Transform ResultValueTransformLenght;
        
        [Space]
        [Header("Position")]
        public Transform MainValueTransformPosition;
        public Transform AddValueTransformPosition;
        public Transform ResultValueTransformPosition;
        
        void Update()
        {
            string value = $"{MainValue} + {AddValue} = {(MainValue + AddValue)}";
            if (AddValue < 0)
            {
                value = $"{MainValue} + ({AddValue}) = {(MainValue + AddValue)}";
            }

            TMP.text = value;

            MainValueTransform.localScale = Vector3.one * MainValue;
            AddValueTransform.localScale = Vector3.one * AddValue;
            ResultValueTransform.localScale = Vector3.one * (MainValue + AddValue);
            
            MainValueTransformLenght.localScale = new Vector3(MainValue, 1,1);
            AddValueTransformLenght.localScale = new Vector3(AddValue,1,1);
            ResultValueTransformLenght.localScale = new Vector3(MainValue + AddValue,1,1);

            SetPosition(MainValueTransformPosition, MainValue);
            SetPosition(AddValueTransformPosition, AddValue);
            SetPosition(ResultValueTransformPosition, MainValue + AddValue);
        }

        private void SetPosition(Transform trans, float value)
        {
            var pos = trans.position;
            pos.y = value;
            trans.position = pos;
        }
    }
}
