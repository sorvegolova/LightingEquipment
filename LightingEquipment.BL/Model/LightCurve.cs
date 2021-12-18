
namespace LightingEquipment.BL.Model
{
	public class LightCurve
	{
		/// <summary> наименоваание типа кривой силы света </summary>
		public string Name { get; }

		/// <summary> Коэффициент экономически-наивыгоднейшего расстояния</summary>
		public float СoefEconomicDistance { get; }

		/// <summary> Коэффициент светотехнически-наивыгоднейшего расстояния</summary>
		public float СoefLightingDistance { get; }

		public LightCurve(string name, float сoefEconomicDistance, float сoefLightingDistance)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new System.ArgumentException($"\"{nameof(name)}\" - наименоваание типа кривой силы света не может быть пустым или содержать только пробел.", nameof(name));
			}

			СoefEconomicDistance = сoefEconomicDistance;
			СoefLightingDistance = сoefLightingDistance;
		}
	}
}
