using System;
using System.Collections.Generic;

public class DocumentSystem
{
    private static List<Document> documents = new List<Document>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        if (cmd == "AddTextDocument")
        {
            AddDocument(new TextDocument(), parameters);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddDocument(new PDFDocument(), parameters);
        }
        else if (cmd == "AddWordDocument")
        {
            AddDocument(new WordDocument(), parameters);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddDocument(new ExcelDocument(), parameters);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddDocument(new AudioDocument(), parameters);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddDocument(new VideoDocument(), parameters);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(parameters);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddDocument(Document doc, string attributes)
    {
        string[] attribs = attributes.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var attrib in attribs)
        {
            string[] keyAndValue = attrib.Split('=');
            string key = keyAndValue[0];
            string value = keyAndValue[1];
            doc.LoadProperty(key, value);
        }
        if (doc.Name != null)
        {
            documents.Add(doc);
            Console.WriteLine("Document added: " + doc.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void ListDocuments()
    {
        foreach (var doc in documents)
        {
            Console.WriteLine(doc);
        }
    }

    private static void EncryptDocument(string name)
    {
        bool documentFound = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Encrypt();
                    Console.WriteLine("Document encrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: " + name);
                }
                documentFound = true;
            }
        }
        if (!documentFound)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool documentFound = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Decrypt();
                    Console.WriteLine("Document decrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: " + name);
                }
                documentFound = true;
            }
        }
        if (!documentFound)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool documentFound = false;
        foreach (var doc in documents)
        {
            if (doc is IEncryptable)
            {
                ((IEncryptable)doc).Encrypt();
                documentFound = true;
            }
        }
        if (documentFound)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string parameters)
    {
        string[] nameAndContent = parameters.Split(';');
        string name = nameAndContent[0];
        string content = nameAndContent[1];
        bool documentFound = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                if (doc is IEditable)
                {
                    ((IEditable)doc).ChangeContent(content);
                    Console.WriteLine("Document content changed: " + doc.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: " + doc.Name);
                }
                documentFound = true;
            }
        }
        if (!documentFound)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }
}
