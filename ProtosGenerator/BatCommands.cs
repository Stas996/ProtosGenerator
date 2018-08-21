namespace ProtosGenerator
{
    public class BatCommands
    {
        public static string GetProtocCommand(string inputDirectory, string outputDirectory, string fileName)
        {
            return $"%PROTOC% --proto_path={inputDirectory} --csharp_out {outputDirectory} {fileName} --grpc_out {outputDirectory} --plugin=protoc-gen-grpc=%PLUGIN%";
        }
    }
}
