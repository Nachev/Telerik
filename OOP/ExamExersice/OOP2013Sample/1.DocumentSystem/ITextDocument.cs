namespace DocumentSystem
{
    interface ITextDocument : IDocument
    {
        string Charset { get; }
    }
}
