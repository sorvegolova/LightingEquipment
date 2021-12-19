using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightingEquipment.BL.Model
{
	/// <summary> Лампа </summary>
	class Lamp
	{
		/// <summary> Наименование лампы </summary>
		public string Name { get; }

		/// <summary> Тип лампы </summary>
		public string TypeLamp { get; }
		
		/// <summary> Световой поток </summary>
		public int LuminousFlux { get; }

		/// <summary> Наименование кривой силы света </summary>
		public string LightCurveName { get; }

		/// <summary>
		/// Создать Лампу
		/// </summary>
		/// <param name="name">наименование лампы</param>
		/// <param name="typeLamp">тип лампы</param>
		/// <param name="luminousFlux">световой поток лампы</param>
		/// <param name="lightCurveName">наименование кривой силы света</param>
		public Lamp(string name, string typeLamp, int luminousFlux, string lightCurveName)
		{
			#region Проверка
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("Наименование лампы не может быть пустым или содержать только пробел", nameof(name));
			}

			if (string.IsNullOrWhiteSpace(typeLamp))
			{
				throw new ArgumentException("Наименование типа лампы не может быть пустым или содержать только пробел", nameof(typeLamp));
			}

			if (string.IsNullOrWhiteSpace(lightCurveName))
			{
				throw new ArgumentException("Наименование кривой силы света не может быть пустым или содержать только пробел.", nameof(lightCurveName));
			}

			if (luminousFlux <= 0)
			{
				throw new ArgumentException("Световой поток не может быть равен или меньше 0", nameof(luminousFlux));
			} 
			#endregion

			Name = name;
			TypeLamp = typeLamp;
			LuminousFlux = luminousFlux;
			LightCurveName = lightCurveName;
		}
	}
}
