using System.Collections.Generic;
using UnityEngine;

namespace _Mathematic.Graphs.Momentum
{
    [ExecuteInEditMode]
    public class Momentum : MonoBehaviour
    {
        public Transform[] Nodes;

        public float Power;
        public float FrictionValue;
    
        private List<NodeData> _nodes = new List<NodeData>();
        private float _maxLenght;

        [ContextMenu("FillNodes")]
        private void FillNodes()
        {
            foreach (var node in Nodes)
            {
                _nodes.Add(new NodeData(node.position.y, node));
                if (node.position.y > _maxLenght) _maxLenght = node.position.y;
            }
        }

        private void Update()
        {
            var momentum = _maxLenght * Power;
            for (int i = 0; i < _nodes.Count; i++)
            {
                var pos = _nodes[i].InitPosition;
                pos.x = Mathf.Lerp(0, momentum, Mathf.Pow(_nodes[i].Lenght/_maxLenght, FrictionValue));
                pos.y = Mathf.Sqrt(_nodes[i].Lenght * _nodes[i].Lenght - pos.x * pos.x);
                _nodes[i].NodeTransform.position = pos;
                if (i > 0)
                {
                    _nodes[i].NodeTransform.LookAt(_nodes[i-1].NodeTransform);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            foreach (var node in _nodes)
            {
                Gizmos.DrawLine(node.NodeTransform.position,node.NodeTransform.position + new Vector3(Power*node.Lenght*2f,0f,0f));
            }
        }
    }

    public class NodeData
    {
        public float Lenght;
        public Transform NodeTransform;
        public Vector3 InitPosition;

        public NodeData(float lenght, Transform myTransform)
        {
            Lenght = lenght;
            NodeTransform = myTransform;
            InitPosition = myTransform.position;
        }
    }
}