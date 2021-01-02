class ArraySortIntQuick
{
    Initialize(parameter)
    {
        var n = parameter;

        this.NumberArray = [];

        for (var i = 0; i < n; i++)
        {
            this.NumberArray[i] = Math.round(Math.random() * 1000000);
        }
    }

    Execute()
    {
        this.SortMain(this.NumberArray);

        return this.NumberArray[this.NumberArray.length / 2];
    }


    SortMain(array)
    {
        this.Sort(array, 0, array.length - 1);
    }

    Sort(array, left, right)
    {
        if (left >= right)
        {
            return;
        }

        var p = this.Partition(array, left, right);
        this.Sort(array, left, p);
        this.Sort(array, p + 1, right);
    }

    SelectPivot(array, left, right)
    {
        return array[left + (right - left) / 2];
    } 

    Partition(array, left, right)
    {
        var pivot = this.SelectPivot(array, left, right);
        var nleft = left;
        var nright = right;
        while (true)
        {
            while (array[nleft] - pivot < 0)
            {
                nleft++;
            }

            while (array[nright] - pivot > 0)
            {
                nright--;
            }

            if (nleft >= nright)
            {
                return nright;
            }

            var t = array[nleft];
            array[nleft] = array[nright];
            array[nright] = t;

            nleft++;
            nright--;
        }
    }
}