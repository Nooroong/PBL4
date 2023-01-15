using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class StaticMapLoader : MonoBehaviour
{
    public RawImage m_RawImage;

    [Header("맵 정보 입력")]
    public string URL = "http://api.vworld.kr/req/image?service=image&request=getmap&key=";
    public string latitude = ""; // 위도
    public string longitude = ""; // 경도
    public int zoomLevel = 18; // 6~18
    public int mapWidth; // size max = 1024x1024
    public int mapHeigth;
    public string APIKey = "";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(VWorldMapLoad());
    }
    IEnumerator VWorldMapLoad()
    {
        yield return null;

        StringBuilder str = new StringBuilder();
        str.Append(URL.ToString());
        str.Append(APIKey.ToString());
        str.Append("&format=png");
        str.Append("&basemap=GRAPHIC"); /*NONE : 없음(흰배경)
                                        GRAPHIC(기본값) : 기본지도
                                        GRAPHIC_GRAY : 회색지도
                                        GRAPHIC_NIGHT : 야간지도
                                        PHOTO : 영상지도
                                        PHOTO_HYBRID : 영상시설물지도
                                            */
        str.Append("&center=");
        str.Append(longitude.ToString());
        str.Append(",");
        str.Append(latitude.ToString());
        str.Append("&crs=epsg:4326");
        str.Append("&zoom=");
        str.Append(zoomLevel.ToString());
        str.Append("&size=");
        str.Append(mapWidth.ToString());
        str.Append(",");
        str.Append(mapHeigth.ToString());

        Debug.Log(str.ToString());
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(str.ToString());

        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            m_RawImage.texture = DownloadHandlerTexture.GetContent(request);
        }

    }
   
}
