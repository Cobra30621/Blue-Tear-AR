using  System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Imagine.WebAR{

    [System.Serializable]
    public class ImageTargetInfo
    {
        public string id;
        public Texture2D texture;
    }

    [System.Serializable]
    public class TrackerSettings
    {
        [Tooltip("Allows tracking multiple image targets simultaneously (Experimental)")]
        [SerializeField] public int maxSimultaneousTargets = 1;

        //public enum TrackingQuality { SPEED_OVER_QUALITY, BALANCED, QUALITY_OVER_SPEED };
        //[SerializeField] public TrackingQuality trackingQuality = TrackingQuality.BALANCED;


        public enum FrameRate { FR_30_FPS = 30, FR_60FPS = 60};

        [SerializeField] public FrameRate targetFrameRate = FrameRate.FR_30_FPS;

        [SerializeField] public AdvancedSettings advancedSettings;
        

        [Tooltip("If enabled, you can display imageTarget feature points by pressing 'I' in desktop browser")]
        [Space][SerializeField] public bool debugMode = false;


        public string Serialize() {
            var json = "{";
            json += "\"MAX_SIMULTANEOUS_TRACK\":" + maxSimultaneousTargets + ",";

            //json += "\"QOS\":" + (int)trackingQuality + ",";

            json += "\"FRAMERATE\":" + (int)targetFrameRate + ",";

            json += "\"MAX_AREA\":" + Mathf.RoundToInt(advancedSettings.maxFrameArea * 1000) + ",";
            
            json += "\"MAX_PIXELS\":" + Mathf.RoundToInt(advancedSettings.maxFrameLength) + ",";

            json += "\"TRACK_TARGET_MATCH_COUNT\":" + advancedSettings.trackedPoints + ",";

             json += "\"DETECT_INTERVAL\":" + advancedSettings.detectInterval;

            /*json += "\"KALMAN_POSE_POS_FACTOR\":" + advancedSettings.noiseFiltering.smoothingThresholdPos.ToStringInvariantCulture() + ",";
            json += "\"KALMAN_POSE_ROT_FACTOR\":" + advancedSettings.noiseFiltering.smoothingThresholdRot.ToStringInvariantCulture() + ",";
            json += "\"KALMAN_MEAS_NOISE_POS\":"  + advancedSettings.noiseFiltering.smoothingStrengthPos.ToStringInvariantCulture() + ",";
            json += "\"KALMAN_MEAS_NOISE_ROT\":"  + advancedSettings.noiseFiltering.smoothingStrengthRot.ToStringInvariantCulture() + ",";

            json += "\"STABLE_POSE_POS_FACTOR\":" + advancedSettings.stability.stabilityThresholdPos.ToStringInvariantCulture() + ",";
            json += "\"STABLE_POSE_ROT_FACTOR\":" + advancedSettings.stability.stabilityThresholdRot.ToStringInvariantCulture();*/

            json += "}";

            return json;

        }
    }

    [System.Serializable]
    public class AdvancedSettings
    {
        [Tooltip("Higher values will increase accuracy, but decreases frame rate")]
        [SerializeField][Range(300, 600)]
        public int maxFrameLength = 500;

        [Tooltip("Higher values will make the image easily detected, but induces a short lag/delay")]
        [SerializeField] [Range(24, 80)] public float maxFrameArea = 40;

        [Tooltip("Higher values will improve stability, but decreases frame rate")]
        [SerializeField] [Range(16, 80)] public int trackedPoints = 40;

        [Tooltip("Lower intervals will speed up detection, especially on multiple targets, but significantly decreases frame rate. Value in millisecods")]
        [SerializeField] [Range(0, 1000)] public int detectInterval = 200;

        //[Space] [SerializeField] public NoiseFilteringSettings noiseFiltering;
        //[Space] [SerializeField] public StabilitySettings stability;
    }

    /*[System.Serializable]
    public class NoiseFilteringSettings
    {
        [Tooltip("Higer values are less prone to noise, but induces \"floatiness\"")]
        [SerializeField] [Range(.001f, 0.1f)] public float smoothingThresholdPos = .001f;
        [Tooltip("Higer values are less prone to noise, but induces \"floatiness\"")]
        [SerializeField] [Range(.001f, 0.1f)] public float smoothingThresholdRot = .001f;
        [Tooltip("Higer values are less prone to noise, but induces \"staircase clipping\"")]
        [SerializeField] [Range(.05f, 2f)]    public float smoothingStrengthPos  = .15f;
        [Tooltip("Higer values are less prone to noise, but induces \"staircase clipping\"")]
        [SerializeField] [Range(.05f, 2f)]    public float smoothingStrengthRot  = .15f;
    }

    [System.Serializable]
    public class StabilitySettings
    {
        [Tooltip("Lower values are more stable to motion, but induces noise")]
        [SerializeField] [Range(.001f, 0.1f)] public float stabilityThresholdPos = .1f;
        [Tooltip("Lower values are more stable to motion, but induces noise")]
        [SerializeField] [Range(.001f, 0.1f)] public float stabilityThresholdRot = .1f;
    }*/

    //[CreateAssetMenu(menuName = "Imagine WebAR/Image Tracker Global Settings", order = 1300)]
    public class ImageTrackerGlobalSettings : ScriptableObject
    {
        [SerializeField] public List<ImageTargetInfo> imageTargetInfos;

        [SerializeField] public TrackerSettings defaultTrackerSettings;
        
        
        private static ImageTrackerGlobalSettings _instance;
        public static ImageTrackerGlobalSettings Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = Resources.Load<ImageTrackerGlobalSettings>("ImageTrackerGlobalSettings");
                }
                return _instance;

            }
        }
    }
}

