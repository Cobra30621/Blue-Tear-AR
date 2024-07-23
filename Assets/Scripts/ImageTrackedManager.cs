// using UnityEngine;
// using UnityEngine.XR.ARFoundation;
// using UnityEngine.XR.ARSubsystems;
// using System.Collections.Generic;
//
// public class ImageTrackedManager : MonoBehaviour
// {
//     private ARTrackedImageManager trackedImageManager;
//     public GameObject dynamicEffectPrefab;
//
//     public TouchTest touchTest;
//     public ArtDisplay artDisplay;
//     
//     void Awake()
//     {
//         trackedImageManager = GetComponent<ARTrackedImageManager>();
//     }
//
//     void OnEnable()
//     {
//         trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
//     }
//
//     void OnDisable()
//     {
//         trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
//     }
//
//     void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
//     {
//         foreach (var trackedImage in eventArgs.added)
//         {
//             // 創建並顯示動態效果
//             var ob = Instantiate(dynamicEffectPrefab, trackedImage.transform);
//             artDisplay = ob.GetComponent<ArtDisplay>();
//             artDisplay.gameObject.SetActive(true);
//             touchTest.artDisplay = artDisplay;
//             
//             // 設置動態效果的大小
//             SetEffectSize(artDisplay.gameObject, trackedImage.referenceImage.size);
//         }
//
//         foreach (var trackedImage in eventArgs.updated)
//         {
//             Debug.Log($"{trackedImage.transform.rotation}, {trackedImage.transform.position}, {trackedImage.gameObject.name}");
//             // 更新動態效果的位置和狀態
//             if (trackedImage.trackingState == TrackingState.Tracking)
//             {
//                 artDisplay.gameObject.SetActive(true);
//                 artDisplay.transform.position = trackedImage.transform.position;
//                 // artDisplay.transform.rotation = trackedImage.transform.rotation;
//                 
//                 Debug.Log($"art  {artDisplay.transform.rotation},{artDisplay.transform.position}, {artDisplay.gameObject.name}");
//             }
//             else
//             {
//                 artDisplay.gameObject.SetActive(false);
//             }
//         }
//
//         foreach (var trackedImage in eventArgs.removed)
//         {
//             // 移除動態效果
//             Destroy(artDisplay);
//         }
//     }
//
//     void SetEffectSize(GameObject ob, Vector2 size)
//     {
//         // 根據參考圖像的物理尺寸調整動態效果的大小
//         ob.transform.localScale = new Vector3(size.x, size.y, 1f);
//     }
// }
