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
                //BUG: I can see the kinectHead properly in 1st debug log, but when I assign to kinectHead I do not see it. Getting null error. 

                //Debug.Log("start: "+ GameObject.Find("/Kinect4AzureTracker/pointBody/head"));
                //GameObject kinectHead = GameObject.Find("/Kinect4AzureTacker/pointBody/head");
                //Debug.Log("kinectHead: "+kinectHead);
                float distance = Vector3.Distance(_headsetTransform.position, GameObject.Find("/Kinect4AzureTacker/pointBody/head").transform.position);
                _headsetTransform.position.Set(_headsetTransform.position.x, _headsetTransform.position.y, _headsetTransform.position.z + distance);
                transform.SetPositionAndRotation(_headsetTransform.position * -1f, _headsetTransform.rotation);
            }
        }
    }
}
