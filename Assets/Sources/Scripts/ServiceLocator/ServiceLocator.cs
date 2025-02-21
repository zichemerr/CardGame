using System;
using System.Collections.Generic;

namespace CMS.EntryPoint
{
    public class ServiceLocator<T> : IServiceLocator<T>
    {
        protected Dictionary<Type, T> _itemsMap { get; }
        protected Dictionary<int, T> _itemsId { get; }

        public ServiceLocator()
        {
            _itemsMap = new Dictionary<Type, T>();
            _itemsId = new Dictionary<int, T>();
        }

        public TP Get<TP>(int id = -1) where TP : T
        {
            var type = typeof(TP);

            if (id == -1)
            {
                if (_itemsMap.ContainsKey(type) == false)
                {
                    throw new Exception($"»ƒ» ¬  ” ¿… √ÂÚ {type.Name}");
                }

                return (TP)_itemsMap[type];
            }

            if (_itemsId.ContainsKey(id) == false)
            {
                throw new Exception($"»ƒ» ¬  ” ¿… √ÂÚ {type.Name}");
            }

            return (TP)_itemsId[id];
        }

        public TP Register<TP>(TP service, int id = -1) where TP : T
        {
            var type = service.GetType();

            if (id == -1)
            {
                if (_itemsMap.ContainsKey(type))
                {
                    throw new Exception($"»ƒ» ¬  ” ¿… Register {type.Name}");
                }

                _itemsMap[type] = service;

                return service;
            }

            if (_itemsId.ContainsKey(id))
            {
                throw new Exception($"»ƒ» ¬  ” ¿… Register {type.Name}");
            }

            _itemsId[id] = service;

            return service;
        }

        public void UnRegister<TP>(TP service) where TP : T
        {
            var type = service.GetType();

            if (_itemsMap.ContainsKey(type))
            {
                _itemsMap.Remove(type);
            }
        }
    }
}
