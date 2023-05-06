﻿class MultiplicationDouble
{
    Initialize(parameter)
    {
        var n = parameter;

        this.List = [];

        for (var i = 0; i < n / 100; i++)
        {
            this.List.push(Math.random());
        }
    }

    Execute()
    {
        var res = 0.0;
        var c = this.List.length;

        for(var j = 0; j < 100; j++)
            for (var i = 0; i < c; i++) 
            {
                res += this.List[i] * i;
            }

        return res;
    }
}