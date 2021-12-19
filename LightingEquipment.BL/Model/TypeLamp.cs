
namespace LightingEquipment.BL.Model
{
	/// <summary> Тип лампы </summary>
	public class TypeLamp
	{
		/// <summary> Наименование типа лампы </summary>
		public string Name { get; }

		/// <summary> коэффициента минимальной освещенности </summary>
		public float CoefMinIllumination { get; }

		/// <summary> коэффициент запаса </summary>
		public float CoefStore { get; }

		/// <summary>
		/// Создать объект - Тип Лампы
		/// </summary>
		/// <param name="name">наименование типа лампы</param>
		/// <param name="minIlluminationCoef">коэффициента минимальной освещенности</param>
		/// <param name="stockRatio">коэффициент запаса</param>
		public TypeLamp(string name, float minIlluminationCoef, float stockRatio)
		{
			#region Проверка
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new System.ArgumentException($"\"{nameof(name)}\" - наименование типа лампы не может быть пустым или содержать только пробел.", nameof(name));
			} 
			#endregion

			CoefMinIllumination = minIlluminationCoef;
			CoefStore = stockRatio;
			Name = name;
		}
	}
}
