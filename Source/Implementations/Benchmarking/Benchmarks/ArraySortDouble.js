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
        // This code converts the numbers to strings first...
        // this.NumberArray.sort();

        this.NumberArray.sort(function(a, b) 
        {
            return a - b;
        });

        return this.NumberArray[this.NumberArray.length / 2];
    }
}