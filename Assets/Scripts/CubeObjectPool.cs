using UnityEngine;
using UnityEngine.Pool;
namespace Chapter.ObjectPool
{
    public class CubeObjectPool : MonoBehaviour
    {
        public int maxPoolSize = 10;
        public int stackDefaultCapacity = 10;
        public IObjectPool<CubePooling> Pool
        {
            get
            {
                if (_pool == null)
                    _pool =
                    new ObjectPool<CubePooling>(
                    CreatedPooledItem,
                    OnTakeFromPool,
                    OnReturnedToPool,
                    OnDestroyPoolObject,
                    true,
                    stackDefaultCapacity,
                    maxPoolSize);
                return _pool;
            }
        }
        private IObjectPool<CubePooling> _pool;

        private CubePooling CreatedPooledItem()
        {
            var go =
            GameObject.CreatePrimitive(PrimitiveType.Cube);
            CubePooling cube = go.AddComponent<CubePooling>();
            go.name = "cube";
            cube.Pool = Pool;
            return cube;
        }
        private void OnReturnedToPool(CubePooling cube)
        {
            cube.gameObject.SetActive(false);
        }
        private void OnTakeFromPool(CubePooling cube)
        {
            cube.gameObject.SetActive(true);
        }
        private void OnDestroyPoolObject(CubePooling cube)
        {
            Destroy(cube.gameObject);
        }
        public void Spawn()
        {
            var amount = Random.Range(1, 10);
            for (int i = 0; i < amount; ++i)
            {
                var cube = Pool.Get();
                cube.transform.position =
                Random.insideUnitSphere * 10;
            }
        }
        private void Update()
        {
            Spawn();
        }
    }
}