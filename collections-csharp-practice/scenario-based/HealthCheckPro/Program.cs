using System;
// Entry point that triggers API validation and documentation generation
class Program
{
    static void Main()
    {
        ApiMetadataScanner scanner = new ApiMetadataScanner();
        scanner.ScanControllers();
        ApiDocGenerator docGenerator = new ApiDocGenerator();
        string docs = docGenerator.GenerateDocs();
        Console.WriteLine("\n=== AUTO GENERATED API DOCS ===");
        Console.WriteLine(docs);
    }
}
