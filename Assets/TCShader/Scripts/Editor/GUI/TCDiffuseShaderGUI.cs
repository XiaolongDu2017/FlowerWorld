using System.Collections.Generic;

namespace TC.Shader
{
	public class TCDiffuseShaderGUI : TCBaseShaderGUI
	{
		#region Rendering Mode

		protected override bool IsRenderingModeEnabled {
			get { return true; }
		}

		#endregion


		#region Property Basic

		private readonly List<string> _basicPropertyNames = new List<string> {
			TCShaderEditorHelper.PROPERTY_MAIN_COLOR,
			TCShaderEditorHelper.PROPERTY_MAIN_TEX,
			TCShaderEditorHelper.PROPERTY_COLOR_FACTOR
		};

		protected override List<string> BasicPropertyNames {
			get { return _basicPropertyNames; }
		}

		#endregion


		#region Property Group

		private readonly List<TCPropertyGroup> _propertyGroups = new List<TCPropertyGroup> {
			TCShaderEditorHelper.AlphaTestPropertyGroup,
			TCShaderEditorHelper.SpecularPropertyGroup,
			TCShaderEditorHelper.NormalmapPropertyGroup,
			TCShaderEditorHelper.ReflectionPropertyGroup,
			TCShaderEditorHelper.BottomLayerPropertyGroup,
			new TCKeywordPropertyGroup {
				SubNames = new Dictionary<string, string[]> {
					{ TCShaderEditorHelper.KEYWORD_REFLECTION_ON, new[] { TCShaderEditorHelper.PROPERTY_FACTOR_TEX } },
					{ TCShaderEditorHelper.KEYWORD_BOTTOM_LAYER_ON, new[] { TCShaderEditorHelper.PROPERTY_FACTOR_TEX } }
				}
			},
			TCShaderEditorHelper.RimWrapPropertyGroup,
			TCShaderEditorHelper.DiscolorPropertyGroup
		};

		protected override List<TCPropertyGroup> PropertyGroups {
			get { return _propertyGroups; }
		}

		#endregion
	}
}