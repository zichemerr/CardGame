using UnityEngine;

namespace CMS.EntryPoint
{
    public abstract class CompositeRoot : MonoBehaviour, IService
    {
        public virtual void Init() { }
    }
}