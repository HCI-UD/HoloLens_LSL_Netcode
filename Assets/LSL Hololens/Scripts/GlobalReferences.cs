using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HCIUD.HoloLSL
{
    public class GlobalReferences : MonoBehaviour
    {
        protected GlobalReferences() { }
        public static GlobalReferences instance = null;

        [HideInInspector]
        public GameObject _localPlayer;

        private void Awake()
        {
            //Check if instance already exists
            if (instance == null)
            {
                //if not, set instance to this
                instance = this;
            }
            //If instance already exists and it's not this:
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
        }

        
    }
}
