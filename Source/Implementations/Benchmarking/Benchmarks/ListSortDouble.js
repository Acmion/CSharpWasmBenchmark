class ListSortDouble
{
    Initialize(parameter)
    {
        var n = parameter;

        this.List = [];

        for (var i = 0; i < n; i++) 
        {
            this.List.push(Math.random() * 1000000);
        }
    }

    Execute()
    {
        // This code converts the numbers to strings first...
        // this.List.sort();

        this.List.sort(function(a, b) 
        {
            return a - b;
        });

        return this.List[this.List.Count / 2];
    }
}