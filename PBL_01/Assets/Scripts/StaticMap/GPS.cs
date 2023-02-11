using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Android;

public class GPS : MonoBehaviour
{
    public static float latitude;
    public static float longitude;

    private static bool status = false;

    private void Awake()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
#endif
        StartCoroutine(StartLocationService());
    }
    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            status = false;
            Debug.Log("User has not enabled location");
            yield break;
        }
        Input.location.Start();
        while (Input.location.status == LocationServiceStatus.Initializing)
        {
            yield return new WaitForSeconds(1);
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            status = false;
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            while (true)
            {
		/* gps 정보를 가져와 경도와 위도 저장 */
                latitude = Input.location.lastData.latitude;
                longitude = Input.location.lastData.longitude;
                
                status = true;

                //Latitude.text = "    : " + GoogleStaticMap.url;
                //Longtitude.text = " 浵: "+longitude.ToString();
                Debug.Log("Latitude : " + Input.location.lastData.latitude);
                Debug.Log("Longitude : " + Input.location.lastData.longitude);
                Debug.Log("Altitude : " + Input.location.lastData.altitude);
                yield return new WaitForSeconds(0.0001f); //위도와 경도 갱신
            }
        }
    }

    public static bool ReturnStatus() {
        return status;
    }
}