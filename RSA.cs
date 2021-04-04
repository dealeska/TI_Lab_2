namespace TI_Lab_2
{
	static class RSA
	{
		public static long Fast_Exp(long a, long z, long n)
		{
			long a1 = a, z1 = z, x = 1;
			while (z1 != 0)
			{
				while (z1 % 2 == 0)
				{
					z1 = z1 / 2;
					a1 = (a1 * a1) % n;
				}
				z1 = z1 - 1;
				x = (x * a1) % n;
			}
			return x;
		}

		public static void Encrypt(ref long[] textNum, long key, long module)
		{
			for (int i = 0; i < textNum.Length; i++)
			{
				textNum[i] = Fast_Exp(textNum[i], key, module);
			}
		}
	}
}