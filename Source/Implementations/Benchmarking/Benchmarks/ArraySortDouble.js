class ArraySortDouble
{
    Initialize(parameter)
    {
        var n = parameter;

        this.NumberArray = [];

        for (var i = 0; i < n; i++)
        {
            this.NumberArray.push(Math.random() * 1000000);
        }
    }

    Execute()
    {
        this.NumberArray.sort();

        return this.NumberArray[this.NumberArray.length / 2];
    }
}