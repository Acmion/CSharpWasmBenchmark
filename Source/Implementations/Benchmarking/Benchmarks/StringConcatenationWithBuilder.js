class StringConcatenationWithBuilder
{
    Initialize(parameter)
    {
        this.CharCount = parameter;
        this.Characters = "abcdefghijklmnopqrstuvwxyz";
    }

    Execute()
    {
        var res = "";

        for (var i = 0; i < this.CharCount; i++) 
        {
            res += this.Characters[i % this.Characters.length];
        }

        return res[this.CharCount / 2];
    }
}
