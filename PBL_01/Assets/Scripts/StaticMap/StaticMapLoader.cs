using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class StaticMapLoader : MonoBehaviour
{
    public RawImage m_RawImage;

    [Header("�� ���� �Է�")]
    public string URL = "http://api.vworld.kr/req/image?service=image&request=getmap&key=";
    public string latitude = ""; // ����
    public string longitude = ""; // �浵
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
        str.Append("&basemap=GRAPHIC"); /*NONE : ����(����)
                                        GRAPHIC(�⺻��) : �⺻����
                                        GRAPHIC_GRAY : ȸ������
                                        GRAPHIC_NIGHT : �߰�����
                                        PHOTO : ��������
                                        PHOTO_HYBRID : ����ü�������
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
