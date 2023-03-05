using OfficeRetro.Domain.Auth.Entities;
using OfficeRetro.Domain.Inquiry.Exceptions.InquiryFile;
using OfficeRetro.Domain.Inquiry.ValueObjects;

namespace OfficeRetro.Domain.Inquiry.Entities;

public class InquiryAnswer
{
    public long Id { get; }
    public Guid Key { get; private set; }
#pragma warning disable
    private InquiryAnswerWriterId _writerId;
    private InquiryAnswerTargetId _targetId;
    private InquiryContent _content;
    private DateTime _createdAt;
    private DateTime _modifiedAt;
#pragma warning restore
    private readonly LinkedList<InquiryAnswerFile> _files = new();

    internal InquiryAnswer(
        Guid key,
        User user,
        long inquiryId,
        string content,
        DateTime createdAt,
        DateTime modifiedAt)
    {
        Key = key;
        _writerId = new InquiryAnswerWriterId(user);
        _targetId = new InquiryAnswerTargetId(inquiryId);
        _content = new InquiryContent(content);
        _createdAt = createdAt;
        _modifiedAt = modifiedAt;
    }

    private InquiryAnswer() { }

    public void Update(User user, string content)
    {
        _writerId = new InquiryAnswerWriterId(user);
        _content = new InquiryContent(content);
        _modifiedAt = DateTime.UtcNow;
    }

    public void AddFile(InquiryAnswerFile file)
    {
        var isFileExist = _files.Any(f => f.Key.Equals(file.Key));
        if (isFileExist) throw new InquiryFileAlreadyExistsException();

        _files.AddLast(file);
    }

    public void AddFiles(IEnumerable<InquiryAnswerFile> inquiryFiles)
    {
        _files.Clear();

        foreach (var inquiryFile in inquiryFiles)
        {
            AddFile(inquiryFile);
        }
    }

    public void RemoveFile(InquiryAnswerFile file)
    {
        var isFileExist = _files.Any(f => f.Key.Equals(file.Key));
        if (!isFileExist) return;

        _files.Remove(file);
    }
}
