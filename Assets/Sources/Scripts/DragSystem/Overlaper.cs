using System.Collections.Generic;
using UnityEngine;

namespace CMS.DragSystem
{
    public class Overlaper
    {
        private List<Slot> _slots;
        private Transform _transform;

        public Overlaper(Transform transform)
        {
            _slots = new List<Slot>();
            _transform = transform;
        }

        public Slot[] OverlapAll(float radius)
        {
            Collider2D[] colls = Physics2D.OverlapCircleAll(_transform.position, radius);

            foreach (var coll in colls)
            {
                if (coll.TryGetComponent(out Slot slot))
                {
                    _slots.Add(slot);
                }
            }

            if (_slots.Count == 0)
            {
                return null;
            }

            return _slots.ToArray();
        }
    }
}
