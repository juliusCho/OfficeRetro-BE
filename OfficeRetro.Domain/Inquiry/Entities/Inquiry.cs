using OfficeRetro.Domain.Inquiry.Exceptions.InquiryFile;
using OfficeRetro.Domain.Inquiry.ValueObjects;

namespace OfficeRetro.Domain.Inquiry.Entities;

public class Inquiry
{
    public long Id { get; }
    public Guid Key { get; private set; }
#pragma warning disable
    private InquiryWriter _writer;
    private InquiryTitle _title;
    private InquiryContent _content;
    private InquiryPassword _password;
    private DateTime _createdAt;
    private DateTime _modifiedAt;
#pragma warning restore
    private readonly LinkedList<InquiryFile> _files = new();

    internal Inquiry(
        Guid key,
        string writer,
        string title,
        string content,
        string password,
        DateTime createdAt,
        DateTime modifiedAt)
    {
        Key = key;
        _writer = new InquiryWriter(writer);
        _title = new InquiryTitle(title);
        _content = new InquiryContent(content);
        _password = new InquiryPassword(password);
        _createdAt = createdAt;
        _modifiedAt = modifiedAt;
    }

    private Inquiry() { }

    public void Update(
        string writer, 
        string title, 
        string content, 
        string password)
    {
        _writer = new InquiryWriter(writer);
        _title = new InquiryTitle(title);
        _content = new InquiryContent(content);
        _password = new InquiryPassword(password);
        _modifiedAt = DateTime.UtcNow;
    }

    public void AddFile(InquiryFile file)
    {
        var isFileExist = _files.Any(f => f.Key.Equals(file.Key));
        if (isFileExist) throw new InquiryFileAlreadyExistsException();

        _files.AddLast(file);
        //AddEvent(new InquiryFileAdded(this, file));
    }

    public void AddFiles(IEnumerable<InquiryFile> inquiryFiles)
    {
        _files.Clear();

        foreach (var inquiryFile in inquiryFiles)
        {
            AddFile(inquiryFile);
        }
    }

    public void RemoveFile(InquiryFile file)
    {
        var isFileExist = _files.Any(f => f.Key.Equals(file.Key));
        if (!isFileExist) return;

        _files.Remove(file);
        //AddEvent(new InquiryFileRemoved(this, file));
    }
}
