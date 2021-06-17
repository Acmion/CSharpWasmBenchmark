class MultiplicationDouble
{
    Initialize(parameter)
    {
        var n = parameter;

        this.List = [];

        for (var i = 0; i < n / 1000; i++)
        {
            this.List.push(Math.random());
        }
    }

    Execute()
    {
        var res = 1.0;
        var c = this.List.length;

        for(var j = 0; j < 1000; j++)
            for (var i = 0; i < c; i++) 
            {
                res *= this.List[i];
            }

        return res;
    }
}