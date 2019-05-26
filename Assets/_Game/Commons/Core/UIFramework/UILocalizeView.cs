using UnityEngine;
using System.Collections;
using Game;
using UnityEngine.UI;

namespace CocoPlay
{
	[AddComponentMenu ("Localize/UILocalizeView")]
	public class UILocalizeView : MonoBehaviour
	{

		/// <summary>
		/// Localization key.
		/// </summary>

		public string key;

		/// <summary>
		/// Manually change the value of whatever the localization component is attached to.
		/// </summary>

		public string value {
			set {
				if (!string.IsNullOrEmpty (value)) {
//					Debug.LogWarning ("location : " + value);
					if (GetComponent<Text> () != null) {
						Text txt = GetComponent<Text> ();
						if (txt != null)
							txt.text = value;
					}
					if (GetComponent<Image> () != null) {
						Image img = GetComponent<Image> ();
						if (img != null) {
							img.sprite = Resources.Load (value, typeof(Sprite))as Sprite;
							img.SetNativeSize ();
						}
						
					}
				}
			}
		}

		private bool m_Started = false;

		/// <summary>
		/// Localize the widget on enable, but only if it has been started already.
		/// </summary>
		private void OnEnable ()
		{
			#if UNITY_EDITOR
			if (!Application.isPlaying)
				return;
			#endif
			if (m_Started)
				OnLocalize ();
		}

		/// <summary>
		/// Localize the widget on start.
		/// </summary>
		private void Start ()
		{
			#if UNITY_EDITOR
			if (!Application.isPlaying)
				return;
			#endif
			m_Started = true;
			OnLocalize ();
		}

		/// <summary>
		/// This function is called by the Localization manager via a broadcast SendMessage.
		/// </summary>

        protected virtual void OnLocalize ()
		{
			// If no localization key has been specified, use the label's text as the key
			if (string.IsNullOrEmpty (key)) {
				Text lbl = GetComponent<Text> ();
				if (lbl != null)
					key = lbl.text;
			}

			// If we still don't have a key, leave the value as blank
//			if (!string.IsNullOrEmpty (key))
//				value = GameData.Instance.GetLangValue(key);
		}
	}
}
