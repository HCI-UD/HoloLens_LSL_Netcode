using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using LSL;
using LSL4Unity.Utils;

namespace HCIUD.HoloLSL
{
    /// <summary>
    /// sends Headset position and rotation and eye gaze position data from HoloLens to LabRecorder
    /// </summary>
    public class LSLSampleStream : AFloatOutlet
    {
        [Header("Synchronized Transform")]
        [SerializeField]
        private Transform sphere;
        [SerializeField]
        private Transform body;

        public override List<string> ChannelNames
        {
            get { return new List<string>(new string[] { 
                    "headset position x", "headset position y", "headset position z", "headset rotation x", "headset rotation y", "headset rotation z",
                    "gaze position x", "gaze position y", "gaze position z",
                    "torso position x", "torso position y", "torso position z", "neck position x", "neck position y", "neck position z",
                     "left knee position x", "left knee position y", "left knee position z", "right knee position x", "right knee position y", "right knee position z",
                     "left elbow position x", "left elbow position y", "left elbow position z", "right elbow position x", "right elbow position y", "right elbow position z",
                     "left hand position x", "left hand position y", "left hand position z", "right hand position x", "right hand position y", "right hand position z"
            }); }
        }


        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            Debug.Log("Try to connect LSL: " + LSL.LSL.library_version());
            Debug.Log(outlet.ToString());
            //Reset();
        }

        // Update is called once per frame
        protected override bool BuildSample()
        {

            if (GlobalReferences.instance != null && GlobalReferences.instance._localPlayer != null)
            {
                var gaze_position_values = sphere.position;
                var headset_position_values = GlobalReferences.instance._localPlayer.transform.position;
                var headset_rotation_values = GlobalReferences.instance._localPlayer.transform.eulerAngles;
                var torso_position_values = body.Find("spineNaval").position;
                var neck_position_values = body.Find("neck").position;
                var left_knee_position_values = body.Find("leftKnee").position;
                var right_knee_position_values = body.Find("rightKnee").position;
                var left_elbow_position_values = body.Find("leftElbow").position;
                var right_elbow_position_values = body.Find("rightElbow").position;
                var left_hand_position_values = body.Find("leftHand").position;
                var right_hand_position_values = body.Find("rightHand").position;

                sample[0] = headset_position_values.x;
                sample[1] = headset_position_values.y;
                sample[2] = headset_position_values.z;
                sample[3] = headset_rotation_values.x;
                sample[4] = headset_rotation_values.y;
                sample[5] = headset_rotation_values.z;

                sample[6] = gaze_position_values.x;
                sample[7] = gaze_position_values.y;
                sample[8] = gaze_position_values.z;
                
                sample[9] = torso_position_values.x;
                sample[10] = torso_position_values.y;
                sample[11] = torso_position_values.z;

                sample[12] = neck_position_values.x;
                sample[13] = neck_position_values.y;
                sample[14] = neck_position_values.z;

                sample[15] = left_knee_position_values.x;
                sample[16] = left_knee_position_values.y;
                sample[17] = left_knee_position_values.z;
                sample[18] = right_knee_position_values.x;
                sample[19] = right_knee_position_values.y;
                sample[20] = right_knee_position_values.z;

                sample[21] = left_elbow_position_values.x;
                sample[22] = left_elbow_position_values.y;
                sample[23] = left_elbow_position_values.z;
                sample[24] = right_elbow_position_values.x;
                sample[25] = right_elbow_position_values.y;
                sample[26] = right_elbow_position_values.z;

                sample[27] = left_hand_position_values.x;
                sample[28] = left_hand_position_values.y;
                sample[29] = left_hand_position_values.z;
                sample[30] = right_hand_position_values.x;
                sample[31] = right_hand_position_values.y;
                sample[32] = right_hand_position_values.z;
            }

            return true;
        }
    }
}
