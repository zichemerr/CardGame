using MerJame.Infrastructure;
using UnityEngine;

namespace MerJame.ParticleSystem
{
    public class ParticleRoot : CompositeRoot
    {
        [SerializeField] private GameObject _particle;
        [SerializeField] private Transform _parent;

        public void Play(Vector2 position)
        {
            GameObject obj = Instantiate(_particle, _parent);

            obj.transform.position = position;
        }
    }
}
