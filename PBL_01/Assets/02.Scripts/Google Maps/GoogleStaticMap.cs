using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleStaticMap : MonoBehaviour
{
	public RawImage rawImage;
	[Range(0f, 1f)]
	public float transparency = 1f;
	public float mapCenterLatitude;
	public float mapCenterLongtitude;
	float[] pLatitude = new float [100];
	float[] pLongtitude = new float[100];
	string path;
	int i = 0;
	[Range(1, 20)]
	public int mapZoom = 30;
	public int mapWidth = 1080;
	public int mapHeight =1080;
	public enum MapType
	{
		roadmap, satellite, terrain, hybrid,
	}
	public MapType mapType = MapType.roadmap;
	[Range(1, 4)]
	public int scale = 1;
	public float markerLatitude;
	public float markerLongtitude;
	public enum MarkerSize
	{
		tiny, mid, small,
	}
	public MarkerSize markerSize = MarkerSize.mid;
	public enum MarkerColor
	{
		black, brown, green, purple, yellow, blue, gray, orange, red, white,
	}
	public MarkerColor markerColor = MarkerColor.blue;
	public char label = 'C';
	public string apiKey;

	private string url;
	private Color rawImageColor = Color.white;

	IEnumerator Map()
	{

		markerLatitude = GPS.latitude;
		markerLongtitude = GPS.longitude;

		pLatitude[i] = GPS.latitude;
		pLongtitude[i] = GPS.longitude;

		i++;

		mapCenterLatitude = GPS.latitude;
		mapCenterLongtitude = GPS.longitude;

		rawImageColor.a = transparency;
		rawImage.color = rawImageColor;

		for(int j =0; j < i; j++)
        {
			path += "%7C" + pLatitude[j] + "," + pLongtitude[j];
			//yield return path;
        }

		label = Char.ToUpper(label);

		url = "https://maps.googleapis.com/maps/api/staticmap"
			+ "?center=" + mapCenterLatitude + "," + mapCenterLongtitude
			+ "&zoom=" + mapZoom
			+ "&size=" + mapWidth + "x" + mapHeight
			+ "&scale=" + scale
			+ "&maptype=" + mapType
			+ "&markers=size:" + markerSize + "%7Ccolor:" + markerColor + "%7Clabel:" + label + "%7C" + markerLatitude + "," + markerLongtitude
			+ "&path=weight:5%7Ccolor:orange" + path
			+ "&key=" + apiKey;

		WWW www = new WWW(url);
		yield return www;
		rawImage.texture = www.texture;
		rawImage.SetNativeSize();
	}

	public void RefreshMap()
	{
		if (gameObject.activeInHierarchy)
		{
			StartCoroutine(Map());
		}
	}

	private void Reset()
	{
		rawImage = gameObject.GetComponentInChildren<RawImage>();
		InvokeRepeating("RefreshMap", 0.0001f, 1f);
		//RefreshMap();

	}

	private void Start()
	{
		Invoke("Reset", 1f);
	}

    private void Update()
    {
		//Reset();
		//Invoke("Reset", 1f);
	}

#if UNITY_EDITOR
    private void OnValidate()
	{
		RefreshMap();
	}
#endif
}
