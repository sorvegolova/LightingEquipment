
namespace LightingEquipment.BL.Model
{
	/// <summary>
	/// Тип кривой силы света
	/// </summary>
	public class LightCurve
	{
		/// <summary> наименоваание типа кривой силы света </summary>
		public string Name { get; }

		/// <summary> Коэффициент экономически-наивыгоднейшего расстояния</summary>
		public float СoefEconomicDistance { get; }

		/// <summary> Коэффициент светотехнически-наивыгоднейшего расстояния</summary>
		public float СoefLightingDistance { get; }


		/// <summary>
		/// Создать объект кривой силы света
		/// </summary>
		/// <param name="name">наименоваание типа кривой силы света</param>
		/// <param name="сoefEconomicDistance">Коэффициент экономически-наивыгоднейшего расстояния</param>
		/// <param name="сoefLightingDistance">Коэффициент светотехнически-наивыгоднейшего расстояния</param>
		public LightCurve(string name, float сoefEconomicDistance, float сoefLightingDistance)
		{
			#region Проверка
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new System.ArgumentException($"\"{nameof(name)}\" - наименоваание типа кривой силы света не может быть пустым или содержать только пробел.", nameof(name));
			} 
			#endregion

			СoefEconomicDistance = сoefEconomicDistance;
			СoefLightingDistance = сoefLightingDistance;
		}
	}
}
