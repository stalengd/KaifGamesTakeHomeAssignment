using System.Collections.Generic;
using UnityEngine;

namespace KaifGames.TestClicker.UI.Elements
{
    public struct ObjectPool
    {
        public ICollection<GameObject> ActiveObjects => _activeObjects;

        private readonly GameObject _prefab;
        private readonly List<GameObject> _freeObjects;
        private readonly HashSet<GameObject> _activeObjects;

        public ObjectPool(GameObject prefab) : this()
        {
            _prefab = prefab;
            _freeObjects = new();
            _activeObjects = new();
        }

        public GameObject Instantiate()
        {
            if (!TryInstantiateFromPooled(out var obj))
            {
                obj = Object.Instantiate(_prefab);
            }
            TrackActive(obj);
            return obj;
        }

        public GameObject Instantiate(Transform parent)
        {
            if (!TryInstantiateFromPooled(parent, out var obj))
            {
                obj = Object.Instantiate(_prefab, parent);
            }
            TrackActive(obj);
            return obj;
        }

        public void SoftDestroy(GameObject obj)
        {
            if (!_activeObjects.Remove(obj))
            {
                return;
            }
            _freeObjects.Add(obj);
            obj.SetActive(false);
        }

        public void SoftDestroyActive()
        {
            foreach (var obj in _activeObjects)
            {
                _freeObjects.Add(obj);
                obj.SetActive(false);
            }
            _activeObjects.Clear();
        }

        private void TrackActive(GameObject obj)
        {
            _activeObjects.Add(obj);
        }

        private bool TryInstantiateFromPooled(out GameObject obj)
        {
            if (!TryGetPooledObject(out obj))
            {
                return false;
            }
            obj.SetActive(true);
            return true;
        }

        private bool TryInstantiateFromPooled(Transform parent, out GameObject obj)
        {
            if (!TryInstantiateFromPooled(out obj))
            {
                return false;
            }
            obj.transform.SetParent(parent);
            return true;
        }

        private bool TryGetPooledObject(out GameObject obj)
        {
            if (_freeObjects.Count == 0)
            {
                obj = null;
                return false;
            }
            obj = _freeObjects[^1];
            _freeObjects.RemoveAt(_freeObjects.Count - 1);
            return true;
        }
    }
}