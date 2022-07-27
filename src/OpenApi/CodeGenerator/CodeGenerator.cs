using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

namespace CodeGenerator;

public class App
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No file path was found!");
            return;
        }
        var document = ReadJson(args[0]);
        var paths = document.Paths;

        if (paths is null || paths.Count == 0)
        {
            Console.WriteLine("No path was found in the schema!");
            return;
        }

        RuntimeTextTemplate2 page;
        String pageContent;

        int countPaths = 0;
        bool shouldCreateWebApp = true;

        foreach (var path in paths)
        {
            var operations = path.Value.Operations;
            if (operations is null || operations.Count == 0)
            {
                Console.WriteLine("No path was found!");
                Environment.Exit(0);
            }
            foreach (var operation in operations)
            {
                if (countPaths > 0)
                {
                    shouldCreateWebApp = false;
                }

                var method = operation.Key.ToString().ToLower();
                method = GetHttpMethod(method);

                if (method == String.Empty)
                {
                    Console.WriteLine("Invalid operation found!");
                    Environment.Exit(0);
                }

                var response = operation.Value.Responses.FirstOrDefault().Value;
                var schema = response.Content.Values.FirstOrDefault()?.Schema;

                var parameters = operation.Value.Parameters;
                string parametersList = "";

                for (int i = 0; i < parameters.Count; i++)
                {
                    var parameter = parameters[i];
                    parametersList += GetDataTypeKeyword(parameter.Schema) + " " + parameter.Name;

                    if (i < parameters.Count - 1)
                    {
                        parametersList += ", ";
                    }
                }

                string returnValue;

                if (schema?.Type.ToLower() == "array")
                {
                    returnValue = GetArrayKeyword(schema);
                }
                else
                {
                    returnValue = GetPrimitiveValue(schema);
                }

                page = new RuntimeTextTemplate2
                {
                    Path = path.Key.ToString(),
                    Method = method,
                    ShouldCreateWebApp = shouldCreateWebApp,
                    ReturnValue = returnValue,
                    ParametersList = parametersList
                };
                pageContent = page.TransformText();
                File.AppendAllText(args[1], pageContent);

                countPaths++;
            }
        }
    }
    private static string GetHttpMethod(string method) => method switch
    {
        "get" => "MapGet",
        "post" => "MapPost",
        "put" => "MapPut",
        "delete" => "MapDelete",
        _ => String.Empty
    };
    private static string GetDataTypeKeyword(OpenApiSchema? schema) => schema?.Type switch
    {
        "string" => "string",
        "integer" => "int",
        "float" => "float",
        "boolean" => "bool",
        "double" => "double",
        _ => String.Empty
    };
    private static string GetArrayKeyword(OpenApiSchema? schema)
    {
        if (schema == null)
        {
            return String.Empty;
        }
        string returnValue = "[";
        while (schema.Items.Type == "array")
        {
            returnValue += ",";
            schema = schema.Items;
        }
        returnValue = "new " + GetDataTypeKeyword(schema.Items) + returnValue + "] {}";
        return returnValue;
    } 
    private static string GetPrimitiveValue(OpenApiSchema? schema) => schema?.Type switch
    {
        "string" => "\"\"",
        "integer" => "0",
        "boolean" => "false",
        "float" => "0.0f",
        "double" => "0.0d",
        _ => String.Empty,
    };
    private static OpenApiDocument? ReadJson(string args)
    {
        //var inputPath = "C:\\Users\\AnhThiDao\\openapi.json";
        var inputPath = "C:\\Users\\Anh Thi Dao\\Downloads\\petstore.json";

        if (!Path.IsPathRooted(args))
        {
            Console.WriteLine("The file path you entered does not have a root");
            return null;
        }

        OpenApiStreamReader reader = new OpenApiStreamReader();
        var diagnostic = new OpenApiDiagnostic();

        try
        {
            string path = Path.GetFullPath(args);
            Stream stream = File.OpenRead(path);
            OpenApiDocument newDocument = reader.Read(stream, out diagnostic);
            return newDocument;
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("Check to make sure you entered a correct file path because the file was not found.");
            Console.Error.WriteLine(e.Message);
            Environment.Exit(0);
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine("Check the file path you entered for errors.");
            Console.Error.WriteLine(e.Message);
            Environment.Exit(0);
            return null;
        }
        finally
        {
            if (diagnostic.Errors.Count == 0)
            {
                Console.WriteLine("Read File Successfully");
            }
            else
            {
                foreach (OpenApiError error in diagnostic.Errors)
                {
                    Console.WriteLine($"There was an error reading in the file: {error.Pointer}");
                    Console.Error.WriteLine(error.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}
