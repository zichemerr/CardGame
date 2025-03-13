using CMS.DragSystem;
using System.Collections.Generic;
using UnityEngine;
using MerJame.Infrastructure;

namespace CMS.CardSystem
{
    [ExecuteInEditMode]
    public class CardAlign : CompositeRoot
    {
        [SerializeField] private float width = 1f;
        
        private List<Dragable> _ailne = new List<Dragable>();
        private List<Dragable> _objects = new List<Dragable>();
        
        public void Align()
        {
            _ailne.Clear();

            foreach (var obj in _objects)
            {
                if (!obj.IsDragging && !obj.IsSloted)
                {
                    _ailne.Add(obj);
                }
            }

            float totalWidth = width * (_ailne.Count - 1);
            float startX = -totalWidth / 2f;
            
            for (var i = 0; i < _ailne.Count; i++)
            {
                _ailne[i].Movable.TargetPosition = new Vector3(startX + i * width, transform.position.y, 0);
            }
        }

        public void AddDragable(Dragable draggable)
        {
            _objects.Add(draggable);
        }
    }
}
