using UnityEngine;
using System.Collections;

public class MapView : MonoBehaviour
{
	public bool locationTest = false;

	[HideInInspector]
	public float latitude;
	[HideInInspector]
	public float longitude;
	
	
	[HideInInspector]
	public bool flag = false;
	
	private AndroidJavaObject activity;
	void Start ()
	{
//        #if UNITY_ANDROID && !UNITY_EDITOR // 新たに追加する行
		AndroidJavaClass unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		activity = unityPlayer.GetStatic<AndroidJavaObject> ("currentActivity");
//       #endif // 新たに追加する行
	}
	
	public void SetLocation(){
		if(flag)
			return;
		
		flag = true;
		StartCoroutine(_SetLocation());
	}
	
	private IEnumerator _SetLocation ()
	{
        /*
        iPhoneSettings.StartLocationServiceUpdates ();
		while (iPhoneSettings.locationServiceStatus.Equals (LocationServiceStatus.Initializing)) {
			yield return new WaitForEndOfFrame ();
		}
		latitude = iPhoneSettings.lastLocation.latitude;
		longitude = iPhoneSettings.lastLocation.longitude;
		activity.Call ("setLocation", latitude, longitude);
        iPhoneSettings.StopLocationServiceUpdates ();
        */

        /*
        Application.StartLocationServiceUpdates();
        while (Application.locationServiceStatus.Equals(LocationServiceStatus.Initializing))
        {
            yield return new WaitForEndOfFrame();
        }
        latitude = Application.lastLocation.latitude;
        longitude = Application.lastLocation.longitude;
        activity.Call("setLocation", latitude, longitude);
        Application.StopLocationServiceUpdates();
        */
        yield return new WaitForEndOfFrame();

        latitude = 35.643254f;
        longitude = 139.712579f;
        activity.Call("setLocation", latitude, longitude);

        flag = false;
	}

	public void SetLocationTest (float latitude, float longitude)
	{
		activity.Call ("setLocation", latitude, longitude);
	}
}
