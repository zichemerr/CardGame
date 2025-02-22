using CMS.DragSystem;
using System.Collections.Generic;
using Unity.VisualScripting;
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
                if (!obj.Dragging && obj.Sloted == false)
                {
                    _ailne.Add(obj);
                }
            }

            float totalWidth = width * (_ailne.Count - 1); // Общая ширина
            float startX = -totalWidth / 2f;


            for (var i = 0; i < _ailne.Count; i++)
            {
                _ailne[i].transform.localPosition = Vector2.Lerp(_ailne[i].transform.localPosition, new Vector3(startX + i * width, 0, 0), 0.1f);

            }
        }
    }
}
