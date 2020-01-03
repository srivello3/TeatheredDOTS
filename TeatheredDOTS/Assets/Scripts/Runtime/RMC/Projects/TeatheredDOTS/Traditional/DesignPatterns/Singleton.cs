using UnityEngine;

namespace RMC.Projects.TeatheredDOTS.Traditional.DesignPatterns
{
    public class Singleton : MonoBehaviour
    {

    }

    public class Singleton<T> : Singleton where T: class
    {
        protected static T _instance = default(T);
        public static T Instance
        {
            get
            {
                return _instance;
            }
        }
    
        protected virtual void Awake()
        {
            _instance = this as T;
        }
    }
}