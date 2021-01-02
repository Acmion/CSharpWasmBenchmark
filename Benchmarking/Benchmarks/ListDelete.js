class ListDelete
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
        var c = this.List.length;

        for (var i = 0; i < c / 5; i++)
        {
            this.List.splice(0, 1);
        }

        return this.List[this.List.length / 2];
    }
}