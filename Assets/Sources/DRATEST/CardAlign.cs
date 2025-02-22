using System.Collections.Generic;
using UnityEngine;

namespace DragRoot
{
    [ExecuteInEditMode]
    public class CardAlign : MonoBehaviour
    {
        [SerializeField] List<Drag> _objects;

        List<Drag> _ailne = new List<Drag>();
        public float width = 1f;

        void Update()
        {
            _ailne.Clear();

            foreach (var obj in _objects)
            {
                if (!obj.IsDragging && obj.IsActive && !obj.IsSloted)
                {
                    _ailne.Add(obj);
                }
            }

            if (_ailne.Count == 0)
            {
                return;
            }

            float totalWidth = width * (_ailne.Count - 1);
            float startX = -totalWidth / 2f;

            for (var i = 0; i < _ailne.Count; i++)
            {
                _ailne[i].transform.localPosition = Vector2.Lerp(_ailne[i].transform.localPosition, new Vector3(startX + i * width, 0, 0), 0.1f);
            }
        }
    }
}
