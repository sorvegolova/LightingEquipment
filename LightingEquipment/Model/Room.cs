using System;

namespace LightingEquipment.Model
{
	public class Room
	{
		/// <summary> Длина помещения </summary>
		public float Length { get; }

		/// <summary> Ширина помещения </summary>
		public float Width { get; }

		/// <summary> Высота помещения </summary>
		private float Height { get; }

		/// <summary> Высота рабочей поверхности </summary>
		public float HeightWorkingSurface { get; }

		/// <summary> Высота свеса светильника </summary>
		public float HeightOverhang { get; }

		/// <summary> Нормированная освещённость </summary>
		public float NormIllumination { get; }


		/// <summary> Площадь помещения </summary>
		public float Square { get; }

		/// <summary> Индекс помещения </summary>
		public float Index { get; }

		/// <summary> Высота светильника </summary>
		public float HeightLuminaire { get; }

		public Room(
			float length, float width, float height,
			float heightWorkingSurface, float heightOverhang,
			int normIllumination)
		{
			if (length <= 0)
			{
				throw new ArgumentException($"Длина помещения не может быть отрицательной или равной 0");
			}

			if (width <= 0)
			{
				throw new ArgumentException($"Ширина помещения не может быть отрицательной или равной 0");
			}

			if (height <= 0)
			{
				throw new ArgumentException($"Высота помещения не может быть отрицательной или равной 0");
			}

			if (heightWorkingSurface <= 0)
			{
				throw new ArgumentException($"Высота рабочей поверхности не может быть отрицательной или равной 0");
			}

			if (heightOverhang <= 0)
			{
				throw new ArgumentException($"Высота свеса светильника не может быть отрицательной или равной 0");
			}

			if (normIllumination <= 0)
			{
				throw new ArgumentException($"Нормированная освещённость не может быть отрицательной или равной 0");
			}


			Length = length;
			Width = width;
			Height = height;
			HeightWorkingSurface = heightWorkingSurface;
			HeightOverhang = heightOverhang;
			NormIllumination = normIllumination;

			Square = Width * Height;
			HeightLuminaire = Height - HeightOverhang - HeightWorkingSurface;
			Index = Width * Height / (Height * (Width + Height));
		}
	}
}
