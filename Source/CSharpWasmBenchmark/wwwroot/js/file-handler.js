class FileHandler
{
    static downloadTextAsFile(filename, text)
    {
        var anchor = document.createElement('a');
        anchor.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(text));
        anchor.setAttribute('download', filename);

        anchor.style.display = 'none';
        document.body.appendChild(anchor);

        anchor.click();

        document.body.removeChild(anchor);
    }
}