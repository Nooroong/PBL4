using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Text;
using System.Xml;

/*
    vworld static map 레퍼런스
    https://www.vworld.kr/dev/v4dv_static2_s001.do#
*/

public class VworldStaticMap : MonoBehaviour
{
    public RawImage mapRawImage;    

        [Header("요청 파라미터")]
        public string strBaseURL = "http://api.vworld.kr/req/image?service=image&version=2.0&request=getmap&key=";
        public string strAPIKey = "";

        public enum format { png, jpen, bmp };
        public format map_format = format.png;

        public enum error { json, xml, image, blank };
        public error map_error = error.xml;

        public enum m_base { NONE, GRAPHIC, GRAPHIC_GRAY, GRAPHIC_NIGHT, PHOTO, PHOTO_HYBRID }
        public m_base basemap = m_base.GRAPHIC;

        public float latitude = 37.5710f;
        public float longitude = 126.9769f;
        public Slider zoomLevel;
        [Range(0f, 1024f)]
        public int mapWidth;
        [Range(0f, 1024f)]
        public int mapHeight;


        // 마커 관련 변수
        [Header("마커 서브 파라미터")]
        public string marker_label;
        public Font marker_label_font;
        public enum marker_id { img01, img01s, img02, img02s, img03, img03s, img04,
                               img04s, img05, img05s, img06, img06s, img07, img07s,
                               img08, img08s, img09, img09s, img10, img10s };
        public marker_id marker_img = marker_id.img01;


        // 경로 관련 변수
        [Header("경로 서브 파라미터")]
        [Range(1, 5)]
        public int route_width = 3;
        public enum m_color { balck, white, red, blue, green };
        public m_color route_color = m_color.blue;
        public enum r_style { solid, dash, dot, dashdot, dashdotdot, longdash, longdashdot };
        public r_style routeStyle = r_style.dashdot;


    private bool updateMap = true;
    private string route_path; // 경로 좌표들이 기록되는 문자열

    // vworld api key 문자열이 담겨있는 구글 드라이브 파일의 아이디
    private string key_id = "1SL6iHKnhnTv9nqfFjCKDy3-tuPjMnrbo";

    private string strAPIKeyLast;
    private float latitudeLast = 37.5710f;
    private float longitudeLast = 126.9769f;
    [Range(7, 18)]
    private float zoomLevelLast = 14f;
    
        

    private void Start()
    {
        // API Key를 받아오기
        StartCoroutine(GetVworldKey(key_id));

        // 지도 크기를 RawImage 크기에 맞게 지정
        Rect map_bg_size = mapRawImage.GetComponent<RawImage>().rectTransform.rect;
        mapWidth = (int)Math.Round(map_bg_size.width)/2;
        mapHeight = (int)Math.Round(map_bg_size.height)/2;
    }

    private void Update() {
        // 지도 중심 좌표와 마커의 좌표
        if(GPS.ReturnStatus()) {
            latitude = GPS.latitude;
            longitude = GPS.longitude;
        }

        // 지도 관련 설정이 바뀌거나 사용자의 위치가 바뀌면 지도를 다시 로딩
        if(updateMap && (strAPIKey != strAPIKeyLast ||
        !Mathf.Approximately(latitude, latitudeLast) ||
        !Mathf.Approximately(longitude, longitudeLast) ||
        (int)zoomLevel.value != 
        zoomLevelLast))
        {
            StartCoroutine(VWorldMapLoad());
            updateMap = false;
        }
        
    }

    IEnumerator VWorldMapLoad()
    {
        yield return null;

        // 지도 중심 좌표와 마커의 좌표
        if(GPS.ReturnStatus()) {
            latitude = GPS.latitude;
            longitude = GPS.longitude;
        }
        
        // 새로운 좌표를 경로에 추가(좌표가 바뀐 경우에만)
        if(!Mathf.Approximately(latitude, latitudeLast) ||
        !Mathf.Approximately(longitude, longitudeLast)) {
            if(String.IsNullOrEmpty(route_path)) {
                // 첫 좌표를 경로에 기록
                // 좌표가 하나만 있으면 마커가 나오지 않기에 처음에만 중복하여 기록
                route_path += longitude + " " + latitude + "," + longitude + " " + latitude;
            } else {
                route_path += "," + longitude + " " + latitude;
            }

        }

        // 지도 요청 url
        StringBuilder url = new StringBuilder();
        url.Append(strBaseURL.ToString());
        url.Append(strAPIKey.ToString());
        url.Append("&format=");
        url.Append(map_format.ToString());
        url.Append("&errorFormat=");
        url.Append(map_error.ToString());
        url.Append("&basemap=");
        url.Append(basemap.ToString());
        url.Append("&center=");
        url.Append(longitude.ToString());
        url.Append(",");
        url.Append(latitude.ToString());
        url.Append("&crs=epsg:4326");
        url.Append("&zoom=");
        url.Append(zoomLevel.value.ToString());
        url.Append("&size=");
        url.Append(mapWidth.ToString());
        url.Append(",");
        url.Append(mapHeight.ToString());

        // 마커 정보
        url.Append("&marker=label:");
        url.Append(marker_label.ToString());
        url.Append("|point:");
        url.Append(longitude.ToString());
        url.Append(" ");
        url.Append(latitude.ToString());
        url.Append("|image:");
        url.Append(marker_img.ToString());

        // 경로 정보
        url.Append("&route=style:");
        url.Append(routeStyle.ToString());
        url.Append("|color:");
        url.Append(route_color.ToString());
        url.Append("|width:");
        url.Append(route_width.ToString());
        url.Append("|point:");
        url.Append(route_path);


        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url.ToString());
        yield return request.SendWebRequest();

        Debug.Log(url.ToString());

        if (request.result != UnityWebRequest.Result.Success) {
            // 오류메세지 출력
            Debug.Log(request.downloadHandler.text);
        } else {
            updateMap = true;
            mapRawImage.texture = DownloadHandlerTexture.GetContent(request);

            strAPIKeyLast = strAPIKey;
            latitudeLast = latitude;
            longitudeLast = longitude;
            zoomLevelLast = (int)zoomLevel.value;
        }
    }

   IEnumerator GetVworldKey(String key_id) {
        // https://ehdud9426.tistory.com/300

        yield return new WaitForSeconds(1f);

        String prefix = "http://drive.google.com/uc?export=view&id=";

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(prefix + key_id);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success) {
            strAPIKey = "None";
            Debug.Log("Get Key Failed!");
        } else {
            strAPIKey = request.downloadHandler.text;
        }
    }

}
