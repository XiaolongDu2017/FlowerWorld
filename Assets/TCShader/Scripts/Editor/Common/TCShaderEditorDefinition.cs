namespace TC.Shader
{
	public enum TCShaderRenderingMode
	{
		NoSet = -1,
		Opaque = 0,
		Cutout = 1,
		Transparent = 2
	}

	public enum TCShaderDiscolorMode
	{
		None = 0,
		HslBlend = 1,
		HueReplace = 2
	}
}