﻿using OfficeRetro.Shared.Constants.Inquiry;
using OfficeRetro.Shared.Exceptions.Inquiry;

namespace OfficeRetro.Domain.Inquiry.Exceptions.InquiryFile;

internal class InquiryFileUrlNullException : AuthNullException
{
    public InquiryFileUrlNullException()
        : base(InquiryExceptionMessages.File.EMPTY_URL) { }
}
