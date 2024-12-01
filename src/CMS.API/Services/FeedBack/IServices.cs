﻿using CMS.Shared.DTOs.FeedBack.Request;

namespace CMS.API.Services.FeedBack;

public interface IServices
{
  Task<Guid> CreateAsync(CreateFeedBackRequest request);
}
