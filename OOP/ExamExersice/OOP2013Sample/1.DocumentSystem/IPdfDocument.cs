namespace DocumentSystem
{
    public interface IPdfDocument
    {
        int NumberOfPages { get; }

        bool IsEncrypted { get; }

        void Encrypt();

        void Decrypt();
    }
}