using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HCIUD.HoloLSL
{
    public class FollowedHeadset : MonoBehaviour
    {
        [SerializeField]
        private bool isEnableHeadset;
        [SerializeField]
        private MeshRenderer meshRenderer;            
        private Transform _headsetTransform;


        // Start is called before the first frame update
        void Start()
        {
            if (meshRenderer == null)
                meshRenderer = GetComponent<MeshRenderer>();

            if (isEnableHeadset)
                _headsetTransform = Camera.main.transform;
            else
                meshRenderer.enabled = false;

            
        }

        // Update is called once per frame
        void Update()
        {
            if (isEnableHeadset)
            {
                transform.SetPositionAndRotation(_headsetTransform.position, _headsetTransform.rotation);
            }
        }
    }
}
