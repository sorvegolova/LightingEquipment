using LightingEquipment.Model.Base;

namespace LightingEquipment.Model
{
	public class TypeLamp : BaseModel
	{
		/// <summary> коэффициента минимальной освещенности  </summary>
		public float CoefMinIllumination { get; }

		/// <summary> коэффициент запаса </summary>
		public float CoefStore { get; }

		public TypeLamp(uint id, string name, float minIlluminationCoef, float stockRatio) : base(id, name)
		{
			CoefMinIllumination = minIlluminationCoef;
			CoefStore = stockRatio;
		}
	}
}
