using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TC.Shader
{
	public class TCUnlitShaderGUI : TCBaseShaderGUI
	{
		#region Rendering Mode

		protected override bool IsRenderingModeEnabled {
			get { return true; }
		}

		#endregion


		#region Property Basic

		private readonly List<string> _basicPropertyNames = new List<string> {
			TCShaderEditorHelper.PROPERTY_MAIN_COLOR,
			TCShaderEditorHelper.PROPERTY_MAIN_TEX
		};

		protected override List<string> BasicPropertyNames {
			get { return _basicPropertyNames; }
		}

		#endregion


		#region Property Group

		private readonly List<TCPropertyGroup> _propertyGroups = new List<TCPropertyGroup> {
			TCShaderEditorHelper.AlphaTestPropertyGroup,
			TCShaderEditorHelper.ToonmapPropertyGroup,
			TCShaderEditorHelper.DecalLayerPropertyGroup,
			TCShaderEditorHelper.DiscolorPropertyGroup
		};

		protected override List<TCPropertyGroup> PropertyGroups {
			get { return _propertyGroups; }
		}

		#endregion
	}
}