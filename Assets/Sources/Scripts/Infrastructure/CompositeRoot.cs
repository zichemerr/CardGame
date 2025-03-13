using MerJame.Locator;
using UnityEngine;

namespace MerJame.Infrastructure
{
    public abstract class CompositeRoot : MonoBehaviour, IService
    {
        public virtual void Ready() { }
        public virtual void Init() { }
    }
}