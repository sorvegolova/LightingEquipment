
namespace LightingEquipment.BL.Model
{
	public class TypeLamp
	{
		/// <summary> Коэффициент экономически-наивыгоднейшего расстояния </summary>
		public string Name { get; }

		/// <summary> коэффициента минимальной освещенности </summary>
		public float CoefMinIllumination { get; }

		/// <summary> коэффициент запаса </summary>
		public float CoefStore { get; }

		public TypeLamp(string name, float minIlluminationCoef, float stockRatio)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new System.ArgumentException($"\"{nameof(name)}\" - наименование типа лампы не может быть пустым или содержать только пробел.", nameof(name));
			}

			CoefMinIllumination = minIlluminationCoef;
			CoefStore = stockRatio;
			Name = name;
		}
	}
}
