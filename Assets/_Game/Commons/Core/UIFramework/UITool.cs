using UnityEngine;

namespace Game
{
    public static class UITool
    {
        #region Transform
        #region Position

        public static void Set_X(this Transform pTrans, float pX)
        {
            Vector3 pos = pTrans.position;
            pos.x = pX;
            pTrans.position = pos;
        }

        public static void Set_Y(this Transform pTrans, float pY)
        {
            Vector3 pos = pTrans.position;
            pos.y = pY;
            pTrans.position = pos;
        }

        public static void Set_Z(this Transform pTrans, float pZ)
        {
            Vector3 pos = pTrans.position;
            pos.z = pZ;
            pTrans.position = pos;
        }

        public static void SetLocal_X(this Transform pTrans, float pX)
        {
            Vector3 pos = pTrans.localPosition;
            pos.x = pX;
            pTrans.localPosition = pos;
        }

        public static void SetLocal_Y(this Transform pTrans, float pY)
        {
            Vector3 pos = pTrans.localPosition;
            pos.y = pY;
            pTrans.localPosition = pos;
        }

        public static void SetLocal_Z(this Transform pTrans, float pZ)
        {
            Vector3 pos = pTrans.localPosition;
            pos.z = pZ;
            pTrans.localPosition = pos;
        }

        public static void AddLocal(this Transform pTrans, Vector3 pOffset)
        {
            pTrans.localPosition += pOffset;
        }

        public static void AddLocal_X(this Transform pTrans, float pX)
        {
            pTrans.localPosition += new Vector3(pX, 0, 0);
        }

        public static void AddLocal_Y(this Transform pTrans, float pY)
        {
            pTrans.localPosition += new Vector3(0, pY, 0);
        }

        public static void AddLocal_Z(this Transform pTrans, float pZ)
        {
            pTrans.localPosition += new Vector3(0, 0, pZ);
        }

        public static void Add_X(this Transform pTrans, float pX)
        {
            pTrans.position += new Vector3(pX, 0, 0);
        }

        public static void Add_Y(this Transform pTrans, float pY)
        {
            pTrans.position += new Vector3(0, pY, 0);
        }

        public static void Add_Z(this Transform pTrans, float pZ)
        {
            pTrans.position += new Vector3(0, 0, pZ);
        }

        public static void Add(this Transform pTrans, Vector3 pAdd)
        {
            pTrans.position += pAdd;
        }

        #endregion

        public static void RemoveAllChildren(this Transform pTransform)
        {
            for (int i = pTransform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(pTransform.GetChild(i).gameObject);
            }
        }

        public static void SetZero(this Transform pTarget)
        {
            pTarget.localEulerAngles = Vector3.zero;
            pTarget.localPosition = Vector3.zero;
            pTarget.localScale = Vector3.one;
        }

        #endregion
        public static Vector3 GetScreenToUIWorldPos(Vector3 ScreenPos)
        {
            var temp = GameObject.FindWithTag("MainCamera");
            if (temp == null)
                return Vector3.zero;
            Vector3 worldPos = temp.GetComponent<Camera>().ScreenToWorldPoint(ScreenPos);
            return worldPos;
        }
        public static Vector3 GetUIToScreenPos(Vector3 WorldPosition)
        {
            var temp = GameObject.FindWithTag("MainCamera");
            if (temp == null)
                return Vector3.zero;
            Vector3 pScreenPos = temp.GetComponent<Camera>().WorldToScreenPoint(WorldPosition);
            return pScreenPos;
        }


        /// <summary>
        /// 如果只取局部区域的话，建议用这个截屏方法 - dht
        /// </summary>
        /// <returns>The camera.</returns>
        /// <param name="rect">Rect.</param>
        /// <param name="cameras">Cameras.</param>
        public static Texture2D CaptureCameras(Rect rect, params Camera[] cameras)
        {
            RenderTexture rt = new RenderTexture((int)Screen.width, (int)Screen.height, 24);
            //临时设置相关相机的targetTexture为rt, 并手动渲染相关相机
            for (int i = 0; i < cameras.Length; i++)
            {
                if (cameras[i] != null)
                {
                    cameras[i].targetTexture = rt;
                    cameras[i].Render();
                }
            }

            //激活这个rt, 并从中中读取像素。
            RenderTexture.active = rt;
            Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
            screenShot.ReadPixels(rect, 0, 0);   //注：这个时候，它是从RenderTexture.active中读取像素
            screenShot.Apply();

            //重置相关参数，以使用camera继续在屏幕上显示
            for (int i = 0; i < cameras.Length; i++)
            {
                if (cameras[i] != null)
                    cameras[i].targetTexture = null;
            }
            RenderTexture.active = null;
            rt.Release();
            GameObject.Destroy(rt);
            rt = null;

            return screenShot;
        }

    }
}