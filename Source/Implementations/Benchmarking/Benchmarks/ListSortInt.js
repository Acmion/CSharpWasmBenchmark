class ListSortInt
{
    Initialize(parameter)
    {
        var n = parameter;

        this.List = [];

        for (var i = 0; i < n; i++) 
        {
            this.List.push(Math.round(Math.random() * 1000000));
        }
    }

    Execute()
    {
        this.List.sort();

        return this.List[this.List.Count / 2];
    }
}