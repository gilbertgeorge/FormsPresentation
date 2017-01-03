public class MyColor
	{
		public string Name { get; set; }
		public int Red { get; set; }
		public int Green { get; set; }
		public int Blue { get; set; }

		public MyColor()
		{
		}

		public static IList<MyColor> GetColors()
		{
			return new List<MyColor>
			{
				new MyColor { Name = "Green", Red = 0x00, Green = 0xff, Blue = 0x00 },
				new MyColor { Name = "Red", Red = 0xff, Green = 0x00, Blue = 0x00 },
				new MyColor { Name = "Blue", Red = 0x00, Green = 0x00, Blue = 0xff },
				new MyColor { Name = "Brown", Red = 0xf4, Green = 0xa4, Blue = 0x60 },
				new MyColor { Name = "Pink", Red = 0xff, Green = 0xb6, Blue = 0xc1 },
				new MyColor { Name = "Yellow", Red = 0xff, Green = 0xff, Blue = 0x00 },
				new MyColor { Name = "Orange", Red = 0xff, Green = 0xa5, Blue = 0x00 },
				new MyColor { Name = "Gray", Red = 0xcc, Green = 0xcc, Blue = 0xcc },
				new MyColor { Name = "White", Red = 0xff, Green = 0xff, Blue = 0xff },
				new MyColor { Name = "Black", Red = 0x00, Green = 0x00, Blue = 0x00 },
				new MyColor { Name = "Purple", Red = 0x80, Green = 0x00, Blue = 0x80 },
				new MyColor { Name = "Navy", Red = 0x00, Green = 0x00, Blue = 0x80 },
				new MyColor { Name = "Magenta", Red = 0xff, Green = 0x00, Blue = 0xff },
				new MyColor { Name = "Cyan", Red = 0x00, Green = 0xff, Blue = 0xff },

			};
		}
	}