using CMS.DragSystem;
using System.Collections.Generic;
using UnityEngine;

namespace CMS.CardSystem
{
    [ExecuteInEditMode]
    public class CardAlign : MonoBehaviour
    {
        [SerializeField] List<Dragable> _objects;

        List<Dragable> _ailne = new List<Dragable>();
        public float width = 1f;

        void Update()
        {
            _ailne.Clear();

            foreach (var obj in _objects)
            {
                if (!obj.Dragging && obj.IsSloted == false)
                {
                    _ailne.Add(obj);
                }
            }

            var centerOffset = width * (_ailne.Count * 0.5f - 0.5f);

            for (var i = 0; i < _ailne.Count; i++)
            {
                _ailne[i].transform.localPosition = new Vector3(i * width - centerOffset, 0, 0);
            }
        }
    }
}
