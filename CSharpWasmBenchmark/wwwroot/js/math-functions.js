class MathFunctions
{
	static average(array)
	{
		var sum = 0;

		for (var i = 0; i < array.length; i++)
		{
			sum += array[i];
		}

		return sum / array.length;
	}

	static standardDeviation(array)
	{
		var n = array.length;
		var mean = MathFunctions.average(array);
		return Math.sqrt(array.map(x => Math.pow(x - mean, 2)).reduce((a, b) => a + b) / n);
	}

}