class DictionaryAccessString
{
    Initialize(parameter)
    {
        var n = parameter;

        this.Dictionary = {};
        this.DictionaryKeys = [];

        for (var i = 0; i < n; i++)
        {
            var val = Math.round(Math.random() * 1000000);
            var key = i + ":" + val;

            this.Dictionary[key] = val;
            this.DictionaryKeys.push(key);
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