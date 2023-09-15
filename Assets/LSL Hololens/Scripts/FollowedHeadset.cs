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
                Debug.Log("head_position: " + _headsetTransform.position);
            }

            //if (isenableheadset)
            //{
            //    //bug: i can see the kinecthead properly in 1st debug log, but when i assign to kinecthead i do not see it. getting null error. 

            //    //debug.log("start: "+ gameobject.find("/kinect4azuretracker/pointbody/head"));
            //    //gameobject kinecthead = gameobject.find("/kinect4azuretacker/pointbody/head");
            //    //debug.log("kinecthead: "+kinecthead);
            //    float distance = vector3.distance(_headsettransform.position, gameobject.find("/kinect4azuretracker/pointbody/head").transform.position);
            //    _headsettransform.position.set(_headsettransform.position.x, _headsettransform.position.y, _headsettransform.position.z + distance);
            //    transform.setpositionandrotation(_headsettransform.position * -1f, _headsettransform.rotation);
            //}
        }
    }
}
