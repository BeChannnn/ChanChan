using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class SingleTon<T> : MonoBehaviour where T : SingleTon<T>
    {
        private static T _instance;
        public static T Instance => _instance;
        [SerializeField] private bool isDontDestroyOnload;

        List<int> a;
        private List<FloatingObject> b;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = (T)this;
            }
            else
            {
                Destroy(gameObject);
            }
            if (isDontDestroyOnload)
            {
                DontDestroyOnLoad(target: this);
            }
        }
    }
}