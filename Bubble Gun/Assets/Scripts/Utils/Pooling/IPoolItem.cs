using UnityEngine;

namespace Utils
{
    public interface IPoolItem
    {
        void GetFromPool();
        void ReturnToPool();
    }
}
