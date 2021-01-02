class SummationDouble
{
    Initialize(parameter)
    {
        var n = parameter;

        this.List = [];

        for (var i = 0; i < n; i++)
        {
            this.List.push(Math.random() * 100);
        }
    }

    Execute()
    {
        var res = 0.0;
        var c = this.List.length;

        for (var i = 0; i < c; i++) 
        {
            res += this.List[i];
        }

        return res;
    }
}