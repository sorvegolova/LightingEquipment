using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightingEquipment.BL.Model
{
	/// <summary> Коэффициент использования </summary>
	public class CoefUsage
	{
		/// <summary> Наименование кривой силы света </summary>
		public string NameLightCurve { get; }

		/// <summary> коэффициент отражения потолка </summary>
		public int ReflectionCeilingCoef { get; }

		/// <summary> коэффициент отражения стен </summary>
		public int ReflectionWallCoef { get; }

		/// <summary> коэффициент отражения рабочей поверхности </summary>
		public int ReflectionWorkSurfCoef { get; }

		/// <summary> Индекс помещения </summary>
		public float Index { get; }

		/// <summary> Коэффициент использования </summary>
		public int Coef { get; }

		/// <summary>
		/// Создать новый объект коэффициента использования
		/// </summary>
		/// <param name="nameLightCurve">Наименование кривой силы света</param>
		/// <param name="reflectionCeilingCoef">Коэффициент отражения потолка</param>
		/// <param name="reflectionWallCoef">Коэффициент отражения стен</param>
		/// <param name="reflectionWorkSurfCoef">Коэффициент отражения рабочей поверхности</param>
		/// <param name="index">Индекс помещения</param>
		/// <param name="coef">Коэффициента использования</param>
		public CoefUsage(string nameLightCurve, int reflectionCeilingCoef, int reflectionWallCoef, int reflectionWorkSurfCoef, float index, int coef)
		{
			#region Проверка
			if (string.IsNullOrWhiteSpace(nameLightCurve))
			{
				throw new ArgumentException("Наименование кривой силы света не может быть пустым или содержать только пробел.", nameof(nameLightCurve));
			}

			if (reflectionCeilingCoef < 0 || reflectionCeilingCoef > 100)
			{
				throw new ArgumentException("Коэффициент отражения потолка не может быть меньше 0 или больше 100", nameof(reflectionCeilingCoef));
			}

			if (reflectionWallCoef < 0 || reflectionWallCoef > 100)
			{
				throw new ArgumentException("Коэффициент отражения стен не может быть меньше 0 или больше 100", nameof(reflectionWallCoef));
			}

			if (reflectionWorkSurfCoef < 0 || reflectionWorkSurfCoef > 100)
			{
				throw new ArgumentException("Коэффициент отражения рабочей поверхности не может быть меньше 0 или больше 100", nameof(reflectionWorkSurfCoef));
			}

			if (index < 0)
			{
				throw new ArgumentException("Индекс не может быть равен или меньше 0", nameof(index));
			}

			if (coef < 0)
			{
				throw new ArgumentException("Коэффициент использования не может быть равен или меньше 0", nameof(coef));
			} 
			#endregion

			NameLightCurve = nameLightCurve;
			ReflectionCeilingCoef = reflectionCeilingCoef;
			ReflectionWallCoef = reflectionWallCoef;
			ReflectionWorkSurfCoef = reflectionWorkSurfCoef;
			Index = index;
			Coef = coef;
		}
	}
}
