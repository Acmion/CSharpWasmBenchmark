class DictionaryAccessInt
{
    Initialize(parameter)
    {
        var n = parameter;

        this.Dictionary = {};
        this.DictionaryKeys = [];

        for (var i = 0; i < n; i++)
        {
            var val = Math.round(Math.random() * 1000000);

            this.Dictionary[i] = val;
            this.DictionaryKeys.push(i);
        }
    }

    Execute()
    {
        var sum = 0;
        var c = Object.keys(this.Dictionary).length;

        for (var i = 0; i < c; i++) 
        {
            var key = this.DictionaryKeys[Math.round(Math.random() * c)];
            sum += this.Dictionary[key];
        }

        return sum;
    }
}