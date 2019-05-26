using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
    public static class UILoad
    {
        #region Get/Add Component

        public static T GetOrAddComponent<T> (GameObject pGo) where T : Component
        {
            T com = pGo.GetComponent<T> () ?? pGo.AddComponent<T> ();

            return com;
        }

        public static T GetOrAddComponent<T> (Component pComponent) where T : Component
        {
            return GetOrAddComponent<T> (pComponent.gameObject);
        }

        public static Component GetOrAddComponent (Type pType, GameObject pGo)
        {
            Component com = pGo.GetComponent (pType);
            if (com == null) {
                com = pGo.AddComponent (pType);
                if (com == null) {
                    Debug.LogError ("CocoLoad->GetOrAddComponent: component [" + pType.Name + "] can NOT be added.");
                }
            }

            return com;
        }

        public static Component GetOrAddComponent (Type pType, Component pComponent)
        {
            return GetOrAddComponent (pType, pComponent.gameObject);
        }

        public static void RemoveComponent<T>(GameObject pObj) where T : Component
        {
            T component = pObj.GetComponent<T> ();
            if (component != null) 
            {
                Object.Destroy(component);
            }
        }

        #endregion


        #region Get/Add Component In Children

        public static T GetOrAddComponentInChildren<T> (GameObject pGo, bool pIncludeInactive = false) where T : Component
        {
            T com = pGo.GetComponentInChildren<T> (pIncludeInactive) ?? pGo.AddComponent<T> ();

            return com;
        }

        public static T GetOrAddComponentInChildren<T> (Component pComponent, bool pIncludeInactive = false) where T : Component
        {
            return GetOrAddComponentInChildren<T> (pComponent.gameObject, pIncludeInactive);
        }

        public static Component GetOrAddComponentInChildren (Type pType, GameObject pGo, bool pIncludeInactive = false)
        {
            Component com = pGo.GetComponentInChildren (pType, pIncludeInactive);
            if (com == null) {
                com = pGo.AddComponent (pType);
                if (com == null) {
                    Debug.LogError ("CocoLoad->GetOrAddComponent: component [" + pType.Name + "] can NOT be added.");
                }
            }

            return com;
        }

        public static Component GetOrAddComponentInChildren (Type pType, Component pComponent, bool pIncludeInactive = false)
        {
            return GetOrAddComponentInChildren (pType, pComponent.gameObject, pIncludeInactive);
        }

        #endregion


        #region Set Parent

        public enum TransStayOption
        {
            Non,
            Local,
            World
        }

        public static void SetParent (GameObject pGo, Transform pArent, TransStayOption pStayOption = TransStayOption.Non)
        {
            if (pGo == null) {
                return;
            }

            SetParent (pGo.transform, pArent, pStayOption);
        }

        public static void SetParent (Component pComponent, Transform pArent, TransStayOption pStayOption = TransStayOption.Non)
        {
            if (pComponent == null) {
                return;
            }

            Transform trans = pComponent.transform;

            switch (pStayOption) {
                case TransStayOption.Local:
                    trans.SetParent (pArent, false);
                    break;
                case TransStayOption.World:
                    trans.SetParent (pArent);
                    break;
                default:
                    trans.SetParent (pArent);
                    trans.localPosition = Vector3.zero;
                    trans.localRotation = Quaternion.identity;
                    trans.localScale = Vector3.one;
                    break;
            }
        }

        #endregion


        #region Instantiate GameObject/Component (maybe null)

        public static GameObject Instantiate (GameObject pRefab, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non)
        {
            if (pRefab == null) {
                return null;
            }

            GameObject go = Object.Instantiate (pRefab);
            SetParent (go, pArent, pStayOption);
            return go;
        }

        public static GameObject Instantiate (string pAth, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non)
        {
            if (string.IsNullOrEmpty (pAth)) {
                return null;
            }

            GameObject prefab = Resources.Load<GameObject> (pAth);
            return Instantiate (prefab, pArent, pStayOption);
        }

        public static T Instantiate<T> (GameObject pRefab, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non) where T : Component
        {
            GameObject go = Instantiate (pRefab, pArent, pStayOption);
            if (go == null) {
                return null;
            }

            return go.GetComponent<T> ();
        }

        public static T Instantiate<T> (string pAth, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non) where T : Component
        {
            if (string.IsNullOrEmpty (pAth)) {
                return null;
            }

            GameObject prefab = Resources.Load<GameObject> (pAth);
            return Instantiate<T> (prefab, pArent, pStayOption);
        }

        #endregion


        #region Instantiate/Create GameObject/Component

        public static GameObject InstantiateOrCreate (GameObject pRefab, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non)
        {
            GameObject go = pRefab != null ? Object.Instantiate (pRefab) : new GameObject ();
            SetParent (go, pArent, pStayOption);
            return go;
        }

        public static GameObject InstantiateOrCreate (string pAth, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non)
        {
            GameObject prefab = Resources.Load<GameObject> (pAth);
            return InstantiateOrCreate (prefab, pArent, pStayOption);
        }

        public static T InstantiateOrCreate<T> (GameObject pRefab, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non) where T : Component
        {
            GameObject go = InstantiateOrCreate (pRefab, pArent, pStayOption);
            return GetOrAddComponent<T> (go);
        }

        public static T InstantiateOrCreate<T> (string pAth, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non) where T : Component
        {
            GameObject prefab = Resources.Load<GameObject> (pAth);
            return InstantiateOrCreate<T> (prefab, pArent, pStayOption);
        }

        public static Component InstantiateOrCreate (Type pType, GameObject pRefab, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non)
        {
            GameObject go = InstantiateOrCreate (pRefab, pArent, pStayOption);
            return GetOrAddComponent (pType, go);
        }

        public static Component InstantiateOrCreate (Type pType, string pAth, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non)
        {
            GameObject prefab = Resources.Load<GameObject> (pAth);
            return InstantiateOrCreate (pType, prefab, pArent, pStayOption);
        }

        #endregion


        #region Instantiate/Create GameObject/Component

        public static T InstantiateOrCreateInChildren<T> (GameObject pRefab, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non, bool pIncludeInactive = false) where T : Component
        {
            GameObject go = InstantiateOrCreate (pRefab, pArent, pStayOption);
            return GetOrAddComponentInChildren<T> (go, pIncludeInactive);
        }

        public static T InstantiateOrCreateInChildren<T> (string pAth, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non, bool pIncludeInactive = false) where T : Component
        {
            GameObject prefab = Resources.Load<GameObject> (pAth);
            return InstantiateOrCreateInChildren<T> (prefab, pArent, pStayOption, pIncludeInactive);
        }

        public static Component InstantiateOrCreateInChildren (Type pType, GameObject pRefab, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non, bool pIncludeInactive = false)
        {
            GameObject go = InstantiateOrCreate (pRefab, pArent, pStayOption);
            return GetOrAddComponentInChildren (pType, go, pIncludeInactive);
        }

        public static Component InstantiateOrCreateInChildren (Type pType, string pAth, Transform pArent = null, TransStayOption pStayOption = TransStayOption.Non, bool pIncludeInactive = false)
        {
            GameObject prefab = Resources.Load<GameObject> (pAth);
            return InstantiateOrCreateInChildren (pType, prefab, pArent, pStayOption, pIncludeInactive);
        }

      

        #endregion

        #region add assets

        public static T InstantiateOrCreateAssets<T>(string pAth) where T:Object{

            T target = Resources.Load<T>(pAth);
            if (target == null)
            {
                Debug.LogError(string.Format("paht is error or can not find \"{0}\" target", typeof(T)));
                return null;
            }

            return Object.Instantiate(target);
        }
        #endregion
    }
}