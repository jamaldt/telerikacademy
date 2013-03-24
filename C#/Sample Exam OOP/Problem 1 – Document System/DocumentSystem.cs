using System;
using System.Collections.Generic;
using Problem_1___Document_System;

public class DocumentSystem
{
    private static List<Document> documents = new List<Document>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);

        //AudioToStringTest();

    }

    private static void AudioToStringTest()
    {
        Audio audio = new Audio("Prodigy");
        //doc.content = "";
        audio.LengthInSeconds = "2134";
        audio.SampleRateHz = "50";

        Console.WriteLine(audio);
        Console.WriteLine("poly:");
        Document x = audio;
        Console.WriteLine(x);

        List<Document> docs = new List<Document>();
        docs.Add(audio);
        foreach (var document in docs)
        {
            Console.WriteLine(document);
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

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
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
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        Dictionary<string, string> attr = getDictAttr(attributes);
        string documentName = returnNameCmdValue(attr);
        if (documentName != null)
        {
            TextDocument newDoc = new TextDocument(documentName);
            documents.Add(newDoc);
            Console.WriteLine("Document added: " + documentName);
            foreach (var key in attr.Keys)
            {
                switch (key)
                {
                    case "charset":
                        newDoc.Charset = attr[key];
                        break;
                    case "content":
                        newDoc.Content = attr[key];
                        break;
                }
            }
        }
    }

    private static string returnNameCmdValue(Dictionary<string, string> attr)
    {
        if (attr.ContainsKey("name"))
        {
            string docName = attr["name"];
            attr.Remove("name");
            return docName;
        }
        else
        {
            Console.WriteLine("Document has no name");
            return null;
        }
    }

    private static void AddPdfDocument(string[] attributes)
    {
        Dictionary<string, string> attr = getDictAttr(attributes);
        string documentName = returnNameCmdValue(attr);
        if (documentName != null)
        {
            PDF newDoc = new PDF(documentName);
            documents.Add(newDoc);
            Console.WriteLine("Document added: " + documentName);
            foreach (var key in attr.Keys)
            {
                switch (key)
                {
                    case "pages":
                        newDoc.NumberOfPages = attr[key];
                        break;
                    case "size":
                        newDoc.SizeInBytes = attr[key];
                        break;
                    case "content":
                        newDoc.Content = attr[key];
                        break;
                }
            }
        }
    }

    private static void AddWordDocument(string[] attributes)
    {
        Dictionary<string, string> attr = getDictAttr(attributes);
        string documentName = returnNameCmdValue(attr);
        if (documentName != null)
        {
            Word newDoc = new Word(documentName);
            documents.Add(newDoc);
            Console.WriteLine("Document added: " + documentName);
            foreach (var key in attr.Keys)
            {
                switch (key)
                {
                    case "chars":
                        newDoc.NumberOfCharacters = attr[key];
                        break;
                    case "version":
                        newDoc.Version = attr[key];
                        break;
                    case "size":
                        newDoc.SizeInBytes = attr[key];
                        break;
                    case "content":
                        newDoc.Content = attr[key];
                        break;
                }
            }
        }
    }

    private static void AddExcelDocument(string[] attributes)
    {
        Dictionary<string, string> attr = getDictAttr(attributes);
        string documentName = returnNameCmdValue(attr);
        if (documentName != null)
        {
            Excel newDoc = new Excel(documentName);
            documents.Add(newDoc);
            Console.WriteLine("Document added: " + documentName);
            foreach (var key in attr.Keys)
            {
                switch (key)
                {
                    case "rows":
                        newDoc.Rows = attr[key];
                        break;
                    case "cols":
                        newDoc.Cols = attr[key];
                        break;
                    case "version":
                        newDoc.Version = attr[key];
                        break;
                    case "size":
                        newDoc.SizeInBytes = attr[key];
                        break;
                    case "content":
                        newDoc.Content = attr[key];
                        break;
                }
            }
        }
    }

    private static void AddAudioDocument(string[] attributes)
    {
        Dictionary<string, string> attr = getDictAttr(attributes);
        string documentName = returnNameCmdValue(attr);
        if (documentName != null)
        {
            Audio newDoc = new Audio(documentName);
            documents.Add(newDoc);
            Console.WriteLine("Document added: " + documentName);
            foreach (var key in attr.Keys)
            {
                switch (key)
                {
                    case "content":
                        newDoc.Content = attr[key];
                        break;
                    case "samplerate":
                        newDoc.SampleRateHz = attr[key];
                        break;
                    case "length":
                        newDoc.LengthInSeconds = attr[key];
                        break;
                    case "size":
                        newDoc.SizeInBytes = attr[key];
                        break;
                }
            }
        }
    }

    private static void AddVideoDocument(string[] attributes)
    {
        Dictionary<string, string> attr = getDictAttr(attributes);
        string documentName = returnNameCmdValue(attr);
        if (documentName != null)
        {
            Video newDoc = new Video(documentName);
            documents.Add(newDoc);
            Console.WriteLine("Document added: " + documentName);
            foreach (var key in attr.Keys)
            {
                switch (key)
                {
                    case "content":
                        newDoc.Content = attr[key];
                        break;
                    case "framerate":
                        newDoc.FrameRateFPS = attr[key];
                        break;
                    case "length":
                        newDoc.LengthInSeconds = attr[key];
                        break;
                    case "size":
                        newDoc.SizeInBytes = attr[key];
                        break;
                }
            }
        }
    }

    private static void ListDocuments()
    {
        if (documents.Count > 0)
        {
            foreach (var document in documents)
            {
                Console.WriteLine(document);
            }
        }
        else
            Console.WriteLine("No documents found");
    }

    private static void EncryptDocument(string name)
    {
        bool foundDocument = false;

        foreach (var document in documents)
        {
            if (document.Name.Equals(name))
            {
                foundDocument = true;
                IEncryptable doc = document as IEncryptable;
                if (doc != null)
                {
                    Console.WriteLine("Document encrypted: " + name);
                    if (!doc.IsEncrypted)
                    {
                        doc.Encrypt();
                    }
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: " + name);
                }
            }
        }

        if (!foundDocument)
            Console.WriteLine("Document not found: " + name);
    }

    private static void DecryptDocument(string name)
    {
        bool foundDocument = false;

        foreach (var document in documents)
        {
            if (document.Name.Equals(name))
            {
                foundDocument = true;
                IEncryptable doc = document as IEncryptable;
                if (doc != null)
                {
                    Console.WriteLine("Document decrypted: " + name);
                    if (doc.IsEncrypted)
                    {
                        doc.Decrypt();
                    }
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: " + name);
                }
            }
        }

        if (!foundDocument)
            Console.WriteLine("Document not found: " + name);
    }

    private static void EncryptAllDocuments()
    {
        bool isEncrypted = false;

        foreach (var document in documents)
        {
            if (document is IEncryptable)
            {
                isEncrypted = true;
                IEncryptable doc = document as IEncryptable;
                if (!doc.IsEncrypted)
                {
                    doc.Encrypt();
                }
            }
        }

        if(isEncrypted)
            Console.WriteLine("All documents encrypted");
        else
            Console.WriteLine("No encryptable documents found");
    }

    private static void ChangeContent(string name, string content)
    {
        bool foundDocument = false;

        foreach (var document in documents)
        {
            if (document.Name.Equals(name))
            {
                foundDocument = true;
                if (document is IEditable)
                {
                    ((IEditable)document).ChangeContent(content);
                    Console.WriteLine("Document content changed: " + name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: " + name);
                }
            }
        }

        if (!foundDocument)
            Console.WriteLine("Document not found: " + name);
    }

    private static Dictionary<string, string> getDictAttr(string[] attributes)
    {
        Dictionary<string, string> attr = new Dictionary<string, string>();
        foreach (var attribute in attributes)
        {
            string[] cmdAttributes = attribute.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            attr.Add(cmdAttributes[0], cmdAttributes[1]);
        }
        return attr;
    }
}
