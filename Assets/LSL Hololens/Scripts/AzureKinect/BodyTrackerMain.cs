using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HCIUD.HoloLSL
{
    public class BodyTrackerMain : MonoBehaviour
    {

        // Handler for SkeletalTracking thread.
        public GameObject m_tracker;
        private SkeletalTrackingProvider m_skeletalTrackingProvider;
        public BackgroundData m_lastFrameData = new BackgroundData();


        // Start is called before the first frame update
        void Start()
        {
            //tracker ids needed for when there are two trackers
            const int TRACKER_ID = 0;
            m_skeletalTrackingProvider = new SkeletalTrackingProvider(TRACKER_ID);
        }

        // Update is called once per frame
        void Update()
        {
            if (m_skeletalTrackingProvider.IsRunning)
            {
                if (m_skeletalTrackingProvider.GetCurrentFrameData(ref m_lastFrameData))
                {
                    if (m_lastFrameData.NumOfBodies != 0)
                    {
                        m_tracker.GetComponent<TrackerHandler>().updateTracker(m_lastFrameData);
                    }
                }
            }
        }
        void OnApplicationQuit()
        {
            if (m_skeletalTrackingProvider != null)
            {
                m_skeletalTrackingProvider.Dispose();
            }
        }
    }
}
